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
            ToolStripDropDownButton toolStripDropDownButton1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            newProjectToolStripMenuItem = new ToolStripMenuItem();
            loadProjectToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            saveProjectToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { newProjectToolStripMenuItem, loadProjectToolStripMenuItem, toolStripSeparator1, saveProjectToolStripMenuItem, toolStripSeparator2, ExitToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(38, 22);
            toolStripDropDownButton1.Text = "File";
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(484, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // MainForm
            // 
            AccessibleName = "KefTools";
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(484, 461);
            Controls.Add(toolStrip1);
            MinimumSize = new Size(0, 500);
            Name = "MainForm";
            Text = "KefTools";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
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
    }
}
