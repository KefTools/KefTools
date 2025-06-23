namespace KefTools.UI.Settings.Controls
{
    partial class FolderBrowserPropertyControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label label;
        private TextBox textBox;
        private Button button;
        private TableLayoutPanel layout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            label = new Label();
            textBox = new TextBox();
            button = new Button();
            layout = new TableLayoutPanel();
            layout.SuspendLayout();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Dock = DockStyle.Fill;
            label.Location = new Point(3, 0);
            label.Name = "label";
            label.Size = new Size(35, 30);
            label.TabIndex = 0;
            label.Text = "Label";
            label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox
            // 
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBox.Location = new Point(44, 3);
            textBox.Name = "textBox";
            textBox.Size = new Size(250, 23);
            textBox.TabIndex = 1;
            // 
            // button
            // 
            button.Anchor = AnchorStyles.Right;
            button.AutoSize = true;
            button.Location = new Point(305, 3);
            button.Name = "button";
            button.Size = new Size(92, 24);
            button.TabIndex = 2;
            button.Text = "Browse...";
            // 
            // layout
            // 
            layout.AutoSize = true;
            layout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layout.ColumnCount = 3;
            layout.ColumnStyles.Add(new ColumnStyle());
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.ColumnStyles.Add(new ColumnStyle());
            layout.Controls.Add(label, 0, 0);
            layout.Controls.Add(textBox, 1, 0);
            layout.Controls.Add(button, 2, 0);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 0);
            layout.MinimumSize = new Size(400, 30);
            layout.Name = "layout";
            layout.RowCount = 1;
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layout.Size = new Size(400, 30);
            layout.TabIndex = 0;
            // 
            // FolderBrowserPropertyControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(layout);
            Name = "FolderBrowserPropertyControl";
            Size = new Size(400, 30);
            layout.ResumeLayout(false);
            layout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
