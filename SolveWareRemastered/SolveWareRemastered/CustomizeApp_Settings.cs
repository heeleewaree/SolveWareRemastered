using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SolveWareRemastered
{
    public partial class CustomizeApp_Settings : Form
    {
        public CustomizeApp_Settings()
        {
            InitializeComponent();
            ReadingFile();
            CustomApp();
        }
        #region Global Variables
        byte mbc_r, mbc_g, mbc_b;
        byte smbc_r, smbc_g, smbc_b;
        byte abc_r = 20, abc_g = 20, abc_b = 20;
        byte tc_r = 255, tc_g = 255, tc_b = 255;
        #endregion

        #region Reset To Default
        private void ResetToDefault_Click(object sender, EventArgs e)
        {
            MBC_R.Text = "15";
            MBC_G.Text = "15";
            MBC_B.Text = "15";
            SMBC_R.Text = "140";
            SMBC_G.Text = "10";
            SMBC_B.Text = "10";
            ABC_R.Text = "20";
            ABC_G.Text = "20";
            ABC_B.Text = "20";
            TC_R.Text = "255";
            TC_G.Text = "255";
            TC_B.Text = "255";

            mbc_r = Convert.ToByte(MBC_R.Text);
            mbc_g = Convert.ToByte(MBC_G.Text);
            mbc_b = Convert.ToByte(MBC_B.Text);
            smbc_r = Convert.ToByte(SMBC_R.Text);
            smbc_g = Convert.ToByte(SMBC_G.Text);
            smbc_b = Convert.ToByte(SMBC_B.Text);
            abc_r = Convert.ToByte(ABC_R.Text);
            abc_g = Convert.ToByte(ABC_G.Text);
            abc_b = Convert.ToByte(ABC_B.Text);
            tc_r = Convert.ToByte(TC_R.Text);
            tc_g = Convert.ToByte(TC_G.Text);
            tc_b = Convert.ToByte(TC_B.Text);
        }

        #endregion

        #region Apply Button
        private void Apply_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter file = new StreamWriter("CustomizeApp_Settings.txt");
                file.WriteLine(MBC_R.Text);
                file.WriteLine(MBC_G.Text);
                file.WriteLine(MBC_B.Text);
                file.WriteLine(SMBC_R.Text);
                file.WriteLine(SMBC_G.Text);
                file.WriteLine(SMBC_B.Text);
                file.WriteLine(ABC_R.Text);
                file.WriteLine(ABC_G.Text);
                file.WriteLine(ABC_B.Text);
                file.WriteLine(TC_R.Text);
                file.WriteLine(TC_G.Text);
                file.WriteLine(TC_B.Text);
                file.Close();
            }
            catch
            {
                return;
            }

            this.Close();
            this.Dispose();
            GC.Collect();
        }

        #endregion

        #region Read From File
        private void ReadingFile()
        {
            
            String line;
            int operation = 0;
            try
            {
                StreamReader file = new StreamReader("CustomizeApp_Settings.txt");
                line = file.ReadLine();
                while (line != null)
                {
                    if (operation == 0)
                        MBC_R.Text = line;
                    if (operation == 1)
                        MBC_G.Text = line;
                    if (operation == 2)
                        MBC_B.Text = line;
                    if (operation == 3)
                        SMBC_R.Text = line;
                    if (operation == 4)
                        SMBC_G.Text = line;
                    if (operation == 5)
                        SMBC_B.Text = line;
                    if (operation == 6)
                        ABC_R.Text = line;
                    if (operation == 7)
                        ABC_G.Text = line;
                    if (operation == 8)
                        ABC_B.Text = line;
                    if (operation == 9)
                        TC_R.Text = line;
                    if (operation == 10)
                        TC_G.Text = line;
                    if (operation == 11)
                        TC_B.Text = line;
                    line = file.ReadLine();
                    operation++;
                }
                file.Close();
                mbc_r = Convert.ToByte(MBC_R.Text);
                mbc_g = Convert.ToByte(MBC_G.Text);
                mbc_b = Convert.ToByte(MBC_B.Text);
                smbc_r = Convert.ToByte(SMBC_R.Text);
                smbc_g = Convert.ToByte(SMBC_G.Text);
                smbc_b = Convert.ToByte(SMBC_B.Text);
                abc_r = Convert.ToByte(ABC_R.Text);
                abc_g = Convert.ToByte(ABC_G.Text);
                abc_b = Convert.ToByte(ABC_B.Text);
                tc_r = Convert.ToByte(TC_R.Text);
                tc_g = Convert.ToByte(TC_G.Text);
                tc_b = Convert.ToByte(TC_B.Text);
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Customize App
        private void CustomApp()
        {
            this.BackColor = Color.FromArgb(abc_r, abc_g, abc_b);

            label1.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label2.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label3.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label4.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            Apply.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            ResetToDefault.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
        }
        #endregion

        #region Key Press
        private void Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
        #endregion
    }
}
