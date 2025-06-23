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
            ListViewGroup listViewGroup1 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "test", "tes", "test", "ttest" }, -1);
            ListViewItem listViewItem2 = new ListViewItem("");
            ListViewItem listViewItem3 = new ListViewItem("");
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
            tabControl2 = new TabControl();
            tabPage3 = new TabPage();
            listView1 = new ListView();
            tabControl3 = new TabControl();
            tabPage4 = new TabPage();
            treeView1 = new TreeView();
            tabControl4 = new TabControl();
            tabPage2 = new TabPage();
            tabPage5 = new TabPage();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            treeView2 = new TreeView();
            fileStripDropDownButton = new ToolStripDropDownButton();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabControl3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabControl4.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
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
            toolStrip1.Size = new Size(1264, 25);
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
            importblkToolStripMenuItem.Size = new Size(145, 22);
            importblkToolStripMenuItem.Text = "Import (*.blk)";
            importblkToolStripMenuItem.Click += importblkToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(142, 6);
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(145, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 659);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1264, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Dock = DockStyle.Bottom;
            tabControl2.Location = new Point(0, 521);
            tabControl2.Multiline = true;
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(1264, 138);
            tabControl2.TabIndex = 5;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(listView1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1256, 110);
            tabPage3.TabIndex = 1;
            tabPage3.Text = "Assets";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.BackColor = SystemColors.Control;
            listView1.BorderStyle = BorderStyle.None;
            listViewGroup1.FooterAlignment = HorizontalAlignment.Right;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            listView1.Groups.AddRange(new ListViewGroup[] { listViewGroup1 });
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3 });
            listView1.Location = new Point(3, -17);
            listView1.Name = "listView1";
            listView1.ShowGroups = false;
            listView1.Size = new Size(1249, 124);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tabControl3
            // 
            tabControl3.Controls.Add(tabPage4);
            tabControl3.Dock = DockStyle.Left;
            tabControl3.Location = new Point(0, 25);
            tabControl3.Name = "tabControl3";
            tabControl3.SelectedIndex = 0;
            tabControl3.Size = new Size(200, 496);
            tabControl3.TabIndex = 6;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = SystemColors.Control;
            tabPage4.Controls.Add(treeView1);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(192, 468);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "BLK Viewer";
            // 
            // treeView1
            // 
            treeView1.BackColor = SystemColors.Control;
            treeView1.BorderStyle = BorderStyle.None;
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(3, 3);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(186, 462);
            treeView1.TabIndex = 0;
            // 
            // tabControl4
            // 
            tabControl4.Controls.Add(tabPage2);
            tabControl4.Controls.Add(tabPage5);
            tabControl4.Dock = DockStyle.Fill;
            tabControl4.Location = new Point(200, 25);
            tabControl4.Name = "tabControl4";
            tabControl4.SelectedIndex = 0;
            tabControl4.Size = new Size(1064, 496);
            tabControl4.TabIndex = 7;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1056, 468);
            tabPage2.TabIndex = 0;
            tabPage2.Text = "Text Editor";
            // 
            // tabPage5
            // 
            tabPage5.BackColor = SystemColors.Control;
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(856, 468);
            tabPage5.TabIndex = 1;
            tabPage5.Text = "3D Viewer";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Right;
            tabControl1.Location = new Point(1064, 25);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(200, 496);
            tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(treeView2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(192, 468);
            tabPage1.TabIndex = 1;
            tabPage1.Text = "BLK Viewer";
            // 
            // treeView2
            // 
            treeView2.BackColor = SystemColors.Control;
            treeView2.BorderStyle = BorderStyle.None;
            treeView2.Dock = DockStyle.Fill;
            treeView2.Location = new Point(3, 3);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(186, 462);
            treeView2.TabIndex = 0;
            // 
            // MainForm
            // 
            AccessibleName = "KefTools";
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1264, 681);
            Controls.Add(tabControl4);
            Controls.Add(tabControl1);
            Controls.Add(tabControl3);
            Controls.Add(tabControl2);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            MinimumSize = new Size(1280, 720);
            Name = "MainForm";
            Text = "KefTools";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabControl3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabControl4.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
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
        private TabControl tabControl2;
        private TabPage tabPage3;
        private ListView listView1;
        private TabControl tabControl3;
        private TabPage tabPage4;
        private TreeView treeView1;
        private TabControl tabControl4;
        private TabPage tabPage2;
        private TabPage tabPage5;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TreeView treeView2;
    }
}
