using KefTools.Backend.Projects;
using KefTools.UI.Settings;
using Serilog;

namespace KefTools.Dialogs;

public partial class NewProjectDialog : Form
{
    private static readonly ILogger kLog = Log.ForContext("Component", "NewProjectDialog");

    private readonly KefProject mProject = new();
    private readonly PropertyEditorPanel mEditor;

    public KefProject? Project => DialogResult == DialogResult.OK ? mProject : null;

    public NewProjectDialog()
    {
        InitializeComponent();
        kLog.Debug("NewProjectDialog initialized.");

        mEditor = new PropertyEditorPanel(mProject)
        {
            Dock = DockStyle.Fill
        };

        var buttonPanel = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.RightToLeft,
            Dock = DockStyle.Bottom,
            Padding = new Padding(10),
            Height = 45,
            AutoSize = true
        };

        var okButton = new Button { Text = "OK", DialogResult = DialogResult.OK };
        var cancelButton = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel };

        okButton.Click += ConfirmProject;

        buttonPanel.Controls.Add(okButton);
        buttonPanel.Controls.Add(cancelButton);

        Controls.Add(mEditor);
        Controls.Add(buttonPanel);

        AcceptButton = okButton;
        CancelButton = cancelButton;

        Text = "Create New Project";
        StartPosition = FormStartPosition.CenterParent;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        FormBorderStyle = FormBorderStyle.FixedDialog;
    }

    private void ConfirmProject(object? sender, EventArgs e)
    {
        kLog.Debug("Validating and confirming project creation...");

        mEditor.ApplyChanges();

        if (string.IsNullOrWhiteSpace(mProject.WorkingDirectory) || string.IsNullOrWhiteSpace(mProject.ReleaseDirectory))
        {
            kLog.Warning("Validation failed: empty directories.");
            MessageBox.Show("Both Working and Release directories are required.",
                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        kLog.Information("Project confirmed: WorkingDirectory={Working}", mProject.WorkingDirectory);
        DialogResult = DialogResult.OK;
        Close();
    }
}