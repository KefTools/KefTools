using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KefTools.Dialogs
{
    partial class ProjectSettingsDialog
    {
        private IContainer components = null;

        private Label labelWorkingDir;
        private TextBox textWorkingDir;
        private Button buttonBrowseWorking;
        private Label labelReleaseDir;
        private TextBox textReleaseDir;
        private Button buttonBrowseRelease;
        private Button buttonOK;
        private Button buttonCancel;
        private FolderBrowserDialog folderBrowserDialog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new Container();
            labelWorkingDir = new Label();
            textWorkingDir = new TextBox();
            buttonBrowseWorking = new Button();
            labelReleaseDir = new Label();
            textReleaseDir = new TextBox();
            buttonBrowseRelease = new Button();
            buttonOK = new Button();
            buttonCancel = new Button();
            folderBrowserDialog = new FolderBrowserDialog();
            SuspendLayout();

            // labelWorkingDir
            labelWorkingDir.AutoSize = true;
            labelWorkingDir.Location = new Point(12, 15);
            labelWorkingDir.Name = "labelWorkingDir";
            labelWorkingDir.Size = new Size(106, 15);
            labelWorkingDir.Text = "Working Directory:";

            // textWorkingDir
            textWorkingDir.Location = new Point(130, 12);
            textWorkingDir.Name = "textWorkingDir";
            textWorkingDir.Size = new Size(400, 23);

            // buttonBrowseWorking
            buttonBrowseWorking.Location = new Point(540, 11);
            buttonBrowseWorking.Name = "buttonBrowseWorking";
            buttonBrowseWorking.Size = new Size(75, 23);
            buttonBrowseWorking.Text = "Browse...";
            buttonBrowseWorking.UseVisualStyleBackColor = true;
            buttonBrowseWorking.Click += BrowseWorkingDir;

            // labelReleaseDir
            labelReleaseDir.AutoSize = true;
            labelReleaseDir.Location = new Point(12, 50);
            labelReleaseDir.Name = "labelReleaseDir";
            labelReleaseDir.Size = new Size(100, 15);
            labelReleaseDir.Text = "Release Directory:";

            // textReleaseDir
            textReleaseDir.Location = new Point(130, 47);
            textReleaseDir.Name = "textReleaseDir";
            textReleaseDir.Size = new Size(400, 23);

            // buttonBrowseRelease
            buttonBrowseRelease.Location = new Point(540, 46);
            buttonBrowseRelease.Name = "buttonBrowseRelease";
            buttonBrowseRelease.Size = new Size(75, 23);
            buttonBrowseRelease.Text = "Browse...";
            buttonBrowseRelease.UseVisualStyleBackColor = true;
            buttonBrowseRelease.Click += BrowseReleaseDir;

            // buttonOK
            buttonOK.Location = new Point(459, 90);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 27);
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += ApplyChanges;

            // buttonCancel
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(540, 90);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 27);
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;

            // ProjectSettingsDialog
            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            ClientSize = new Size(634, 131);
            Controls.Add(labelWorkingDir);
            Controls.Add(textWorkingDir);
            Controls.Add(buttonBrowseWorking);
            Controls.Add(labelReleaseDir);
            Controls.Add(textReleaseDir);
            Controls.Add(buttonBrowseRelease);
            Controls.Add(buttonOK);
            Controls.Add(buttonCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProjectSettingsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Project Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
