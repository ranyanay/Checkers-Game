using Ex05.Logic;
using System;
using System.Windows.Forms;

namespace Ex05.CheckersGUI
{
    public partial class SetupForm : Form
    {
        private int m_BoardSize = 6;
        private string m_Player1Name;
        private string m_Player2Name = "[Computer]";

        public int BoardSize
        {
            get { return m_BoardSize; }
        }

        public string Player1Name
        {
            get { return m_Player1Name; }
        }

        public string Player2Name
        {
            get { return m_Player2Name; }
        }

        public SetupForm()
        {
            InitializeComponent();
        }

        private void ButtonDone_Click(object sender, EventArgs e)
        {
            m_Player1Name = TextBoxPlayer1.Text;
            m_Player2Name = TextBoxPlayer2.Text;
            if (m_Player1Name.Equals("") || m_Player2Name.Equals(""))
            {
                MessagesForUser.JumpErrorMsg(MessagesForUser.s_FormFiledsAreEmpty);
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void CheckBoxPlayer2_CheckStateChanged(object sender, EventArgs e)
        {
            if (TextBoxPlayer2.Enabled)
            {
                TextBoxPlayer2.Text = "[Computer]";
                TextBoxPlayer2.Enabled = false;
            }
            else
            {
                TextBoxPlayer2.Enabled = true;
                TextBoxPlayer2.Text = null;
                TextBoxPlayer2.Focus();
            }
        }

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            string radioButtonName = ((RadioButton)sender).Text;

            switch (radioButtonName)
            {
                case "6 x 6":
                    m_BoardSize = 6;
                    break;
                case "8 x 8":
                    m_BoardSize = 8;
                    break;
                case "10 x 10":
                    m_BoardSize = 10;
                    break;
            }
        }
    }
}