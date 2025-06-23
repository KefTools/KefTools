using System.IO.Compression;
using System.Text;
using System.Xml.Serialization;
using Serilog;

namespace KefTools.Formats
{
    #region Interfaces

    /// <summary>
    /// Defines the contract for a serializable project configuration.
    /// </summary>
    public interface IProject
    {
        string WorkingDirectory { get; set; }
        string ReleaseDirectory { get; set; }
        List<TypedDirectory> SourceDirectories { get; }

        void Serialize(string filePath);
        void AddBlkSource(string folderPath);
    }

    #endregion

    #region Metadata

    public struct ProjectHeader
    {
        public const string Magic = "KEFPROJ\0";
        public const byte Version = 1;
        public const int HeaderSize = 0x10;

        public byte VersionByte;
        public int PayloadLength;

        public static readonly byte[] MagicBytes = Encoding.ASCII.GetBytes(Magic);
    }

    public enum SourceType
    {
        Unknown,
        Blk
    }

    [Serializable]
    public class TypedDirectory
    {
        [XmlAttribute("type")]
        public SourceType Type { get; set; } = SourceType.Unknown;

        [XmlText]
        public string Path { get; set; } = string.Empty;

        public TypedDirectory() { }
    }

    #endregion

    [XmlRoot("Project")]
    public class Project : IProject
    {
        private static readonly ILogger log = Log.ForContext("Component", "Project");

        public const string Extension = ".kproj";

        public string WorkingDirectory { get; set; } = string.Empty;
        public string ReleaseDirectory { get; set; } = string.Empty;

        [XmlArray("Sources")]
        [XmlArrayItem("Directory")]
        public List<TypedDirectory> SourceDirectories { get; set; } = [];

        public void AddBlkSource(string folderPath)
        {
            if (!SourceDirectories.Any(x => x.Path.Equals(folderPath, StringComparison.OrdinalIgnoreCase)))
            {
                SourceDirectories.Add(new TypedDirectory
                {
                    Type = SourceType.Blk,
                    Path = folderPath
                });
                log.Debug("Added BLK source folder: {Path}", folderPath);
            }
        }

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
                var header = new StringBuilder()
                    .AppendLine("# KEFTOOLS PROJECT FILE")
                    .AppendLine($"# MAGIC: {ProjectHeader.Magic.Trim('\0')}")
                    .AppendLine($"# VERSION: {ProjectHeader.Version}")
                    .AppendLine($"# PAYLOAD_LENGTH: {xmlBytes.Length}")
                    .AppendLine();

                File.WriteAllText(filePath, header.ToString(), Encoding.UTF8);
                File.AppendAllText(filePath, Encoding.UTF8.GetString(xmlBytes));
                log.Information("Project saved as readable file to {FilePath}", filePath);
#else
                using var compressedStream = new MemoryStream();
                using (var deflate = new DeflateStream(compressedStream, CompressionLevel.Optimal, leaveOpen: true))
                    deflate.Write(xmlBytes, 0, xmlBytes.Length);

                var compressed = compressedStream.ToArray();
                log.Debug("XML compressed: {CompressedLength} bytes", compressed.Length);

                using var fs = File.Create(filePath);
                using var writer = new BinaryWriter(fs);
                writer.Write(ProjectHeader.MagicBytes);
                writer.Write(ProjectHeader.Version);
                writer.Write(new byte[3]);
                writer.Write(compressed.Length);
                writer.Write(compressed);

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

                int xmlStart = Array.FindIndex(lines, line => !line.StartsWith('#'));
                if (xmlStart == -1)
                {
                    log.Error("No XML content found in project file: {FilePath}", filePath);
                    return null;
                }

                var xml = string.Join("\n", lines.Skip(xmlStart));
                log.Debug("Extracted XML from readable file. Length: {Length}", xml.Length);

                return DeserializeXml(xml);
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

                br.ReadBytes(3); // reserved
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

                return DeserializeXml(xml);
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

        #region Helpers

        private static Project? DeserializeXml(string xml)
        {
            try
            {
                log.Debug("Attempting to deserialize the following XML:\n{Xml}", xml);

                var serializer = new XmlSerializer(typeof(Project));
                using var reader = new StringReader(xml);
                var result = serializer.Deserialize(reader) as Project;

                if (result == null)
                    log.Error("XML deserialization returned null.");

                return result;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Failed to deserialize XML content.");
                return null;
            }
        }

        #endregion
    }
}
