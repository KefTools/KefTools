namespace KefTools
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ToolStripDropDownButton fileStripDropDownButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            newProjectToolStripMenuItem = new ToolStripMenuItem();
            loadProjectToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            saveProjectToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            projectStripDropDownButton = new ToolStripDropDownButton();
            importblkToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            fileStripDropDownButton = new ToolStripDropDownButton();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // fileStripDropDownButton
            // 
            fileStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            fileStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { newProjectToolStripMenuItem, loadProjectToolStripMenuItem, toolStripSeparator1, saveProjectToolStripMenuItem, toolStripSeparator2, ExitToolStripMenuItem });
            fileStripDropDownButton.Image = (Image)resources.GetObject("fileStripDropDownButton.Image");
            fileStripDropDownButton.ImageTransparentColor = Color.Magenta;
            fileStripDropDownButton.Name = "fileStripDropDownButton";
            fileStripDropDownButton.ShowDropDownArrow = false;
            fileStripDropDownButton.Size = new Size(29, 22);
            fileStripDropDownButton.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            newProjectToolStripMenuItem.Image = Properties.Resources.AddFolder;
            newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            newProjectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newProjectToolStripMenuItem.Size = new Size(181, 22);
            newProjectToolStripMenuItem.Text = "New Project";
            newProjectToolStripMenuItem.Click += newProjectToolStripMenuItem_Click;
            // 
            // loadProjectToolStripMenuItem
            // 
            loadProjectToolStripMenuItem.Image = Properties.Resources.FolderOpened;
            loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            loadProjectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            loadProjectToolStripMenuItem.Size = new Size(181, 22);
            loadProjectToolStripMenuItem.Text = "Load Project";
            loadProjectToolStripMenuItem.Click += loadProjectToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(178, 6);
            // 
            // saveProjectToolStripMenuItem
            // 
            saveProjectToolStripMenuItem.Enabled = false;
            saveProjectToolStripMenuItem.Image = Properties.Resources.Save;
            saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            saveProjectToolStripMenuItem.ShortcutKeyDisplayString = "";
            saveProjectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveProjectToolStripMenuItem.Size = new Size(181, 22);
            saveProjectToolStripMenuItem.Text = "Save Project";
            saveProjectToolStripMenuItem.Click += saveProjectToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(178, 6);
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(181, 22);
            ExitToolStripMenuItem.Text = "Exit";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { fileStripDropDownButton, projectStripDropDownButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(484, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // projectStripDropDownButton
            // 
            projectStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            projectStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { importblkToolStripMenuItem, toolStripSeparator3, settingsToolStripMenuItem });
            projectStripDropDownButton.Enabled = false;
            projectStripDropDownButton.Image = (Image)resources.GetObject("projectStripDropDownButton.Image");
            projectStripDropDownButton.ImageTransparentColor = Color.Magenta;
            projectStripDropDownButton.Name = "projectStripDropDownButton";
            projectStripDropDownButton.ShowDropDownArrow = false;
            projectStripDropDownButton.Size = new Size(48, 22);
            projectStripDropDownButton.Text = "Project";
            // 
            // importblkToolStripMenuItem
            // 
            importblkToolStripMenuItem.Name = "importblkToolStripMenuItem";
            importblkToolStripMenuItem.Size = new Size(180, 22);
            importblkToolStripMenuItem.Text = "Import (*.blk)";
            importblkToolStripMenuItem.Click += importblkToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(177, 6);
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(180, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 439);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(484, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // MainForm
            // 
            AccessibleName = "KefTools";
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(484, 461);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            MinimumSize = new Size(0, 500);
            Name = "MainForm";
            Text = "KefTools";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripMenuItem newProjectToolStripMenuItem;
        private ToolStripMenuItem loadProjectToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem saveProjectToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripDropDownButton projectStripDropDownButton;
        private ToolStripMenuItem importblkToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
    }
}
