using System.ComponentModel;
using System.Reflection.Emit;
using System.Windows.Forms;
using KefTools.Frontend.Framework.Generators.Property;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KefTools.UI.Settings.Controls
{
    [DesignerCategory("UserControl")]
    public partial class FolderBrowserPropertyControl : UserControl, IPropertyControl
    {
        public FolderBrowserPropertyControl()
        {
            InitializeComponent();

            button.Click += (_, _) =>
            {
                using var dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                    textBox.Text = dialog.SelectedPath;
            };
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("The label displayed next to the folder path.")]
        public string Label
        {
            get => label.Text;
            set => label.Text = value;
        }

        [Browsable(true)]
        [Category("Data")]
        [Description("The selected folder path.")]
        public string Value
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }
    }
}
