namespace KefTools.Dialogs;

partial class NewProjectDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
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
        folderBrowserDialog = new FolderBrowserDialog();
        SuspendLayout();
        // 
        // NewProjectDialog
        // 
        ClientSize = new Size(634, 131);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "NewProjectDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Create New KEF Project";
        ResumeLayout(false);
    }

    #endregion
}