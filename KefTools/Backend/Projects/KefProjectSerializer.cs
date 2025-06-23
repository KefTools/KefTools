using System.IO.Compression;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Serilog;

namespace KefTools.Backend.Projects;

public static class KefProjectSerializer
{
    private static readonly ILogger kLog = Log.ForContext("Component", nameof(KefProjectSerializer));

    private static readonly XmlSerializer kXmlSerializer = new(typeof(KefProject));
    private static readonly XmlWriterSettings kXmlSettings = new()
    {
        Indent = false,
        Encoding = Encoding.UTF8,
        OmitXmlDeclaration = false,
        NewLineHandling = NewLineHandling.None
    };

    public static void Serialize(KefProject project, string filePath)
    {
        try
        {
            kLog.Debug("Serializing project to {Path}", filePath);

            using var xmlStream = new MemoryStream();
            using (var writer = XmlWriter.Create(xmlStream, kXmlSettings))
                kXmlSerializer.Serialize(writer, project);

            xmlStream.Position = 0;
            byte[] finalData;

#if DEBUG
            finalData = xmlStream.ToArray();
            kLog.Debug("DEBUG: writing readable project file with header");

            var header = new StringBuilder()
                .AppendLine("# KEFTOOLS PROJECT FILE")
                .AppendLine($"# MAGIC: KEFPROJ")
                .AppendLine($"# VERSION: 1")
                .AppendLine($"# PAYLOAD_LENGTH: {finalData.Length}")
                .AppendLine();

            File.WriteAllText(filePath, header.ToString(), Encoding.UTF8);

            using (var stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None))
                stream.Write(finalData, 0, finalData.Length);

#else
            using var compressed = new MemoryStream();
            using var deflater = new DeflateStream(compressed, CompressionLevel.Optimal, leaveOpen: true);

            xmlStream.CopyTo(deflater);
            deflater.Flush();

            finalData = compressed.ToArray();

            using var fs = File.Create(filePath);
            using var bw = new BinaryWriter(fs);
            KefProjectHeader.WriteHeader(bw, finalData.Length);
            bw.Write(finalData);
#endif

            kLog.Information("Project serialized successfully.");
        }
        catch (Exception ex)
        {
            kLog.Error(ex, "Failed to serialize project.");
        }
    }

    public static KefProject? Deserialize(string filePath)
    {
        try
        {
            kLog.Debug("Deserializing project from {Path}", filePath);

            if (!File.Exists(filePath))
                return null;

            using var fs = File.OpenRead(filePath);

            // Try reading readable debug header
            if (TryReadDebug(fs, out var debugProject))
            {
                kLog.Debug("Loaded DEBUG-format project.");
                return debugProject;
            }

            // Reset and try reading release format
            fs.Position = 0;
            using var br = new BinaryReader(fs);

            if (!KefProjectHeader.TryReadHeader(br, out var payloadLength))
            {
                kLog.Error("Unrecognized file format: missing valid KEF header.");
                return null;
            }

            byte[] compressed = br.ReadBytes(payloadLength);
            using var input = new MemoryStream(compressed);
            using var inflater = new DeflateStream(input, CompressionMode.Decompress);
            using var xmlReader = XmlReader.Create(inflater);
            return kXmlSerializer.Deserialize(xmlReader) as KefProject;
        }
        catch (Exception ex)
        {
            kLog.Error(ex, "Failed to deserialize project.");
            return null;
        }
    }

    private static bool TryReadDebug(Stream stream, out KefProject? project)
    {
        project = null;

        try
        {
            using var reader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, bufferSize: 1024, leaveOpen: true);
            var lines = new List<string>();
            while (!reader.EndOfStream)
                lines.Add(reader.ReadLine()!);

            int xmlStart = lines.FindIndex(line => !line.StartsWith('#'));
            if (xmlStart < 0) return false;

            var xml = string.Join("\n", lines.Skip(xmlStart));
            using var sr = new StringReader(xml);
            project = kXmlSerializer.Deserialize(sr) as KefProject;
            return project != null;
        }
        catch
        {
            return false;
        }
    }

}
