using System.Xml.Serialization;
using KefTools.Frontend.Framework.Generators.Property;

namespace KefTools.Backend.Projects;

[XmlRoot("Project")]
public sealed class KefProject
{
    public const string kExtension = ".kproj";

    [Property(PropertyType.FolderBrowser, "Working Directory")]
    public string WorkingDirectory { get; set; } = string.Empty;

    [Property(PropertyType.FolderBrowser, "Release Directory")]
    public string ReleaseDirectory { get; set; } = string.Empty;

    public void Save(string path) => KefProjectSerializer.Serialize(this, path);
    public static KefProject? Load(string path) => KefProjectSerializer.Deserialize(path);

}
