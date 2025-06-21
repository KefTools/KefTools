using System.IO.Compression;
using System.Text;
using System.Xml.Serialization;
using Serilog;

namespace KefTools.Formats
{
    #region Interface
    /// <summary>
    /// Defines the contract for a serializable project configuration.
    /// </summary>
    public interface IProject
    {
        /// <summary>
        /// Gets or sets the working directory for the project.
        /// </summary>
        string WorkingDirectory { get; set; }

        /// <summary>
        /// Gets or sets the release output directory for the project.
        /// </summary>
        string ReleaseDirectory { get; set; }

        /// <summary>
        /// Serializes the project to a file at the given path.
        /// </summary>
        /// <param name="filePath">Destination path for the serialized project.</param>
        void Serialize(string filePath);
    }
    #endregion

    #region Header

    public struct ProjectHeader
    {
        public const string Magic = "KEFPROJ\0";
        public const byte Version = 1;
        public const int HeaderSize = 0x10;

        public byte VersionByte;
        public int PayloadLength;

        public static readonly byte[] MagicBytes = Encoding.ASCII.GetBytes(Magic);
    }

    #endregion

    [XmlRoot("Project")]
    public class Project : IProject
    {
        private static readonly ILogger log = Log.ForContext("Component", "Project");

        public const string Extension = ".kproj";

        public string WorkingDirectory { get; set; } = string.Empty;
        public string ReleaseDirectory { get; set; } = string.Empty;

        #region Serialize

        public void Serialize(string filePath)
        {
            try
            {
                log.Information("Serializing Project to {FilePath}", filePath);

                // Convert to XML
                using var xmlStream = new MemoryStream();
                new XmlSerializer(typeof(Project)).Serialize(xmlStream, this);
                var xmlBytes = xmlStream.ToArray();
                log.Debug("Serialized XML: {Size} bytes", xmlBytes.Length);

#if DEBUG
                // Human-readable header
                var header = new StringBuilder();
                header.AppendLine("# KEFTOOLS PROJECT FILE");
                header.AppendLine($"# MAGIC: {ProjectHeader.Magic.Trim('\0')}");
                header.AppendLine($"# VERSION: {ProjectHeader.Version}");
                header.AppendLine($"# PAYLOAD_LENGTH: {xmlBytes.Length}");
                header.AppendLine();
                File.WriteAllText(filePath, header.ToString(), Encoding.UTF8);
                File.AppendAllText(filePath, Encoding.UTF8.GetString(xmlBytes));
#else
                // Compress XML
                using var compressedStream = new MemoryStream();
                using (var deflate = new DeflateStream(compressedStream, CompressionLevel.Optimal, leaveOpen: true))
                    deflate.Write(xmlBytes, 0, xmlBytes.Length);
                var compressed = compressedStream.ToArray();

                // Binary output
                using var fs = File.Create(filePath);
                using var bw = new BinaryWriter(fs);
                bw.Write(ProjectHeader.MagicBytes);
                bw.Write(ProjectHeader.Version);
                bw.Write(new byte[3]);
                bw.Write(compressed.Length);
                bw.Write(compressed);
#endif

                log.Information("Project saved to {FilePath}", filePath);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Failed to serialize Project to {FilePath}", filePath);
            }
        }


        #endregion

        #region Deserialize

        public static Project? Deserialize(string filePath)
        {
            log.Information("Deserializing Project from {FilePath}", filePath);

            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("Project file not found.", filePath);

#if DEBUG
                var lines = File.ReadAllLines(filePath);
                if (!lines.Any(l => l.Contains(ProjectHeader.Magic.Trim('\0'))))
                    throw new InvalidDataException("Missing or invalid readable header.");

                var xml = string.Join('\n', lines.SkipWhile(line => line.StartsWith('#')));
                log.Debug("Loaded readable XML. Length: {Length} chars", xml.Length);

                var project = new XmlSerializer(typeof(Project)).Deserialize(new StringReader(xml)) as Project;
                if (project == null)
                    throw new InvalidDataException("Deserialized project is null.");

                return project;
#else
                using var fs = File.OpenRead(filePath);
                if (fs.Length < ProjectHeader.HeaderSize)
                    throw new InvalidDataException("File too small to be valid.");

                using var br = new BinaryReader(fs);
                Span<byte> magic = stackalloc byte[8];
                br.Read(magic);
                if (!magic.SequenceEqual(ProjectHeader.MagicBytes))
                    throw new InvalidDataException("Invalid file magic.");

                if (br.ReadByte() != ProjectHeader.Version)
                    throw new InvalidDataException("Unsupported version.");

                br.ReadBytes(3); // reserved
                int length = br.ReadInt32();
                if (length <= 0 || length > fs.Length - ProjectHeader.HeaderSize)
                    throw new InvalidDataException("Corrupt XML length.");

                var compressed = br.ReadBytes(length);
                using var compressedStream = new MemoryStream(compressed);
                using var deflate = new DeflateStream(compressedStream, CompressionMode.Decompress);
                using var reader = new StreamReader(deflate, Encoding.UTF8);
                var xml = reader.ReadToEnd();

                var project = new XmlSerializer(typeof(Project)).Deserialize(new StringReader(xml)) as Project;
                if (project == null)
                    throw new InvalidDataException("Deserialized project is null.");

                return project;
#endif
            }
            catch (Exception ex)
            {
                log.Error(ex, "Failed to load Project from {FilePath}", filePath);
                return null;
            }
        }


        #endregion
    }
}
