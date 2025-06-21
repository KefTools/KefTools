using KefTools.Dialogs;
using KefTools.Formats;
using Serilog;

namespace KefTools
{
    public partial class MainForm : Form
    {
        private Project? currentProject;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new NewProjectDialog
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                currentProject = dialog.Project;

                if (currentProject == null)
                {
                    Log.Error("NewProjectDialog returned null project.");
                    return;
                }

                Log.Information("New project created: WorkingDirectory={Working}, ReleaseDirectory={Release}",
                    currentProject.WorkingDirectory, currentProject.ReleaseDirectory);

                try
                {
                    string savePath = Path.Combine(currentProject.WorkingDirectory, "project.kproj");
                    currentProject.Serialize(savePath);
                    Log.Information("Project saved to {Path}", savePath);
                    saveProjectToolStripMenuItem.Enabled = true;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Failed to save new project file.");
                    MessageBox.Show("Failed to save the project file. Check logs for details.", "Save Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Log.Debug("New Project dialog canceled.");
            }
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Load KEF Project",
                Filter = "Kef Project Files (*.kproj)|*.kproj",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                Log.Information("Attempting to load project from: {Path}", path);

                var project = Project.Deserialize(path);

                if (project != null)
                {
                    currentProject = project;

                    Log.Information("Project loaded: WorkingDirectory={Working}, ReleaseDirectory={Release}",
                        currentProject.WorkingDirectory, currentProject.ReleaseDirectory);

                    saveProjectToolStripMenuItem.Enabled = true;
                }
                else
                {
                    Log.Warning("Failed to load project from selected file.");
                    MessageBox.Show("Failed to load the project. Check logs for more information.", "Load Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Log.Debug("Load Project dialog canceled.");
            }
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Implement save logic when project editing is supported
        }
    }
}
