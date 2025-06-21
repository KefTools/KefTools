namespace KefTools.Dialogs;

partial class NewProjectDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label labelWorkingDir;
    private System.Windows.Forms.TextBox textWorkingDir;
    private System.Windows.Forms.Button buttonBrowseWorking;
    private System.Windows.Forms.Label labelReleaseDir;
    private System.Windows.Forms.TextBox textReleaseDir;
    private System.Windows.Forms.Button buttonBrowseRelease;
    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
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
        // 
        // labelWorkingDir
        // 
        labelWorkingDir.AutoSize = true;
        labelWorkingDir.Location = new Point(12, 15);
        labelWorkingDir.Name = "labelWorkingDir";
        labelWorkingDir.Size = new Size(106, 15);
        labelWorkingDir.TabIndex = 0;
        labelWorkingDir.Text = "Working Directory:";
        // 
        // textWorkingDir
        // 
        textWorkingDir.Location = new Point(130, 12);
        textWorkingDir.Name = "textWorkingDir";
        textWorkingDir.Size = new Size(400, 23);
        textWorkingDir.TabIndex = 1;
        // 
        // buttonBrowseWorking
        // 
        buttonBrowseWorking.Location = new Point(540, 11);
        buttonBrowseWorking.Name = "buttonBrowseWorking";
        buttonBrowseWorking.Size = new Size(75, 23);
        buttonBrowseWorking.TabIndex = 2;
        buttonBrowseWorking.Text = "Browse...";
        buttonBrowseWorking.UseVisualStyleBackColor = true;
        buttonBrowseWorking.Click += BrowseWorkingDir;
        // 
        // labelReleaseDir
        // 
        labelReleaseDir.AutoSize = true;
        labelReleaseDir.Location = new Point(12, 50);
        labelReleaseDir.Name = "labelReleaseDir";
        labelReleaseDir.Size = new Size(100, 15);
        labelReleaseDir.TabIndex = 3;
        labelReleaseDir.Text = "Release Directory:";
        // 
        // textReleaseDir
        // 
        textReleaseDir.Location = new Point(130, 47);
        textReleaseDir.Name = "textReleaseDir";
        textReleaseDir.Size = new Size(400, 23);
        textReleaseDir.TabIndex = 4;
        // 
        // buttonBrowseRelease
        // 
        buttonBrowseRelease.Location = new Point(540, 46);
        buttonBrowseRelease.Name = "buttonBrowseRelease";
        buttonBrowseRelease.Size = new Size(75, 23);
        buttonBrowseRelease.TabIndex = 5;
        buttonBrowseRelease.Text = "Browse...";
        buttonBrowseRelease.UseVisualStyleBackColor = true;
        buttonBrowseRelease.Click += BrowseReleaseDir;
        // 
        // buttonOK
        // 
        buttonOK.Location = new Point(459, 90);
        buttonOK.Name = "buttonOK";
        buttonOK.Size = new Size(75, 27);
        buttonOK.TabIndex = 6;
        buttonOK.Text = "OK\r\n";
        buttonOK.UseVisualStyleBackColor = true;
        buttonOK.Click += ConfirmProject;
        // 
        // buttonCancel
        // 
        buttonCancel.DialogResult = DialogResult.Cancel;
        buttonCancel.Location = new Point(540, 90);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(75, 27);
        buttonCancel.TabIndex = 7;
        buttonCancel.Text = "Cancel";
        buttonCancel.UseVisualStyleBackColor = true;
        // 
        // NewProjectDialog
        // 
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
        Name = "NewProjectDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Create New KEF Project";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}