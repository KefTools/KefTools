namespace KefTools.Backend.Projects;

public static class KefProjectHeader
{
    public const string kMagicString = "KEFPROJ\0";
    public static readonly byte[] kMagic = System.Text.Encoding.ASCII.GetBytes(kMagicString);

    public const byte kVersion = 1;
    public const int kHeaderSize = 0x10;

    public static void WriteHeader(BinaryWriter writer, int payloadLength)
    {
        writer.Write(kMagic);               // 8 bytes
        writer.Write(kVersion);            // 1 byte
        writer.Write(new byte[3]);        // 3 reserved
        writer.Write(payloadLength);      // 4 bytes
    }

    public static bool TryReadHeader(BinaryReader reader, out int payloadLength)
    {
        Span<byte> magic = stackalloc byte[8];
        reader.Read(magic);
        if (!magic.SequenceEqual(kMagic)) { payloadLength = 0; return false; }

        var version = reader.ReadByte();
        if (version != kVersion) { payloadLength = 0; return false; }

        reader.ReadBytes(3); // reserved
        payloadLength = reader.ReadInt32();
        return payloadLength > 0;
    }
}
