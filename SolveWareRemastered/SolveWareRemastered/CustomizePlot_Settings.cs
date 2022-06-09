using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SolveWareRemastered
{
    public partial class CustomizePlot_Settings : Form
    {
        public CustomizePlot_Settings()
        {
            InitializeComponent();
            FileReading();
            CustomApp();
        }
        #region Global Variables
        byte mbc_r, mbc_g, mbc_b;
        byte smbc_r, smbc_g, smbc_b;
        byte abc_r = 20, abc_g = 20, abc_b = 20;
        byte tc_r = 255, tc_g = 255, tc_b = 255;
        byte pbc_r = 20, pbc_g = 20, pbc_b = 20;
        byte mac_r = 255, mac_g = 255, mac_b = 255;
        byte nac_r = 0, nac_g = 255, nac_b = 0;
        byte rac_r = 255, rac_g = 255, rac_b = 255;
        byte gc_r = 200, gc_g = 100, gc_b = 40;
        byte pc_r = 255, pc_g = 255, pc_b = 255;
        byte cpc_r = 255, cpc_g = 0, cpc_b = 0;
        byte nc_r = 255, nc_g = 255, nc_b = 255;
        #endregion

        #region Reading From File
        private void FileReading()
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
                        mbc_r = Convert.ToByte(line);
                    if (operation == 1)
                        mbc_g = Convert.ToByte(line);
                    if (operation == 2)
                        mbc_b = Convert.ToByte(line);
                    if (operation == 3)
                        smbc_r = Convert.ToByte(line);
                    if (operation == 4)
                        smbc_g = Convert.ToByte(line);
                    if (operation == 5)
                        smbc_b = Convert.ToByte(line);
                    if (operation == 6)
                        abc_r = Convert.ToByte(line);
                    if (operation == 7)
                        abc_g = Convert.ToByte(line);
                    if (operation == 8)
                        abc_b = Convert.ToByte(line);
                    if (operation == 9)
                        tc_r = Convert.ToByte(line);
                    if (operation == 10)
                        tc_g = Convert.ToByte(line);
                    if (operation == 11)
                        tc_b = Convert.ToByte(line);
                    line = file.ReadLine();
                    operation++;
                }
                file.Close();
            }
            catch
            {
                return;
            }
            operation = 0;
            try
            {
                StreamReader file = new StreamReader("CustomizePlot_Settings.txt");
                line = file.ReadLine();
                while (line != null)
                {
                    if (operation == 0)
                        pbc_r = Convert.ToByte(line);
                    if (operation == 1)
                        pbc_g = Convert.ToByte(line);
                    if (operation == 2)
                        pbc_b = Convert.ToByte(line);
                    if (operation == 3)
                        mac_r = Convert.ToByte(line);
                    if (operation == 4)
                        mac_g = Convert.ToByte(line);
                    if (operation == 5)
                        mac_b = Convert.ToByte(line);
                    if (operation == 6)
                        nac_r = Convert.ToByte(line);
                    if (operation == 7)
                        nac_g = Convert.ToByte(line);
                    if (operation == 8)
                        nac_b = Convert.ToByte(line);
                    if (operation == 9)
                        rac_r = Convert.ToByte(line);
                    if (operation == 10)
                        rac_g = Convert.ToByte(line);
                    if (operation == 11)
                        rac_b = Convert.ToByte(line);
                    if (operation == 12)
                        gc_r = Convert.ToByte(line);
                    if (operation == 13)
                        gc_g = Convert.ToByte(line);
                    if (operation == 14)
                        gc_b = Convert.ToByte(line);
                    if (operation == 15)
                        pc_r = Convert.ToByte(line);
                    if (operation == 16)
                        pc_g = Convert.ToByte(line);
                    if (operation == 17)
                        pc_b = Convert.ToByte(line);
                    if (operation == 18)
                        cpc_r = Convert.ToByte(line);
                    if (operation == 19)
                        cpc_g = Convert.ToByte(line);
                    if (operation == 20)
                        cpc_b = Convert.ToByte(line);
                    if (operation == 21)
                        nc_r = Convert.ToByte(line);
                    if (operation == 22)
                        nc_g = Convert.ToByte(line);
                    if (operation == 23)
                        nc_b = Convert.ToByte(line);
                    line = file.ReadLine();
                    operation++;
                }
                file.Close();

                PBC_R.Text = Convert.ToString(pbc_r);
                PBC_G.Text = Convert.ToString(pbc_g);
                PBC_B.Text = Convert.ToString(pbc_b);
                MAC_R.Text = Convert.ToString(mac_r);
                MAC_G.Text = Convert.ToString(mac_g);
                MAC_B.Text = Convert.ToString(mac_b);
                NAC_R.Text = Convert.ToString(nac_r);
                NAC_G.Text = Convert.ToString(nac_g);
                NAC_B.Text = Convert.ToString(nac_b);
                RAC_R.Text = Convert.ToString(rac_r);
                RAC_G.Text = Convert.ToString(rac_g);
                RAC_B.Text = Convert.ToString(rac_b);
                GC_R.Text = Convert.ToString(gc_r);
                GC_G.Text = Convert.ToString(gc_g);
                GC_B.Text = Convert.ToString(gc_b);
                PC_R.Text = Convert.ToString(pc_r);
                PC_G.Text = Convert.ToString(pc_g);
                PC_B.Text = Convert.ToString(pc_b);
                CPC_R.Text = Convert.ToString(cpc_r);
                CPC_G.Text = Convert.ToString(cpc_g);
                CPC_B.Text = Convert.ToString(cpc_b);
                NC_R.Text = Convert.ToString(nc_r);
                NC_G.Text = Convert.ToString(nc_g);
                NC_B.Text = Convert.ToString(nc_b);
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
            label5.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label6.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label7.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label8.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            Apply.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            ResetToDefault.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
        }
        #endregion

        #region Apply Button
        private void Apply_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter file = new StreamWriter("CustomizePlot_Settings.txt");
                file.WriteLine(PBC_R.Text);
                file.WriteLine(PBC_G.Text);
                file.WriteLine(PBC_B.Text);
                file.WriteLine(MAC_R.Text);
                file.WriteLine(MAC_G.Text);
                file.WriteLine(MAC_B.Text);
                file.WriteLine(NAC_R.Text);
                file.WriteLine(NAC_G.Text);
                file.WriteLine(NAC_B.Text);
                file.WriteLine(RAC_R.Text);
                file.WriteLine(RAC_G.Text);
                file.WriteLine(RAC_B.Text);
                file.WriteLine(GC_R.Text);
                file.WriteLine(GC_G.Text);
                file.WriteLine(GC_B.Text);
                file.WriteLine(PC_R.Text);
                file.WriteLine(PC_G.Text);
                file.WriteLine(PC_B.Text);
                file.WriteLine(CPC_R.Text);
                file.WriteLine(CPC_G.Text);
                file.WriteLine(CPC_B.Text);
                file.WriteLine(NC_R.Text);
                file.WriteLine(NC_G.Text);
                file.WriteLine(NC_B.Text);
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

        #region Reset To Default
        private void ResetToDefault_Click(object sender, EventArgs e)
        {
            PBC_R.Text = "20";
            PBC_G.Text = "20";
            PBC_B.Text = "20";
            MAC_R.Text = "0";
            MAC_G.Text = "0";
            MAC_B.Text = "255";
            NAC_R.Text = "0";
            NAC_G.Text = "255";
            NAC_B.Text = "0";
            RAC_R.Text = "255";
            RAC_G.Text = "255";
            RAC_B.Text = "255";
            GC_R.Text = "255";
            GC_G.Text = "200";
            GC_B.Text = "200";
            PC_R.Text = "255";
            PC_G.Text = "255";
            PC_B.Text = "255";
            CPC_R.Text = "255";
            CPC_G.Text = "0";
            CPC_B.Text = "0";
            NC_R.Text = "255";
            NC_G.Text = "255";
            NC_B.Text = "255";
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
