using System.Reflection;
using KefTools.Frontend.Framework.Generators.Property;
using KefTools.UI.Settings.Controls;

namespace KefTools.UI.Settings;

public partial class PropertyEditorPanel : FlowLayoutPanel
{
    private readonly object mTarget;
    private readonly Dictionary<PropertyInfo, IPropertyControl> mBindings = [];

    public PropertyEditorPanel(object target)
    {
        mTarget = target;
        FlowDirection = FlowDirection.TopDown;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        WrapContents = false;

        GenerateControls();
    }

    private void GenerateControls()
    {
        foreach (var prop in mTarget.GetType().GetProperties())
        {
            var attr = prop.GetCustomAttribute<PropertyAttribute>();
            if (attr == null) continue;

            var control = CreateComponent(attr.Type);
            control.Label = attr.Label ?? prop.Name;
            control.Value = prop.GetValue(mTarget)?.ToString() ?? "";

            Controls.Add((Control)control);
            mBindings[prop] = control;
        }
    }

    public void ApplyChanges()
    {
        foreach (var (prop, control) in mBindings)
        {
            var converted = Convert.ChangeType(control.Value, prop.PropertyType);
            prop.SetValue(mTarget, converted);
        }
    }

    private static IPropertyControl CreateComponent(PropertyType type) => type switch
    {
        PropertyType.Text => new TextPropertyControl(),
        PropertyType.FolderBrowser => new FolderBrowserPropertyControl(),
        _ => throw new NotSupportedException($"Unsupported setting type: {type}")
    };
}
