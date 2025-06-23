using KefTools.Backend.Projects;
using Serilog;

namespace KefTools.Dialogs
{
    public partial class EditProjectDialog : Form
    {
        private static readonly ILogger kLog = Log.ForContext("Component", "ProjectSettingsDialog");

        public KefProject? Project { get; private set; }

        public string WorkingDirectory => textWorkingDir.Text.Trim();
        public string ReleaseDirectory => textReleaseDir.Text.Trim();

        public EditProjectDialog(KefProject existingProject)
        {
            InitializeComponent();
            kLog.Debug("Settings dialog initialized.");

            textWorkingDir.Text = existingProject.WorkingDirectory;
            textReleaseDir.Text = existingProject.ReleaseDirectory;

            Project = existingProject;
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
                kLog.Debug("Updated Working Directory: {Path}", textWorkingDir.Text);
            }
            else
            {
                kLog.Debug("Working directory selection canceled.");
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
                kLog.Debug("Updated Release Directory: {Path}", textReleaseDir.Text);
            }
            else
            {
                kLog.Debug("Release directory selection canceled.");
            }
        }

        private void ApplyChanges(object? sender, EventArgs e)
        {
            kLog.Debug("Applying project settings...");

            if (string.IsNullOrWhiteSpace(WorkingDirectory) || string.IsNullOrWhiteSpace(ReleaseDirectory))
            {
                kLog.Warning("Validation failed: one or both directories are empty.");
                MessageBox.Show(
                    "Both Working and Release directories are required.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                DialogResult = DialogResult.None;
                return;
            }

            Project!.WorkingDirectory = WorkingDirectory;
            Project.ReleaseDirectory = ReleaseDirectory;

            kLog.Information("Project updated: WorkingDirectory={Working}, ReleaseDirectory={Release}",
                Project.WorkingDirectory, Project.ReleaseDirectory);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
