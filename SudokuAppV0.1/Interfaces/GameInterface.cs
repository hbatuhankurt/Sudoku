using SudokuAppV0._1.Classess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Windows.Forms;

namespace SudokuAppV0._1.Interfaces
{
    public partial class GameInterface : Form
    {
        public GameInterface()
        {
            InitializeComponent();
        }

        Dictionary<Coordinate, TextBox> boxes = new Dictionary<Coordinate, TextBox>();

        char[] arr_Char_Value;
        int i_Level = 45;
        Sudoku_Validator validate = new Sudoku_Validator();
        Sudoku_Generator generate = new Sudoku_Generator();
        int i_Sec, i_Min, i_Hour;
        public static string s_Time = string.Empty;

        private void GameInterface_Load(object sender, EventArgs e)
        {
            //Zaman\\
            i_Sec = i_Min = i_Hour = 0;
            timer1.Start();
            labelStatus.Text = "Good Luck";

            #region Horizontal_List
            //Horizontal List            
            validate.txtBox_Array_Horiz_1 = new TextBox[] { textBox1, textBox4, textBox7, textBox18, textBox15, textBox12, textBox27, textBox24, textBox21 };
            validate.txtBox_Array_Horiz_2 = new TextBox[] { textBox2, textBox5, textBox8, textBox17, textBox14, textBox11, textBox26, textBox23, textBox20 };
            validate.txtBox_Array_Horiz_3 = new TextBox[] { textBox3, textBox6, textBox9, textBox16, textBox13, textBox10, textBox25, textBox22, textBox19 };
            validate.txtBox_Array_Horiz_4 = new TextBox[] { textBox36, textBox33, textBox30, textBox45, textBox42, textBox39, textBox54, textBox51, textBox48 };
            validate.txtBox_Array_Horiz_5 = new TextBox[] { textBox35, textBox32, textBox29, textBox44, textBox41, textBox38, textBox53, textBox50, textBox47 };
            validate.txtBox_Array_Horiz_6 = new TextBox[] { textBox34, textBox31, textBox28, textBox43, textBox40, textBox37, textBox52, textBox49, textBox46 };
            validate.txtBox_Array_Horiz_7 = new TextBox[] { textBox63, textBox60, textBox57, textBox72, textBox69, textBox66, textBox81, textBox78, textBox75 };
            validate.txtBox_Array_Horiz_8 = new TextBox[] { textBox62, textBox59, textBox56, textBox71, textBox68, textBox65, textBox80, textBox77, textBox74 };
            validate.txtBox_Array_Horiz_9 = new TextBox[] { textBox61, textBox58, textBox55, textBox70, textBox67, textBox64, textBox79, textBox76, textBox73 };
            #endregion

            #region Vertical_List
            //Vertical List
            validate.txtBox_Array_Vert_1 = new TextBox[] { textBox1, textBox2, textBox3, textBox36, textBox35, textBox34, textBox63, textBox62, textBox61 };
            validate.txtBox_Array_Vert_2 = new TextBox[] { textBox4, textBox5, textBox6, textBox33, textBox32, textBox31, textBox60, textBox59, textBox58 };
            validate.txtBox_Array_Vert_3 = new TextBox[] { textBox7, textBox8, textBox9, textBox30, textBox29, textBox28, textBox57, textBox56, textBox55 };
            validate.txtBox_Array_Vert_4 = new TextBox[] { textBox18, textBox17, textBox16, textBox45, textBox44, textBox43, textBox72, textBox71, textBox70 };
            validate.txtBox_Array_Vert_5 = new TextBox[] { textBox15, textBox14, textBox13, textBox42, textBox41, textBox40, textBox69, textBox68, textBox67 };
            validate.txtBox_Array_Vert_6 = new TextBox[] { textBox12, textBox11, textBox10, textBox39, textBox38, textBox37, textBox66, textBox65, textBox64 };
            validate.txtBox_Array_Vert_7 = new TextBox[] { textBox27, textBox26, textBox25, textBox54, textBox53, textBox52, textBox81, textBox80, textBox79 };
            validate.txtBox_Array_Vert_8 = new TextBox[] { textBox24, textBox23, textBox22, textBox51, textBox50, textBox49, textBox78, textBox77, textBox76 };
            validate.txtBox_Array_Vert_9 = new TextBox[] { textBox21, textBox20, textBox19, textBox48, textBox47, textBox46, textBox75, textBox74, textBox73 };
            #endregion

            validate.txtBox_Array_Add();

            validate.ctrl_Tab_Change();

            grp_Text_Change();

            buttonNewGame_Click(sender, e);
            labelStatus.Text = ("Game Has Started");

        }

        private void grp_Text_Change()
        {
            foreach (GroupBox grpBox in gamePanel.Controls)
            {
                grpBox.Text = "";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) || (char.IsWhiteSpace(e.KeyChar)) || (char.IsPunctuation(e.KeyChar)) || (char.IsSeparator(e.KeyChar)) || (char.IsSurrogate(e.KeyChar)) || (char.IsSymbol(e.KeyChar)) || (e.KeyChar == '0'))
            {
                e.Handled = true;
            }
        }

