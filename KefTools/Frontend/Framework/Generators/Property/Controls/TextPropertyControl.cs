using System.ComponentModel;
using System.Reflection.Emit;
using System.Windows.Forms;
using KefTools.Frontend.Framework.Generators.Property;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KefTools.UI.Settings.Controls
{
    [DesignerCategory("UserControl")]
    public partial class TextPropertyControl : UserControl, IPropertyControl
    {
        public TextPropertyControl()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("The label displayed next to the textbox.")]
        public string Label
        {
            get => label.Text;
            set => label.Text = value;
        }

        [Browsable(true)]
        [Category("Data")]
        [Description("The value of the setting.")]
        public string Value
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }
    }
}
