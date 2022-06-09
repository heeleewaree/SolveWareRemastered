
namespace SolveWareRemastered
{
    partial class CustomizeApp_Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ResetToDefault = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Apply = new System.Windows.Forms.Button();
            this.MBC_R = new System.Windows.Forms.TextBox();
            this.MBC_G = new System.Windows.Forms.TextBox();
            this.MBC_B = new System.Windows.Forms.TextBox();
            this.SMBC_B = new System.Windows.Forms.TextBox();
            this.SMBC_G = new System.Windows.Forms.TextBox();
            this.SMBC_R = new System.Windows.Forms.TextBox();
            this.ABC_B = new System.Windows.Forms.TextBox();
            this.ABC_G = new System.Windows.Forms.TextBox();
            this.ABC_R = new System.Windows.Forms.TextBox();
            this.TC_B = new System.Windows.Forms.TextBox();
            this.TC_G = new System.Windows.Forms.TextBox();
            this.TC_R = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ResetToDefault
            // 
            this.ResetToDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResetToDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetToDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ResetToDefault.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ResetToDefault.Location = new System.Drawing.Point(12, 619);
            this.ResetToDefault.Name = "ResetToDefault";
            this.ResetToDefault.Size = new System.Drawing.Size(89, 30);
            this.ResetToDefault.TabIndex = 0;
            this.ResetToDefault.Text = "ʀᴇsᴇᴛ";
            this.ResetToDefault.UseVisualStyleBackColor = true;
            this.ResetToDefault.Click += new System.EventHandler(this.ResetToDefault_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(117, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Menu back color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(117, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "App back color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(117, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Submenu back color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(117, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Text color";
            // 
            // Apply
            // 
            this.Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Apply.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Apply.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Apply.Location = new System.Drawing.Point(821, 12);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(89, 30);
            this.Apply.TabIndex = 12;
            this.Apply.Text = "ᴀᴘᴘʟʏ";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // MBC_R
            // 
            this.MBC_R.Location = new System.Drawing.Point(12, 12);
            this.MBC_R.Name = "MBC_R";
            this.MBC_R.Size = new System.Drawing.Size(29, 20);
            this.MBC_R.TabIndex = 26;
            this.MBC_R.Text = "255";
            this.MBC_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MBC_R.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // MBC_G
            // 
            this.MBC_G.Location = new System.Drawing.Point(47, 12);
            this.MBC_G.Name = "MBC_G";
            this.MBC_G.Size = new System.Drawing.Size(29, 20);
            this.MBC_G.TabIndex = 27;
            this.MBC_G.Text = "255";
            this.MBC_G.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MBC_G.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // MBC_B
            // 
            this.MBC_B.Location = new System.Drawing.Point(82, 12);
            this.MBC_B.Name = "MBC_B";
            this.MBC_B.Size = new System.Drawing.Size(29, 20);
            this.MBC_B.TabIndex = 28;
            this.MBC_B.Text = "255";
            this.MBC_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MBC_B.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // SMBC_B
            // 
            this.SMBC_B.Location = new System.Drawing.Point(82, 40);
            this.SMBC_B.Name = "SMBC_B";
            this.SMBC_B.Size = new System.Drawing.Size(29, 20);
            this.SMBC_B.TabIndex = 31;
            this.SMBC_B.Text = "255";
            this.SMBC_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SMBC_B.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // SMBC_G
            // 
            this.SMBC_G.Location = new System.Drawing.Point(47, 40);
            this.SMBC_G.Name = "SMBC_G";
            this.SMBC_G.Size = new System.Drawing.Size(29, 20);
            this.SMBC_G.TabIndex = 30;
            this.SMBC_G.Text = "255";
            this.SMBC_G.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SMBC_G.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // SMBC_R
            // 
            this.SMBC_R.Location = new System.Drawing.Point(12, 40);
            this.SMBC_R.Name = "SMBC_R";
            this.SMBC_R.Size = new System.Drawing.Size(29, 20);
            this.SMBC_R.TabIndex = 29;
            this.SMBC_R.Text = "255";
            this.SMBC_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SMBC_R.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // ABC_B
            // 
            this.ABC_B.Location = new System.Drawing.Point(82, 66);
            this.ABC_B.Name = "ABC_B";
            this.ABC_B.Size = new System.Drawing.Size(29, 20);
            this.ABC_B.TabIndex = 34;
            this.ABC_B.Text = "255";
            this.ABC_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ABC_B.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // ABC_G
            // 
            this.ABC_G.Location = new System.Drawing.Point(47, 66);
            this.ABC_G.Name = "ABC_G";
            this.ABC_G.Size = new System.Drawing.Size(29, 20);
            this.ABC_G.TabIndex = 33;
            this.ABC_G.Text = "255";
            this.ABC_G.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ABC_G.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // ABC_R
            // 
            this.ABC_R.Location = new System.Drawing.Point(12, 66);
            this.ABC_R.Name = "ABC_R";
            this.ABC_R.Size = new System.Drawing.Size(29, 20);
            this.ABC_R.TabIndex = 32;
            this.ABC_R.Text = "255";
            this.ABC_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ABC_R.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // TC_B
            // 
            this.TC_B.Location = new System.Drawing.Point(82, 92);
            this.TC_B.Name = "TC_B";
            this.TC_B.Size = new System.Drawing.Size(29, 20);
            this.TC_B.TabIndex = 37;
            this.TC_B.Text = "255";
            this.TC_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TC_B.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // TC_G
            // 
            this.TC_G.Location = new System.Drawing.Point(47, 92);
            this.TC_G.Name = "TC_G";
            this.TC_G.Size = new System.Drawing.Size(29, 20);
            this.TC_G.TabIndex = 36;
            this.TC_G.Text = "255";
            this.TC_G.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TC_G.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // TC_R
            // 
            this.TC_R.Location = new System.Drawing.Point(12, 92);
            this.TC_R.Name = "TC_R";
            this.TC_R.Size = new System.Drawing.Size(29, 20);
            this.TC_R.TabIndex = 35;
            this.TC_R.Text = "255";
            this.TC_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TC_R.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // CustomizeApp_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(922, 661);
            this.Controls.Add(this.TC_B);
            this.Controls.Add(this.TC_G);
            this.Controls.Add(this.TC_R);
            this.Controls.Add(this.ABC_B);
            this.Controls.Add(this.ABC_G);
            this.Controls.Add(this.ABC_R);
            this.Controls.Add(this.SMBC_B);
            this.Controls.Add(this.SMBC_G);
            this.Controls.Add(this.SMBC_R);
            this.Controls.Add(this.MBC_B);
            this.Controls.Add(this.MBC_G);
            this.Controls.Add(this.MBC_R);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResetToDefault);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomizeApp_Settings";
            this.Text = "CustomizeAppSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ResetToDefault;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.TextBox MBC_R;
        private System.Windows.Forms.TextBox MBC_G;
        private System.Windows.Forms.TextBox MBC_B;
        private System.Windows.Forms.TextBox SMBC_B;
        private System.Windows.Forms.TextBox SMBC_G;
        private System.Windows.Forms.TextBox SMBC_R;
        private System.Windows.Forms.TextBox ABC_B;
        private System.Windows.Forms.TextBox ABC_G;
        private System.Windows.Forms.TextBox ABC_R;
        private System.Windows.Forms.TextBox TC_B;
        private System.Windows.Forms.TextBox TC_G;
        private System.Windows.Forms.TextBox TC_R;
    }
}