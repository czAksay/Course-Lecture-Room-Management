using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectK
{
    public partial class MessageDisplay : UserControl
    {
        [Description("Текст в окне элемента управления"), Category("Data")]
        public string _Text
        {
            get { return labelText.Text; }
            set { labelText.Text = value; }
        }

        [Description("Шрифт текста элемента управления"), Category("Data")]
        public Font _Font
        {
            get { return labelText.Font; }
            set { labelText.Font = value; }
        }

        [Description("Цвет текста элемента управления"), Category("Data")]
        public Color _Color
        {
            get { return labelText.ForeColor; }
            set { labelText.ForeColor = value; }
        }

        [Description("Цвет фона элемента управления"), Category("Data")]
        public Color _BackColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        [Description("Положение текста элемента управления"), Category("Data")]
        public ContentAlignment _TextAlign
        {
            get { return labelText.TextAlign; }
            set { labelText.TextAlign = value; }
        }

        public MessageDisplay()
        {
            InitializeComponent();
        }

        public void SetText(String text)
        {
            if (text != null)
                labelText.Text = text;
            else
                labelText.Text = "";
        }

        public void Clear()
        {
            labelText.Text = "";
        }
    }
}
