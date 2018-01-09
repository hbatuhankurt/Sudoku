using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuAppV0._1
{
    public partial class HowCanPlay : Form
    {
        public HowCanPlay()
        {
            InitializeComponent();
        }
        
        private void HowCanPlay_Load(object sender, EventArgs e)
        {
            string s_FileName = Application.StartupPath + "\\Instructions.rtf";
            richTextBox1.LoadFile(s_FileName);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Login OpenLogin = new Login();
            OpenLogin.Show();
            this.Close();
        }
    }
}
