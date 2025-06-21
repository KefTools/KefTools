using KefTools.Formats;
using Serilog;

namespace KefTools.Dialogs;

public partial class NewProjectDialog : Form
{
    private static readonly ILogger log = Log.ForContext("Component", "NewProjectDialog");

    public KefProject? Project { get; private set; }

    public string WorkingDirectory => textWorkingDir.Text.Trim();
    public string ReleaseDirectory => textReleaseDir.Text.Trim();

    public NewProjectDialog()
    {
        InitializeComponent();
        log.Debug("Dialog initialized.");
    }

    private void BrowseWorkingDir(object sender, EventArgs e)
    {
        folderBrowserDialog.Description = "Select Working Directory";
        folderBrowserDialog.SelectedPath = string.IsNullOrWhiteSpace(WorkingDirectory)
            ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            : WorkingDirectory;

        if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
        {
            textWorkingDir.Text = folderBrowserDialog.SelectedPath;
            log.Debug("Selected Working Directory: {Path}", textWorkingDir.Text);
        }
        else
        {
            log.Debug("Working directory selection canceled.");
        }
    }

    private void BrowseReleaseDir(object sender, EventArgs e)
    {
        folderBrowserDialog.Description = "Select Release Directory";
        folderBrowserDialog.SelectedPath = string.IsNullOrWhiteSpace(ReleaseDirectory)
            ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            : ReleaseDirectory;

        if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
        {
            textReleaseDir.Text = folderBrowserDialog.SelectedPath;
            log.Debug("Selected Release Directory: {Path}", textReleaseDir.Text);
        }
        else
        {
            log.Debug("Release directory selection canceled.");
        }
    }

    private void ConfirmProject(object? sender, EventArgs e)
    {
        log.Debug("Attempting to confirm project creation...");

        if (string.IsNullOrWhiteSpace(WorkingDirectory) || string.IsNullOrWhiteSpace(ReleaseDirectory))
        {
            log.Warning("Validation failed: one or both directories are empty.");
            MessageBox.Show(
                "Both Working and Release directories are required.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            DialogResult = DialogResult.None;
            return;
        }

        Project = new KefProject
        {
            WorkingDirectory = WorkingDirectory,
            ReleaseDirectory = ReleaseDirectory
        };

        log.Information("Project created: WorkingDirectory={Working}",
            Project.WorkingDirectory);

        DialogResult = DialogResult.OK;
        Close();
    }
}
