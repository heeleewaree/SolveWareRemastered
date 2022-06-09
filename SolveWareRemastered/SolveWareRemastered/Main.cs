using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SolveWareRemastered
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            CustomDesign();
            CustomApp();
        }
        #region Font
        //https://textgenerator.ru/font/small-capital
        #endregion

        #region Global Variables
        byte mbc_r, mbc_g, mbc_b;
        byte smbc_r, smbc_g, smbc_b;
        byte abc_r, abc_g, abc_b;
        byte tc_r, tc_g, tc_b;
        #endregion

        #region Design
        private void CustomDesign()
        {
            SOC_SubMenu.Visible = false;
            SOTSO_SubMenu.Visible = false;
            SettingsSubMenu.Visible = false;
        }
        #endregion

        #region Hide SubMenu
        private void HideSubMenu()
        {
            if (SOC_SubMenu.Visible == true)
                SOC_SubMenu.Visible = false;
            if (SOTSO_SubMenu.Visible == true)
                SOTSO_SubMenu.Visible = false;
            if (SettingsSubMenu.Visible == true)
                SettingsSubMenu.Visible = false;
        }
        #endregion

        #region Show SubMenu
        private void ShowSubMenu(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                HideSubMenu();
                SubMenu.Visible = true;
            }
            else
                SubMenu.Visible = false;
        }
        #endregion

        #region Open SubForm
        private new Form ActiveForm = null;
        private void OpenSubForm(Form SubForm)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            ActiveForm = SubForm;
            SubForm.TopLevel = false;
            SubForm.FormBorderStyle = FormBorderStyle.None;
            SubForm.Dock = DockStyle.Fill;
            SubFormPanel.Controls.Add(SubForm);
            SubFormPanel.Tag = SubForm;
            SubForm.BringToFront();
            SubForm.Show();
            SubForm.FormClosed += form_closed;
        }
        private void form_closed(object sender, EventArgs e)
        {
            CustomApp();
        }
        #endregion

        #region Second Order Curves
        private void SecondOrderCurves_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            ShowSubMenu(SOC_SubMenu);
        }
        private void SOC_CanonicalEquation_Click(object sender, EventArgs e)
        {
            OpenSubForm(new CanonicalEquation_SOC());
            HideSubMenu();
        }
        private void SOC_GeneralEquation_Click(object sender, EventArgs e)
        {
            OpenSubForm(new GeneralEquation_SOC());
            HideSubMenu();
        }
        #endregion

        #region Surfaces Of The Second Order
        private void SurfacesOfTheSecondOrder_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            ShowSubMenu(SOTSO_SubMenu);
        }
        private void SOTSO_CanonicalEquation_Click(object sender, EventArgs e)
        {
            OpenSubForm(new CanonicalEquation_SOTSO());
            HideSubMenu();
        }
        private void SOTSO_GeneralEquation_Click(object sender, EventArgs e)
        {
            OpenSubForm(new GeneralEquation_SOTSO());
            HideSubMenu();
        }
        private void isometricView_Click(object sender, EventArgs e)
        {
            OpenSubForm(new IsometricView_SOTSO());
            HideSubMenu();
        }
        #endregion

        #region Plane-Surface Intersection
        private void PlaneSurfaceIntersection_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            OpenSubForm(new PlaneSurfaceIntersectionForm());
            HideSubMenu();
        }
        #endregion

        #region Settings
        private void Settings_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            ShowSubMenu(SettingsSubMenu);
        }
        private void CustomizeApp_Click(object sender, EventArgs e)
        {
            OpenSubForm(new CustomizeApp_Settings());
            HideSubMenu();
        }
        private void CustomizePlot_Click(object sender, EventArgs e)
        {
            OpenSubForm(new CustomizePlot_Settings());
            HideSubMenu();
        }
        #endregion

        #region About
        private void About_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            OpenSubForm(new AboutForm());
            HideSubMenu();
        }
        #endregion

        #region Customize App
        private void CustomApp()
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

                panel1.BackColor = Color.FromArgb(mbc_r, mbc_g, mbc_b);

                SOC_SubMenu.BackColor = Color.FromArgb(smbc_r, smbc_g, smbc_b);
                SOTSO_SubMenu.BackColor = Color.FromArgb(smbc_r, smbc_g, smbc_b);
                SettingsSubMenu.BackColor = Color.FromArgb(smbc_r, smbc_g, smbc_b);
                SubFormPanel.BackColor = Color.FromArgb(abc_r, abc_g, abc_b);

                SecondOrderCurves.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
                SurfacesOfTheSecondOrder.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
                PlaneSurfaceIntersection.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
                Settings.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
                About.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);

                SOC_CanonicalEquation.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
                SOC_GeneralEquation.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
                SOTSO_CanonicalEquation.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
                SOTSO_GeneralEquation.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
                CustomizeApp.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
                CustomizePlot.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region SWR
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            HideSubMenu();
        }
        #endregion

        #region Windows Buttons
        /*

        #region Quit
        private void quit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion

        #region Full Size Form
        private void fullsize_Click(object sender, EventArgs e)
        {
            if (!size)
            {
                this.WindowState = FormWindowState.Maximized;
                size = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.CenterToScreen();
                size = false;
            }
        }
        private void window_DoubleClick(object sender, EventArgs e)
        {
            if (!size)
            {
                this.WindowState = FormWindowState.Maximized;
                size = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.CenterToScreen();
                size = false;
            }
        }
        #endregion

        #region Hide Window
        private void hideFrom_Click(object sender, EventArgs e)
        {
            this.CenterToScreen();
            if (ActiveForm != null)
                ActiveForm.Close();
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
        */
        #endregion //disable

        #region Mouse Things
        /*
        void mouseMove1(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X - 277, mouseOffset.Y + 27);
                Location = mousePos;
                if (Cursor.Position.Y == 0)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else if (this.Location.Y - Cursor.Position.Y < 0)
                {
                    this.WindowState = FormWindowState.Normal;
                }

                Console.WriteLine(this.Location.Y);
                Console.WriteLine(Cursor.Position.Y);
                Console.WriteLine("  ");
            }
        }
        void mouseDown1(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                    SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }
        void mouseUp1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }*/
        #endregion //disable
    }
}
