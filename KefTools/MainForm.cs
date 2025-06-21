using KefTools.Dialogs;
using KefTools.Formats;
using KefUtils.IO;
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
                    projectStripDropDownButton.Enabled = true;
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
                    projectStripDropDownButton.Enabled = true;
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

        private async void importblkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
            {
                Log.Warning("No project loaded. Cannot import BLK files.");
                MessageBox.Show("Please load or create a project first.", "Import Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var dialog = new OpenFileDialog
            {
                Title = "Import BLK File(s)",
                Filter = "BLK Files (*.blk)|*.blk",
                Multiselect = true,
                InitialDirectory = currentProject.WorkingDirectory
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                Log.Debug("Import BLK dialog canceled.");
                return;
            }

            string[] selectedFiles = dialog.FileNames;
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = 100;

            IProgress<int> uiProgress = new Progress<int>(value =>
            {
                toolStripProgressBar1.Value = Math.Min(toolStripProgressBar1.Maximum, value);
            });


            await Task.Run(() =>
            {
                for (int i = 0; i < selectedFiles.Length; i++)
                {
                    string blkPath = selectedFiles[i];

                    try
                    {
                        if (!File.Exists(blkPath))
                        {
                            Log.Warning("BLK file not found: {Path}", blkPath);
                            continue;
                        }

                        string blkName = Path.GetFileNameWithoutExtension(blkPath);
                        string outputDir = Path.Combine(currentProject.WorkingDirectory, blkName);

                        Log.Information("Extracting {BlkFile} to {OutputDir}", blkPath, outputDir);

                        // per-BLK progress, mapped to global progress range
                        IProgress<int> perBlkProgress = new Progress<int>(percent =>
                        {
                            double globalProgress = ((i + percent / 100.0) / selectedFiles.Length) * 100.0;
                            uiProgress.Report((int)globalProgress);
                        });

                        BlkArchiveReader.ReadAll(
                            inputDir: Path.GetDirectoryName(blkPath)!,
                            outputDir: outputDir,
                            listingOnly: false,
                            progress: perBlkProgress
                        );
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Failed to extract {BlkFile}", blkPath);
                    }
                }
            });

            toolStripProgressBar1.Visible = false;
            Log.Information("All selected BLK files processed.");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentProject == null)
            {
                Log.Warning("Settings dialog requested but no project is currently loaded.");
                MessageBox.Show("No project is currently loaded.", "Settings Unavailable",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var dialog = new ProjectSettingsDialog(currentProject)
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Log.Information("Project settings updated: WorkingDirectory={Working}, ReleaseDirectory={Release}",
                    currentProject.WorkingDirectory, currentProject.ReleaseDirectory);

                try
                {
                    string savePath = Path.Combine(currentProject.WorkingDirectory, "project.kproj");
                    currentProject.Serialize(savePath);
                    Log.Information("Updated project saved to {Path}", savePath);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Failed to save updated project file.");
                    MessageBox.Show("Failed to save the updated project file. Check logs for details.",
                        "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Log.Debug("Project settings dialog canceled.");
            }
        }
    }
}
