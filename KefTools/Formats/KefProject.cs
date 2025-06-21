using System.IO.Compression;
using System.Text;
using System.Xml.Serialization;
using Serilog;

namespace KefTools.Formats;

/// <summary>
/// Represents the header structure of a .kproj file.
/// </summary>
public struct KefProjectHeader
{
    public const string Magic = "KEFPROJ\0";
    public const byte Version = 1;
    public const int HeaderSize = 0x10;

    public byte VersionByte;
    public int PayloadLength;

    public static readonly byte[] MagicBytes = Encoding.ASCII.GetBytes(Magic);
}

/// <summary>
/// Represents a KefTools project configuration.
/// </summary>
[XmlRoot("KefProject")]
public class KefProject
{
    private static readonly ILogger log = Log.ForContext("Component", "KefProject");

    public const string Extension = ".kproj";

    public string WorkingDirectory { get; set; } = string.Empty;
    public string ReleaseDirectory { get; set; } = string.Empty;

    /// <summary>
    /// Saves the current KefProject to a file.
    /// </summary>
    public void Serialize(string filePath)
    {
        try
        {
            log.Information("Serializing KefProject to {FilePath}", filePath);

            // Serialize object to XML
            using var xmlStream = new MemoryStream();
            new XmlSerializer(typeof(KefProject)).Serialize(xmlStream, this);
            var xmlBytes = xmlStream.ToArray();
            log.Debug("Serialized XML: {Size} bytes", xmlBytes.Length);
            // Compress XML
            using var compressedStream = new MemoryStream();
            using (var deflate = new DeflateStream(compressedStream, CompressionLevel.Optimal, leaveOpen: true))
                deflate.Write(xmlBytes, 0, xmlBytes.Length);
            var compressed = compressedStream.ToArray();
            log.Debug("Compressed XML: {Size} bytes", compressed.Length);

            // Write to file
            using var fs = File.Create(filePath);
            using var bw = new BinaryWriter(fs);

            bw.Write(KefProjectHeader.MagicBytes);
            bw.Write(KefProjectHeader.Version);
            bw.Write(new byte[3]); // reserved

#if !DEBUG
            bw.Write(compressed.Length);
            bw.Write(compressed);
#else
            bw.Write(xmlBytes.Length);
            bw.Write(xmlBytes);
#endif

            log.Information("KefProject saved successfully to {FilePath}", filePath);
        }
        catch (Exception ex)
        {
            log.Error(ex, "Failed to serialize KefProject to {FilePath}", filePath);
        }
    }

    /// <summary>
    /// Loads a KefProject from the given file.
    /// </summary>
    public static KefProject? Deserialize(string filePath)
    {
        log.Information("Deserializing KefProject from {FilePath}", filePath);

        try
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Project file not found.", filePath);

            using var fs = File.OpenRead(filePath);
            if (fs.Length < KefProjectHeader.HeaderSize)
                throw new InvalidDataException("File too small to be a valid .kproj.");

            using var br = new BinaryReader(fs);

            // Header validation
            Span<byte> magic = stackalloc byte[8];
            br.Read(magic);
            if (!magic.SequenceEqual(KefProjectHeader.MagicBytes))
                throw new InvalidDataException("Invalid file magic.");

            if (br.ReadByte() != KefProjectHeader.Version)
                throw new InvalidDataException("Unsupported .kproj version.");

            br.ReadBytes(3); // skip reserved
            int length = br.ReadInt32();
            if (length <= 0 || length > fs.Length - KefProjectHeader.HeaderSize)
                throw new InvalidDataException("Corrupt compressed XML length.");

            var compressed = br.ReadBytes(length);



            // Decompress and deserialize
            using var compressedStream = new MemoryStream(compressed);
            using var deflate = new DeflateStream(compressedStream, CompressionMode.Decompress);

#if !DEBUG
            using var reader = new StreamReader(deflate, Encoding.UTF8);
#else
            using var reader = new StreamReader(compressedStream, Encoding.UTF8);
#endif

            string xml = reader.ReadToEnd();
            log.Debug("Decompressed XML loaded. Size: {Size} chars", xml.Length);

            var project = new XmlSerializer(typeof(KefProject)).Deserialize(new StringReader(xml)) as KefProject;
            if (project == null)
                throw new InvalidDataException("Deserialized project is null.");

            log.Information("KefProject loaded successfully from {FilePath}", filePath);
            return project;
        }
        catch (Exception ex)
        {
            log.Error(ex, "Failed to load KefProject from {FilePath}", filePath);
            return null;
        }
    }
}
