using SudokuAppV0._1.Interfaces;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle; //Form boyutunu kilitleme. 
        }

        //New Game Butonu\\
        private void buttonNewGame_Click(object sender, EventArgs e) 
        {
            GameInterface OpenGameInterface = new GameInterface();
            OpenGameInterface.Show();
            this.Hide();
        }

        //How Can Play Butonu\\
        private void buttonHowCanPlay_Click(object sender, EventArgs e)
        {
            HowCanPlay OpenHowCanPlay = new HowCanPlay();
            OpenHowCanPlay.Show();
            this.Hide();
        }

        //Exit Butonu\\
        private void buttonExit_Click(object sender, EventArgs e) 
        {
            DialogResult exit;
            exit = MessageBox.Show("Are You Sure You Want To Quit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (exit == DialogResult.No)
            {
                MessageBox.Show("Okay, Let's Go Back To The Game");
            }
            if (exit == DialogResult.Yes)
            {
                MessageBox.Show("Thanks For Played, See You Soon ;)");
                this.Close();
                Application.Exit();
            }
        }

/// <summary>
/// Kaydedilen Oyunu Geri Yükleme
/// </summary>
/// <param name="tempSet"></param>
/// <returns></returns>
        private bool InitialiseGame(DataSet tempSet)
        {
            throw new NotImplementedException();
        }

        private void buttonLoadGame_Click(object sender, EventArgs e)
        {
            string fileName = "game.xml";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string file = path + fileName;
            DataSet tempSet = new DataSet();
            try
            {
                tempSet.ReadXml(file);
                bool initSuccess = InitialiseGame(tempSet);
                if (initSuccess)
                {
                    MessageBox.Show("Game Loaded Successfully !");
                }
                else
                {
                    MessageBox.Show("Game Initialisation Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while loading xml file");
            }
        }
    }
}
