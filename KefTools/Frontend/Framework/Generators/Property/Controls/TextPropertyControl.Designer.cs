namespace KefTools.UI.Settings.Controls
{
    partial class TextPropertyControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label label;
        private TextBox textBox;
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
            layout = new TableLayoutPanel();
            layout.SuspendLayout();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(3, 0);
            label.Name = "label";
            label.Size = new Size(35, 15);
            label.TabIndex = 0;
            label.Text = "Label";
            // 
            // textBox
            // 
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox.Location = new Point(44, 3);
            textBox.Name = "textBox";
            textBox.Size = new Size(300, 23);
            textBox.TabIndex = 1;
            // 
            // layout
            // 
            layout.AutoSize = true;
            layout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle());
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.Controls.Add(label, 0, 0);
            layout.Controls.Add(textBox, 1, 0);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 0);
            layout.Name = "layout";
            layout.RowCount = 1;
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layout.Size = new Size(347, 20);
            layout.TabIndex = 0;
            // 
            // TextSettingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(layout);
            Name = "TextSettingControl";
            Size = new Size(347, 20);
            layout.ResumeLayout(false);
            layout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
