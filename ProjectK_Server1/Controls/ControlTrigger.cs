using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectK_Server1
{
    public partial class ControlTrigger : UserControl
    {
        bool currentState;
        String text1, text2;
        Color color1, color2, backcolor1, backcolor2;

        public delegate void TriggerHandler();
        public event TriggerHandler onTriggered;

        [Description("Текст состояния 1"), Category("Data")]
        public String _Text1
        {
            get { return text1; }
            set { text1 = value; RefreshTrigger(); }
        }
        [Description("Текст состояния 2"), Category("Data")]
        public String _Text2
        {
            get { return text2; }
            set { text2 = value; RefreshTrigger(); }
        }
        [Description("Цвет кнопки состояния 1"), Category("Data")]
        public Color _Color1
        {
            get { return color1; }
            set { color1 = value; RefreshTrigger(); }
        }
        [Description("Цвет кнопки состояния 2"), Category("Data")]
        public Color _Color2
        {
            get { return color2; }
            set { color2 = value; RefreshTrigger(); }
        }
        [Description("Цвет фона состояния 1"), Category("Data")]
        public Color _BackColor1
        {
            get { return backcolor1; }
            set { backcolor1 = value; RefreshTrigger(); }
        }

        private void BtnText_Click(object sender, EventArgs e)
        {
            _CurrentState = !_CurrentState;
        }

        [Description("Цвет фона состояния 2"), Category("Data")]
        public Color _BackColor2
        {
            get { return backcolor2; }
            set { backcolor2 = value; RefreshTrigger(); }
        }
        [Description("Текущее состояние"), Category("Data")]
        public bool _CurrentState
        {
            get { return currentState; }
            set { currentState = value; RefreshTrigger(); }
        }

        public void RefreshTrigger()
        {
            if (currentState)
            {
                btnText.Text = text1;
                btnText.BackColor = color1;
                btnText.Dock = DockStyle.Left;
                pnlMain.BackColor = backcolor1;
                pbArrow.Image = Properties.Resources.right;
            }
            else
            {
                btnText.Text = text2;
                btnText.BackColor = color2;
                btnText.Dock = DockStyle.Right;
                pnlMain.BackColor = backcolor2;
                pbArrow.Image = Properties.Resources.left;
            }
            if (onTriggered != null)
                onTriggered();
        }

        public ControlTrigger()
        {
            InitializeComponent();
            currentState = true;
            text1 = "Состояние 1";
            text2 = "Состояние 2";
            color1 = Color.LightGray;
            backcolor1 = Color.White;
            color2 = Color.LightGray;
            backcolor2 = Color.White;
            RefreshTrigger();
        }
    }
}
