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
            ListViewGroup listViewGroup2 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            ListViewItem listViewItem4 = new ListViewItem(new string[] { "test", "tes", "test", "ttest" }, -1);
            ListViewItem listViewItem5 = new ListViewItem("");
            ListViewItem listViewItem6 = new ListViewItem("");
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
            AssetsTab = new TabControl();
            tabPage3 = new TabPage();
            AssetsTabContent = new ListView();
            BLKViewerTab = new TabControl();
            tabPage4 = new TabPage();
            BLKViewerTabContent = new TreeView();
            MainViewTab = new TabControl();
            MainViewTextEditor = new TabPage();
            MainViewTab3DViewer = new TabPage();
            InspectorTab = new TabControl();
            InspectorTabContent = new TabPage();
            fileStripDropDownButton = new ToolStripDropDownButton();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            AssetsTab.SuspendLayout();
            tabPage3.SuspendLayout();
            BLKViewerTab.SuspendLayout();
            tabPage4.SuspendLayout();
            MainViewTab.SuspendLayout();
            InspectorTab.SuspendLayout();
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
            toolStrip1.BackColor = SystemColors.Control;
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
            // AssetsTab
            // 
            AssetsTab.Controls.Add(tabPage3);
            AssetsTab.Dock = DockStyle.Bottom;
            AssetsTab.Location = new Point(0, 521);
            AssetsTab.Multiline = true;
            AssetsTab.Name = "AssetsTab";
            AssetsTab.SelectedIndex = 0;
            AssetsTab.Size = new Size(1264, 138);
            AssetsTab.TabIndex = 5;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(AssetsTabContent);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1256, 110);
            tabPage3.TabIndex = 1;
            tabPage3.Text = "Assets";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // AssetsTabContent
            // 
            AssetsTabContent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AssetsTabContent.BackColor = SystemColors.Control;
            AssetsTabContent.BorderStyle = BorderStyle.None;
            listViewGroup2.FooterAlignment = HorizontalAlignment.Right;
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup1";
            AssetsTabContent.Groups.AddRange(new ListViewGroup[] { listViewGroup2 });
            AssetsTabContent.Items.AddRange(new ListViewItem[] { listViewItem4, listViewItem5, listViewItem6 });
            AssetsTabContent.Location = new Point(3, -17);
            AssetsTabContent.Name = "AssetsTabContent";
            AssetsTabContent.ShowGroups = false;
            AssetsTabContent.Size = new Size(1249, 124);
            AssetsTabContent.TabIndex = 0;
            AssetsTabContent.UseCompatibleStateImageBehavior = false;
            // 
            // BLKViewerTab
            // 
            BLKViewerTab.Controls.Add(tabPage4);
            BLKViewerTab.Dock = DockStyle.Left;
            BLKViewerTab.Location = new Point(0, 25);
            BLKViewerTab.Name = "BLKViewerTab";
            BLKViewerTab.SelectedIndex = 0;
            BLKViewerTab.Size = new Size(200, 496);
            BLKViewerTab.TabIndex = 6;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = SystemColors.Control;
            tabPage4.Controls.Add(BLKViewerTabContent);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(192, 468);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "BLK Viewer";
            // 
            // BLKViewerTabContent
            // 
            BLKViewerTabContent.BackColor = SystemColors.Control;
            BLKViewerTabContent.BorderStyle = BorderStyle.None;
            BLKViewerTabContent.Dock = DockStyle.Fill;
            BLKViewerTabContent.Location = new Point(3, 3);
            BLKViewerTabContent.Name = "BLKViewerTabContent";
            BLKViewerTabContent.Size = new Size(186, 462);
            BLKViewerTabContent.TabIndex = 0;
            // 
            // MainViewTab
            // 
            MainViewTab.Controls.Add(MainViewTextEditor);
            MainViewTab.Controls.Add(MainViewTab3DViewer);
            MainViewTab.Dock = DockStyle.Fill;
            MainViewTab.Location = new Point(200, 25);
            MainViewTab.Name = "MainViewTab";
            MainViewTab.SelectedIndex = 0;
            MainViewTab.Size = new Size(864, 496);
            MainViewTab.TabIndex = 7;
            // 
            // MainViewTextEditor
            // 
            MainViewTextEditor.BackColor = SystemColors.Control;
            MainViewTextEditor.Location = new Point(4, 24);
            MainViewTextEditor.Name = "MainViewTextEditor";
            MainViewTextEditor.Padding = new Padding(3);
            MainViewTextEditor.Size = new Size(856, 468);
            MainViewTextEditor.TabIndex = 0;
            MainViewTextEditor.Text = "Text Editor";
            // 
            // MainViewTab3DViewer
            // 
            MainViewTab3DViewer.BackColor = SystemColors.Control;
            MainViewTab3DViewer.Location = new Point(4, 24);
            MainViewTab3DViewer.Name = "MainViewTab3DViewer";
            MainViewTab3DViewer.Padding = new Padding(3);
            MainViewTab3DViewer.Size = new Size(856, 468);
            MainViewTab3DViewer.TabIndex = 1;
            MainViewTab3DViewer.Text = "3D Viewer";
            // 
            // InspectorTab
            // 
            InspectorTab.Controls.Add(InspectorTabContent);
            InspectorTab.Dock = DockStyle.Right;
            InspectorTab.Location = new Point(1064, 25);
            InspectorTab.Name = "InspectorTab";
            InspectorTab.SelectedIndex = 0;
            InspectorTab.Size = new Size(200, 496);
            InspectorTab.TabIndex = 8;
            // 
            // InspectorTabContent
            // 
            InspectorTabContent.BackColor = SystemColors.Control;
            InspectorTabContent.Location = new Point(4, 24);
            InspectorTabContent.Name = "InspectorTabContent";
            InspectorTabContent.Size = new Size(192, 468);
            InspectorTabContent.TabIndex = 2;
            InspectorTabContent.Text = "Inspector";
            // 
            // MainForm
            // 
            AccessibleName = "KefTools";
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1264, 681);
            Controls.Add(MainViewTab);
            Controls.Add(InspectorTab);
            Controls.Add(BLKViewerTab);
            Controls.Add(AssetsTab);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            MinimumSize = new Size(1280, 720);
            Name = "MainForm";
            Text = "KefTools";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            AssetsTab.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            BLKViewerTab.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            MainViewTab.ResumeLayout(false);
            InspectorTab.ResumeLayout(false);
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
        private TabControl AssetsTab;
        private TabPage tabPage3;
        private ListView AssetsTabContent;
        private TabControl BLKViewerTab;
        private TabPage tabPage4;
        private TreeView BLKViewerTabContent;
        private TabControl MainViewTab;
        private TabPage MainViewTextEditor;
        private TabPage MainViewTab3DViewer;
        private TabControl InspectorTab;
        private TabPage InspectorTabContent;
    }
}
