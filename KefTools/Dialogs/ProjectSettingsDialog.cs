using KefTools.Formats;
using Serilog;

namespace KefTools.Dialogs
{
    public partial class ProjectSettingsDialog : Form
    {
        private static readonly ILogger log = Log.ForContext("Component", "ProjectSettingsDialog");

        public Project? Project { get; private set; }

        public string WorkingDirectory => textWorkingDir.Text.Trim();
        public string ReleaseDirectory => textReleaseDir.Text.Trim();

        public ProjectSettingsDialog(Project existingProject)
        {
            InitializeComponent();
            log.Debug("Settings dialog initialized.");

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
                log.Debug("Updated Working Directory: {Path}", textWorkingDir.Text);
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
                log.Debug("Updated Release Directory: {Path}", textReleaseDir.Text);
            }
            else
            {
                log.Debug("Release directory selection canceled.");
            }
        }

        private void ApplyChanges(object? sender, EventArgs e)
        {
            log.Debug("Applying project settings...");

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

            Project!.WorkingDirectory = WorkingDirectory;
            Project.ReleaseDirectory = ReleaseDirectory;

            log.Information("Project updated: WorkingDirectory={Working}, ReleaseDirectory={Release}",
                Project.WorkingDirectory, Project.ReleaseDirectory);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