        private void groupBox_Validate()
        {
            foreach (GroupBox groupBox in gamePanel.Controls)
            {
                foreach (TextBox txtBox in groupBox.Controls)
                {
                    string s_txt_Value = txtBox.Text.ToString();
                    foreach (TextBox txtBox1 in groupBox.Controls)
                    {
                        if (txtBox.Name == txtBox1.Name)
                        {
                            continue;
                        }
                        else if (s_txt_Value == "")
                        {
                            arr_Add(txtBox);
                            continue;
                        }
                        if (s_txt_Value == txtBox1.Text)
                        {
                            arr_Add(txtBox);
                        }
                    }
                }
            }
        }

        private void arr_Add(TextBox txtBox)
        {
            if (validate.arr_control.Contains(txtBox) == false)
            {
                validate.arr_control.Add(txtBox);
            }
        }

        private void txtBox_Paint()
        {
            foreach (GroupBox groupBox in gamePanel.Controls)
            {
                foreach (TextBox txtBox in groupBox.Controls)
                {
                    if (txtBox.BackColor != Color.WhiteSmoke)
                    {
                        txtBox.BackColor = Color.White;
                    }
                }
            }
        }
     
        private void assign_Char_Value(string[] s_Rem_Value)
        {
            arr_Char_Value = (s_Rem_Value[0] + s_Rem_Value[1] + s_Rem_Value[2] + s_Rem_Value[3] + s_Rem_Value[4] + s_Rem_Value[5] + s_Rem_Value[6] + s_Rem_Value[7] + s_Rem_Value[8]).ToCharArray();
            int i_Cnt = 0;
            foreach (TextBox[] arr_txtBox in validate.arr_txtBox_Horiz)
            {
                foreach (TextBox txtBox in arr_txtBox)
                {
                    txtBox.Text = arr_Char_Value[i_Cnt].ToString();
                    i_Cnt++;
                }
            }
            dot_Clear();
        }

        private void dot_Clear()
        {
            foreach (TextBox[] arr_TxtBox in validate.arr_txtBox_Horiz)
            {
                foreach (TextBox txtBox in arr_TxtBox)
                {
                    if (txtBox.Text == ".")
                    {
                        txtBox.Text = "";
                    }
                    else
                    {
                        txtBox.ReadOnly = true;
                        txtBox.BackColor = Color.WhiteSmoke;
                        continue;
                    }
                }
            }
        }

        private void ctrl_Check(bool b_Value)
        {
            foreach (GroupBox groupBox in gamePanel.Controls)
            {
                foreach (TextBox txtBox in groupBox.Controls)
                {
                    txtBox.Enabled = b_Value;
                }
            }
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            buttonPause_Click(sender, e);


            string[] s_Gen_Value = generate.s_No_Generate();

            string[] s_Rem_Value = generate.s_No_Remove(i_Level);

            assign_Char_Value(s_Rem_Value);

            i_Sec = i_Min = i_Hour = 0;

            buttonPlay_Click(sender, e);
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            buttonPlay.Enabled = true;
            timer1.Stop();
            labelStatus.Text = ("Game Paused");
            ctrl_Check(false);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            buttonPlay.Enabled = false;
            timer1.Start();
            labelStatus.Text = ("Game in Progress");
            ctrl_Check(true);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
              txtBox_Paint();
            foreach (GroupBox groupBox in gamePanel.Controls)
            {
                foreach (TextBox txtBox in groupBox.Controls)
                {
                    txtBox.Text = "";
                }
            }
            labelStatus.Text = ("Game Cleaned");
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            validate.arr_control.Clear();

            txtBox_Paint();

            groupBox_Validate();

            validate.txtBox_Horiz_Validate();

            validate.txtBox_Vert_Validate();

            DialogResult d_Result = validate.paint_TxtBox();

            if (d_Result == DialogResult.Yes)
            {
                buttonNewGame_Click(sender, e);
            }
            if (d_Result == DialogResult.No)
            {
                s_Time = i_Hour.ToString() + ":" + i_Min.ToString() + ":" + i_Sec.ToString();
                this.Opacity = 0.5;
            }
            timer1.Start();
        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {
            i_Sec += 1;
            if (i_Sec > 59)
            {
                i_Sec = 0;
                i_Min += 1;
                labelTimeMinutes.Text = i_Min.ToString();
                if (i_Min > 59)
                {
                    i_Min = 0;
                    i_Hour += 1;
                    labelTimeMinutes.Text = i_Min.ToString();
                    labelTimeHour.Text = i_Hour.ToString();
                }
            }
            labelTimeHour.Text = i_Sec.ToString();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("Are You Sure You Want To Quit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (exit == DialogResult.No)
            {
                MessageBox.Show("Okay, Let's Go Back To The Game");
                labelStatus.Text = "The Game Countinues";
            }
            if (exit == DialogResult.Yes)
            {
                labelStatus.Text = "Leaving The Game";
                MessageBox.Show("Thanks For Played, See You Soon ;)");
                this.Close();
                Application.Exit();
            }
        }

    }
}
