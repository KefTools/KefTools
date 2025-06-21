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
                log.Information("Starting serialization of Project to {FilePath}", filePath);
                log.Debug("WorkingDirectory={Working}, ReleaseDirectory={Release}", WorkingDirectory, ReleaseDirectory);

                using var xmlStream = new MemoryStream();
                new XmlSerializer(typeof(Project)).Serialize(xmlStream, this);
                var xmlBytes = xmlStream.ToArray();

                log.Debug("XML serialized successfully: {Length} bytes", xmlBytes.Length);

#if DEBUG
                var header = new StringBuilder();
                header.AppendLine("# KEFTOOLS PROJECT FILE");
                header.AppendLine($"# MAGIC: {ProjectHeader.Magic.Trim('\0')}");
                header.AppendLine($"# VERSION: {ProjectHeader.Version}");
                header.AppendLine($"# PAYLOAD_LENGTH: {xmlBytes.Length}");
                header.AppendLine();

                File.WriteAllText(filePath, header.ToString(), Encoding.UTF8);
                File.AppendAllText(filePath, Encoding.UTF8.GetString(xmlBytes));
                log.Information("Project saved as readable file to {FilePath}", filePath);
#else
                using var compressedStream = new MemoryStream();
                using (var deflate = new DeflateStream(compressedStream, CompressionLevel.Optimal, leaveOpen: true))
                {
                    deflate.Write(xmlBytes, 0, xmlBytes.Length);
                }

                var compressed = compressedStream.ToArray();
                log.Debug("XML compressed: {CompressedLength} bytes", compressed.Length);

                using var fs = File.Create(filePath);
                using var bw = new BinaryWriter(fs);
                bw.Write(ProjectHeader.MagicBytes);
                bw.Write(ProjectHeader.Version);
                bw.Write(new byte[3]);
                bw.Write(compressed.Length);
                bw.Write(compressed);

                log.Information("Project saved to {FilePath}", filePath);
#endif
            }
            catch (Exception ex)
            {
                log.Error(ex, "Exception during project serialization to {FilePath}", filePath);
            }
        }

        #endregion

        #region Deserialize

        public static Project? Deserialize(string filePath)
        {
            log.Information("Attempting to deserialize project from {FilePath}", filePath);

            try
            {
                if (!File.Exists(filePath))
                {
                    log.Warning("File not found: {FilePath}", filePath);
                    return null;
                }

#if DEBUG
                var lines = File.ReadAllLines(filePath);
                if (!lines.Any(l => l.Contains(ProjectHeader.Magic.Trim('\0'))))
                {
                    log.Error("Missing or malformed readable header in project file: {FilePath}", filePath);
                    return null;
                }

                var xml = string.Join('\n', lines.SkipWhile(line => line.StartsWith('#')));
                log.Debug("Extracted XML from readable file. Length: {Length}", xml.Length);

                var project = new XmlSerializer(typeof(Project)).Deserialize(new StringReader(xml)) as Project;
                if (project == null)
                {
                    log.Error("Deserialization returned null project.");
                    return null;
                }

                log.Information("Project loaded successfully from readable file.");
                return project;
#else
                using var fs = File.OpenRead(filePath);
                if (fs.Length < ProjectHeader.HeaderSize)
                {
                    log.Error("Project file too small to be valid. Size: {Length}", fs.Length);
                    return null;
                }

                using var br = new BinaryReader(fs);
                Span<byte> magic = stackalloc byte[8];
                br.Read(magic);

                if (!magic.SequenceEqual(ProjectHeader.MagicBytes))
                {
                    log.Error("Invalid magic header in project file.");
                    return null;
                }

                var version = br.ReadByte();
                if (version != ProjectHeader.Version)
                {
                    log.Error("Unsupported project version: {Version} (expected {Expected})", version, ProjectHeader.Version);
                    return null;
                }

                br.ReadBytes(3);
                int length = br.ReadInt32();
                if (length <= 0 || length > fs.Length - ProjectHeader.HeaderSize)
                {
                    log.Error("Declared XML length is invalid: {Length}", length);
                    return null;
                }

                var compressed = br.ReadBytes(length);
                using var compressedStream = new MemoryStream(compressed);
                using var deflate = new DeflateStream(compressedStream, CompressionMode.Decompress);
                using var reader = new StreamReader(deflate, Encoding.UTF8);
                var xml = reader.ReadToEnd();

                var project = new XmlSerializer(typeof(Project)).Deserialize(new StringReader(xml)) as Project;
                if (project == null)
                {
                    log.Error("Deserialization returned null project.");
                    return null;
                }

                log.Information("Project loaded successfully from binary file.");
                return project;
#endif
            }
            catch (InvalidDataException ide)
            {
                log.Warning(ide, "Invalid project data in file: {FilePath}", filePath);
                return null;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Unexpected error while loading project from {FilePath}", filePath);
                return null;
            }
        }

        #endregion
    }
}
