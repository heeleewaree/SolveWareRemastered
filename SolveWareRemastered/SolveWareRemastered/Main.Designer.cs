
namespace SolveWareRemastered
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.About = new System.Windows.Forms.Button();
            this.SettingsSubMenu = new System.Windows.Forms.Panel();
            this.CustomizePlot = new System.Windows.Forms.Button();
            this.CustomizeApp = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.PlaneSurfaceIntersection = new System.Windows.Forms.Button();
            this.SOTSO_SubMenu = new System.Windows.Forms.Panel();
            this.SOTSO_GeneralEquation = new System.Windows.Forms.Button();
            this.SOTSO_CanonicalEquation = new System.Windows.Forms.Button();
            this.SurfacesOfTheSecondOrder = new System.Windows.Forms.Button();
            this.SOC_SubMenu = new System.Windows.Forms.Panel();
            this.SOC_GeneralEquation = new System.Windows.Forms.Button();
            this.SOC_CanonicalEquation = new System.Windows.Forms.Button();
            this.SecondOrderCurves = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SubFormPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.isometricView = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SettingsSubMenu.SuspendLayout();
            this.SOTSO_SubMenu.SuspendLayout();
            this.SOC_SubMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SubFormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panel1.Controls.Add(this.About);
            this.panel1.Controls.Add(this.SettingsSubMenu);
            this.panel1.Controls.Add(this.Settings);
            this.panel1.Controls.Add(this.PlaneSurfaceIntersection);
            this.panel1.Controls.Add(this.SOTSO_SubMenu);
            this.panel1.Controls.Add(this.SurfacesOfTheSecondOrder);
            this.panel1.Controls.Add(this.SOC_SubMenu);
            this.panel1.Controls.Add(this.SecondOrderCurves);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 700);
            this.panel1.TabIndex = 0;
            // 
            // About
            // 
            this.About.Dock = System.Windows.Forms.DockStyle.Top;
            this.About.FlatAppearance.BorderSize = 0;
            this.About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.About.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.About.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.About.Location = new System.Drawing.Point(0, 534);
            this.About.Name = "About";
            this.About.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.About.Size = new System.Drawing.Size(277, 40);
            this.About.TabIndex = 9;
            this.About.Text = "ᴀʙᴏᴜᴛ";
            this.About.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.About.UseVisualStyleBackColor = true;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // SettingsSubMenu
            // 
            this.SettingsSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.SettingsSubMenu.Controls.Add(this.CustomizePlot);
            this.SettingsSubMenu.Controls.Add(this.CustomizeApp);
            this.SettingsSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsSubMenu.Location = new System.Drawing.Point(0, 454);
            this.SettingsSubMenu.Name = "SettingsSubMenu";
            this.SettingsSubMenu.Size = new System.Drawing.Size(277, 80);
            this.SettingsSubMenu.TabIndex = 8;
            // 
            // CustomizePlot
            // 
            this.CustomizePlot.Dock = System.Windows.Forms.DockStyle.Top;
            this.CustomizePlot.FlatAppearance.BorderSize = 0;
            this.CustomizePlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomizePlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CustomizePlot.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CustomizePlot.Location = new System.Drawing.Point(0, 40);
            this.CustomizePlot.Name = "CustomizePlot";
            this.CustomizePlot.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.CustomizePlot.Size = new System.Drawing.Size(277, 40);
            this.CustomizePlot.TabIndex = 1;
            this.CustomizePlot.Text = "ᴄᴜsᴛᴏᴍɪᴢᴇ ᴘʟᴏᴛ";
            this.CustomizePlot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CustomizePlot.UseVisualStyleBackColor = true;
            this.CustomizePlot.Click += new System.EventHandler(this.CustomizePlot_Click);
            // 
            // CustomizeApp
            // 
            this.CustomizeApp.Dock = System.Windows.Forms.DockStyle.Top;
            this.CustomizeApp.FlatAppearance.BorderSize = 0;
            this.CustomizeApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomizeApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.CustomizeApp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CustomizeApp.Location = new System.Drawing.Point(0, 0);
            this.CustomizeApp.Name = "CustomizeApp";
            this.CustomizeApp.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.CustomizeApp.Size = new System.Drawing.Size(277, 40);
            this.CustomizeApp.TabIndex = 0;
            this.CustomizeApp.Text = "ᴄᴜsᴛᴏᴍɪᴢᴇ ᴀᴘᴘ";
            this.CustomizeApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CustomizeApp.UseVisualStyleBackColor = true;
            this.CustomizeApp.Click += new System.EventHandler(this.CustomizeApp_Click);
            // 
            // Settings
            // 
            this.Settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.Settings.FlatAppearance.BorderSize = 0;
            this.Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Settings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Settings.Location = new System.Drawing.Point(0, 414);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.Settings.Size = new System.Drawing.Size(277, 40);
            this.Settings.TabIndex = 7;
            this.Settings.Text = "sᴇᴛᴛɪɴɢs";
            this.Settings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // PlaneSurfaceIntersection
            // 
            this.PlaneSurfaceIntersection.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlaneSurfaceIntersection.FlatAppearance.BorderSize = 0;
            this.PlaneSurfaceIntersection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlaneSurfaceIntersection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.PlaneSurfaceIntersection.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PlaneSurfaceIntersection.Location = new System.Drawing.Point(0, 374);
            this.PlaneSurfaceIntersection.Name = "PlaneSurfaceIntersection";
            this.PlaneSurfaceIntersection.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.PlaneSurfaceIntersection.Size = new System.Drawing.Size(277, 40);
            this.PlaneSurfaceIntersection.TabIndex = 5;
            this.PlaneSurfaceIntersection.Text = "ᴘʟᴀɴᴇ-sᴜʀꜰᴀᴄᴇ ɪɴᴛᴇʀsᴇᴄᴛɪᴏɴ";
            this.PlaneSurfaceIntersection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PlaneSurfaceIntersection.UseVisualStyleBackColor = true;
            this.PlaneSurfaceIntersection.Click += new System.EventHandler(this.PlaneSurfaceIntersection_Click);
            // 
            // SOTSO_SubMenu
            // 
            this.SOTSO_SubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.SOTSO_SubMenu.Controls.Add(this.isometricView);
            this.SOTSO_SubMenu.Controls.Add(this.SOTSO_GeneralEquation);
            this.SOTSO_SubMenu.Controls.Add(this.SOTSO_CanonicalEquation);
            this.SOTSO_SubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.SOTSO_SubMenu.Location = new System.Drawing.Point(0, 254);
            this.SOTSO_SubMenu.Name = "SOTSO_SubMenu";
            this.SOTSO_SubMenu.Size = new System.Drawing.Size(277, 120);
            this.SOTSO_SubMenu.TabIndex = 4;
            // 
            // SOTSO_GeneralEquation
            // 
            this.SOTSO_GeneralEquation.Dock = System.Windows.Forms.DockStyle.Top;
            this.SOTSO_GeneralEquation.FlatAppearance.BorderSize = 0;
            this.SOTSO_GeneralEquation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SOTSO_GeneralEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.SOTSO_GeneralEquation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SOTSO_GeneralEquation.Location = new System.Drawing.Point(0, 40);
            this.SOTSO_GeneralEquation.Name = "SOTSO_GeneralEquation";
            this.SOTSO_GeneralEquation.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.SOTSO_GeneralEquation.Size = new System.Drawing.Size(277, 40);
            this.SOTSO_GeneralEquation.TabIndex = 1;
            this.SOTSO_GeneralEquation.Text = "ɢᴇɴᴇʀᴀʟ ᴇǫᴜᴀᴛɪᴏɴ";
            this.SOTSO_GeneralEquation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SOTSO_GeneralEquation.UseVisualStyleBackColor = true;
            this.SOTSO_GeneralEquation.Click += new System.EventHandler(this.SOTSO_GeneralEquation_Click);
            // 
            // SOTSO_CanonicalEquation
            // 
            this.SOTSO_CanonicalEquation.Dock = System.Windows.Forms.DockStyle.Top;
            this.SOTSO_CanonicalEquation.FlatAppearance.BorderSize = 0;
            this.SOTSO_CanonicalEquation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SOTSO_CanonicalEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.SOTSO_CanonicalEquation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SOTSO_CanonicalEquation.Location = new System.Drawing.Point(0, 0);
            this.SOTSO_CanonicalEquation.Name = "SOTSO_CanonicalEquation";
            this.SOTSO_CanonicalEquation.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.SOTSO_CanonicalEquation.Size = new System.Drawing.Size(277, 40);
            this.SOTSO_CanonicalEquation.TabIndex = 0;
            this.SOTSO_CanonicalEquation.Text = "ᴄᴀɴᴏɴɪᴄᴀʟ ᴇǫᴜᴀᴛɪᴏɴ";
            this.SOTSO_CanonicalEquation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SOTSO_CanonicalEquation.UseVisualStyleBackColor = true;
            this.SOTSO_CanonicalEquation.Click += new System.EventHandler(this.SOTSO_CanonicalEquation_Click);
            // 
            // SurfacesOfTheSecondOrder
            // 
            this.SurfacesOfTheSecondOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.SurfacesOfTheSecondOrder.FlatAppearance.BorderSize = 0;
            this.SurfacesOfTheSecondOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SurfacesOfTheSecondOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.SurfacesOfTheSecondOrder.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SurfacesOfTheSecondOrder.Location = new System.Drawing.Point(0, 214);
            this.SurfacesOfTheSecondOrder.Name = "SurfacesOfTheSecondOrder";
            this.SurfacesOfTheSecondOrder.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.SurfacesOfTheSecondOrder.Size = new System.Drawing.Size(277, 40);
            this.SurfacesOfTheSecondOrder.TabIndex = 3;
            this.SurfacesOfTheSecondOrder.Text = "sᴇᴄᴏɴᴅ ᴏʀᴅᴇʀ sᴜʀꜰᴀᴄᴇs";
            this.SurfacesOfTheSecondOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SurfacesOfTheSecondOrder.UseVisualStyleBackColor = true;
            this.SurfacesOfTheSecondOrder.Click += new System.EventHandler(this.SurfacesOfTheSecondOrder_Click);
            // 
            // SOC_SubMenu
            // 
            this.SOC_SubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.SOC_SubMenu.Controls.Add(this.SOC_GeneralEquation);
            this.SOC_SubMenu.Controls.Add(this.SOC_CanonicalEquation);
            this.SOC_SubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.SOC_SubMenu.Location = new System.Drawing.Point(0, 134);
            this.SOC_SubMenu.Name = "SOC_SubMenu";
            this.SOC_SubMenu.Size = new System.Drawing.Size(277, 80);
            this.SOC_SubMenu.TabIndex = 2;
            // 
            // SOC_GeneralEquation
            // 
            this.SOC_GeneralEquation.Dock = System.Windows.Forms.DockStyle.Top;
            this.SOC_GeneralEquation.FlatAppearance.BorderSize = 0;
            this.SOC_GeneralEquation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SOC_GeneralEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.SOC_GeneralEquation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SOC_GeneralEquation.Location = new System.Drawing.Point(0, 40);
            this.SOC_GeneralEquation.Name = "SOC_GeneralEquation";
            this.SOC_GeneralEquation.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.SOC_GeneralEquation.Size = new System.Drawing.Size(277, 40);
            this.SOC_GeneralEquation.TabIndex = 1;
            this.SOC_GeneralEquation.Text = "ɢᴇɴᴇʀᴀʟ ᴇǫᴜᴀᴛɪᴏɴ";
            this.SOC_GeneralEquation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SOC_GeneralEquation.UseVisualStyleBackColor = true;
            this.SOC_GeneralEquation.Click += new System.EventHandler(this.SOC_GeneralEquation_Click);
            // 
            // SOC_CanonicalEquation
            // 
            this.SOC_CanonicalEquation.Dock = System.Windows.Forms.DockStyle.Top;
            this.SOC_CanonicalEquation.FlatAppearance.BorderSize = 0;
            this.SOC_CanonicalEquation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SOC_CanonicalEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.SOC_CanonicalEquation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SOC_CanonicalEquation.Location = new System.Drawing.Point(0, 0);
            this.SOC_CanonicalEquation.Name = "SOC_CanonicalEquation";
            this.SOC_CanonicalEquation.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.SOC_CanonicalEquation.Size = new System.Drawing.Size(277, 40);
            this.SOC_CanonicalEquation.TabIndex = 0;
            this.SOC_CanonicalEquation.Text = "ᴄᴀɴᴏɴɪᴄᴀʟ ᴇǫᴜᴀᴛɪᴏɴ";
            this.SOC_CanonicalEquation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SOC_CanonicalEquation.UseVisualStyleBackColor = true;
            this.SOC_CanonicalEquation.Click += new System.EventHandler(this.SOC_CanonicalEquation_Click);
            // 
            // SecondOrderCurves
            // 
            this.SecondOrderCurves.Dock = System.Windows.Forms.DockStyle.Top;
            this.SecondOrderCurves.FlatAppearance.BorderSize = 0;
            this.SecondOrderCurves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SecondOrderCurves.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.SecondOrderCurves.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SecondOrderCurves.Location = new System.Drawing.Point(0, 94);
            this.SecondOrderCurves.Name = "SecondOrderCurves";
            this.SecondOrderCurves.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.SecondOrderCurves.Size = new System.Drawing.Size(277, 40);
            this.SecondOrderCurves.TabIndex = 1;
            this.SecondOrderCurves.Text = "sᴇᴄᴏɴᴅ ᴏʀᴅᴇʀ ᴄᴜʀᴠᴇs";
            this.SecondOrderCurves.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SecondOrderCurves.UseVisualStyleBackColor = true;
            this.SecondOrderCurves.Click += new System.EventHandler(this.SecondOrderCurves_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SolveWareRemastered.Properties.Resources.logo3;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 94);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // SubFormPanel
            // 
            this.SubFormPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.SubFormPanel.Controls.Add(this.pictureBox2);
            this.SubFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubFormPanel.Location = new System.Drawing.Point(277, 0);
            this.SubFormPanel.Name = "SubFormPanel";
            this.SubFormPanel.Size = new System.Drawing.Size(1138, 700);
            this.SubFormPanel.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::SolveWareRemastered.Properties.Resources.realdeal;
            this.pictureBox2.Location = new System.Drawing.Point(227, 89);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(654, 557);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // isometricView
            // 
            this.isometricView.Dock = System.Windows.Forms.DockStyle.Top;
            this.isometricView.FlatAppearance.BorderSize = 0;
            this.isometricView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.isometricView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.isometricView.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.isometricView.Location = new System.Drawing.Point(0, 80);
            this.isometricView.Name = "isometricView";
            this.isometricView.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.isometricView.Size = new System.Drawing.Size(277, 40);
            this.isometricView.TabIndex = 11;
            this.isometricView.Text = "ɪsᴏᴍᴇᴛʀɪᴄ ᴠɪᴇᴡ";
            this.isometricView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.isometricView.UseVisualStyleBackColor = true;
            this.isometricView.Click += new System.EventHandler(this.isometricView_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 700);
            this.Controls.Add(this.SubFormPanel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1415, 700);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SolveWare Remastered";
            this.panel1.ResumeLayout(false);
            this.SettingsSubMenu.ResumeLayout(false);
            this.SOTSO_SubMenu.ResumeLayout(false);
            this.SOC_SubMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.SubFormPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SecondOrderCurves;
        private System.Windows.Forms.Button SurfacesOfTheSecondOrder;
        private System.Windows.Forms.Panel SOC_SubMenu;
        private System.Windows.Forms.Button SOC_GeneralEquation;
        private System.Windows.Forms.Button SOC_CanonicalEquation;
        private System.Windows.Forms.Button About;
        private System.Windows.Forms.Panel SettingsSubMenu;
        private System.Windows.Forms.Button CustomizePlot;
        private System.Windows.Forms.Button CustomizeApp;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button PlaneSurfaceIntersection;
        private System.Windows.Forms.Panel SOTSO_SubMenu;
        private System.Windows.Forms.Button SOTSO_GeneralEquation;
        private System.Windows.Forms.Button SOTSO_CanonicalEquation;
        private System.Windows.Forms.Panel SubFormPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button isometricView;
    }
}

