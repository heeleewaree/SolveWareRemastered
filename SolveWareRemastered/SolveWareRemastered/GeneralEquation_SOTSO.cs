using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SolveWareRemastered
{
    public partial class GeneralEquation_SOTSO : Form
    {
        public GeneralEquation_SOTSO()
        {
            InitializeComponent();
            FileReading();
            CustomApp();
            Plot1.MouseWheel += new MouseEventHandler(m_MouseWheel1);
            Plot2.MouseWheel += new MouseEventHandler(m_MouseWheel2);
            Plot3.MouseWheel += new MouseEventHandler(m_MouseWheel3);
            Paint_All();
        }

        #region Global Variables
        double Tick;
        int MaxTrack;
        double A, B, C, F, G, H, P, Q, R, D;
        double I, J, K, N1, N2, N3;
        double accuracy, length;
        bool GridCheck = false;
        bool HideNumbers = false;
        int OX = 430 / 2, OY = 230 / 2;
        double tau1, tau2, sigma, delta, k1, k2;
        double alpha, ksi, beta, gamma, tetta, lyambda;
        double angle, x0, y0;
        int scale1 = 40, scale2 = 40, scale3 = 40;
        double x, y, x1, x2, y1, y2, d;
        String surface;
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

        #region Resize Form
        private void GeneralEquation_SOTSO_Resize(object sender, EventArgs e)
        {
            Plot1.Width = panel1.Width / 2 - 20;
            Plot2.Width = Plot1.Width;
            panel1.Height = this.Height / 2 - 100;
            trackBar1.Location = new Point(panel1.Location.X, panel1.Height + 100);
            trackBar1.Width = Plot1.Width;
            trackBar2.Location = new Point(Plot2.Location.X+210, panel1.Height + 100);
            trackBar2.Width = Plot2.Width;
            Plot3.Location = new Point(trackBar1.Location.X, trackBar1.Location.Y + 42);
            Plot3.Width = Plot1.Width;
            Plot3.Height = Plot1.Height;
            trackBar3.Location = new Point(panel1.Location.X, panel1.Height + Plot3.Height + 145);
            trackBar3.Width = Plot3.Width;

            OX = Plot1.Width / 2;
            OY = Plot1.Height / 2;
            Paint_All();
        }
        #endregion

        #region Function Of Calculating All Values
        private void CalculateFunction()
        {
            try
            {
                A = Convert.ToDouble(textA.Text);
                B = Convert.ToDouble(textB.Text);
                C = Convert.ToDouble(textC.Text);
                F = Convert.ToDouble(textF.Text) / 2.0;
                G = Convert.ToDouble(textG.Text) / 2.0;
                H = Convert.ToDouble(textH.Text) / 2.0;
                P = Convert.ToDouble(textP.Text) / 2.0;
                Q = Convert.ToDouble(textQ.Text) / 2.0;
                R = Convert.ToDouble(textR.Text) / 2.0;
                D = Convert.ToDouble(textD.Text);
                accuracy = Convert.ToDouble(textAccuracy.Text);
                length = Convert.ToDouble(textLength.Text);
            }
            catch
            {
                return;
            }
            if ((A == 0) && (B == 0) && (C == 0) && (F == 0) && (G == 0) && (H == 0))
                return;
            tau1 = A + B + C;
            tau2 = A * B - F * F + A * C - G * G + B * C - H * H;
            sigma = (A * B * C) + (F * G * H) + (F * G * H) - (H * B * H) - (G * G * A) - (C * F * F);
            delta = (A * ((B * C * D) + (G * R * Q) + (Q * R * G) - (Q * Q * C) - (R * R * B) - (D * G * G)));
            delta -= (F * ((F * C * D) + (H * R * Q) + (P * R * G) - (P * C * Q) - (R * R * F) - (D * H * G)));
            delta += (H * ((F * G * D) + (H * Q * Q) + (P * R * B) - (P * G * Q) - (Q * R * F) - (D * H * B)));
            delta -= (P * ((F * G * R) + (H * Q * G) + (P * B * C) - (P * G * G) - (Q * C * F) - (R * B * H)));
            k1 = A * D - P * P + B * D - Q * Q + C * D - R * R;
            k2 = (A * B * D) + (F * Q * P) + (P * F * Q) - (P * P * B) - (Q * Q * A) - (D * F * F);
            k2 += (A * C * D) + (H * R * P) + (P * R * H) - (P * P * C) - (R * R * A) - (D * H * H);
            k2 += (B * C * D) + (G * R * Q) + (Q * G * R) - (Q * Q * C) - (R * R * B) - (D * G * G);

            if (I != 0)
            {
                alpha = (A * J * J) - (2 * F * I * J) + (B * I * I);//
                beta = (A * K * K) + (C * I * I) - (2 * H * I * K);//
                gamma = (2 * I * I * Q) - (2 * F * I * N1) - (2 * I * J * P) + (2 * A * J * N1);//
                tetta = (2 * I * I * R) - (2 * H * I * N1) + (2 * A * K * N1) - (2 * I * K * P);//
                ksi = (2 * G * I * I) - (2 * H * I * J) - (2 * F * I * K) + (2 * A * J * K);//
                lyambda = (D * I * I) + (A * N1 * N1) - (2 * I * N1 * P);//
                ksi = ksi / 2.0;
                gamma = gamma / 2.0;
                tetta = tetta / 2.0;

                angle = Math.Atan((2 * ksi) / (alpha - beta)) / 2;
                if ((alpha * beta - (ksi * ksi)) != 0)
                {
                    x0 = (-gamma * beta - (-tetta * ksi)) / (alpha * beta - (ksi * ksi));
                    y0 = (-tetta * alpha - (-gamma * ksi)) / (alpha * beta - (ksi * ksi));
                }
            }
            else if (J != 0)
            {
                alpha = (B * I * I) - (2 * F * I * J) + (A * J * J);//
                beta = (B * K * K) + (C * J * J) - (2 * J * G * K);//
                gamma = (2 * N2 * I * B) - (2 * F * J * N2) - (2 * I * J * Q) + (2 * P * J * J);//
                tetta = (2 * J * J * R) - (2 * G * J * N2) + (2 * B * K * N2) - (2 * J * K * Q);//
                ksi = (2 * K * I * B) - (2 * F * K * J) - (2 * G * I * J) + (2 * J * J * H);//
                lyambda = (B * N2 * N2) + (D * J * J) - (2 * J * N2 * Q);//
                ksi = ksi / 2.0;
                gamma = gamma / 2.0;
                tetta = tetta / 2.0;

                angle = Math.Atan((2 * ksi) / (alpha - beta)) / 2;
                if ((alpha * beta - (ksi * ksi)) != 0)
                {
                    x0 = (-gamma * beta - (-tetta * ksi)) / (alpha * beta - (ksi * ksi));
                    y0 = (-tetta * alpha - (-gamma * ksi)) / (alpha * beta - (ksi * ksi));
                }
            }
            else if (K != 0)
            {
                alpha = (C * I * I) - (2 * K * H * I) + (A * K * K);//
                beta = (C * J * J) + (B * K * K) - (2 * J * G * K);//
                gamma = (2 * N3 * I * C) - (2 * H * K * N3) - (2 * I * K * R) + (2 * P * K * K);//
                tetta = (2 * K * K * Q) - (2 * G * K * N3) + (2 * C * J * N3) - (2 * J * K * R);//
                ksi = (2 * C * I * J) - (2 * G * K * I) - (2 * H * K * J) + (2 * K * K * F);//
                lyambda = (C * N3 * N3) + (D * K * K) - (2 * K * N3 * R);//
                ksi = ksi / 2.0;
                gamma = gamma / 2.0;
                tetta = tetta / 2.0;

                angle = Math.Atan((2 * ksi) / (alpha - beta)) / 2;
                if ((alpha * beta - (ksi * ksi)) != 0)
                {
                    x0 = (-gamma * beta - (-tetta * ksi)) / (alpha * beta - (ksi * ksi));
                    y0 = (-tetta * alpha - (-gamma * ksi)) / (alpha * beta - (ksi * ksi));
                }
            }
            DetSurface();
        }

        #endregion

        #region Apply Button
        private void Apply_Click(object sender, EventArgs e)
        {
            if ((textA.Text == "0") && (textB.Text == "0") && (textC.Text == "0") && (textF.Text == "0") && (textG.Text == "0") && (textH.Text == "0"))
                return;
            A = Convert.ToDouble(textA.Text);
            B = Convert.ToDouble(textB.Text);
            C = Convert.ToDouble(textC.Text);
            F = Convert.ToDouble(textF.Text) / 2.0;
            G = Convert.ToDouble(textG.Text) / 2.0;
            H = Convert.ToDouble(textH.Text) / 2.0;
            P = Convert.ToDouble(textP.Text) / 2.0;
            Q = Convert.ToDouble(textQ.Text) / 2.0;
            R = Convert.ToDouble(textR.Text) / 2.0;
            D = Convert.ToDouble(textD.Text);
            Tick = Convert.ToDouble(textTick.Text);
            MaxTrack = Convert.ToInt32(textMaxtrack.Text);
            trackBar1.Maximum = MaxTrack;
            trackBar1.Minimum = -MaxTrack;
            trackBar2.Maximum = MaxTrack;
            trackBar2.Minimum = -MaxTrack;
            trackBar3.Maximum = MaxTrack;
            trackBar3.Minimum = -MaxTrack;
            Paint_All();
        }
        #endregion

        #region Paint Function 1
        private void Plot1_Paint()
        {
            try
            {
                I = 1; J = 0; K = 0;// N = 0;
                CalculateFunction();

                Bitmap btmp = new Bitmap(this.Width, this.Height);
                Plot1.Image = btmp;
                Graphics gr = Graphics.FromImage(Plot1.Image);

                #region Pens
                Plot1.BackColor = Color.FromArgb(pbc_r, pbc_g, pbc_b);
                Pen MainAxesPen = new Pen(Color.FromArgb(mac_r, mac_g, mac_b), 1);
                Pen NewAxesPen = new Pen(Color.FromArgb(nac_r, nac_g, nac_b), 1);
                SolidBrush NumsPen = new SolidBrush(Color.FromArgb(nc_r, nc_g, nc_b));
                Pen RotatedAxesPen = new Pen(Color.FromArgb(rac_r, rac_g, rac_b), 1);
                SolidBrush FigurePen = new SolidBrush(Color.FromArgb(pc_r, pc_g, pc_b));
                Pen GridPen = new Pen(Color.FromArgb(gc_r, gc_g, gc_b), 1);
                SolidBrush CrossingPointsPen = new SolidBrush(Color.FromArgb(cpc_r, cpc_g, cpc_b));
                #endregion

                #region Main Axes
                Point p1 = new Point(OX, 0);
                Point p2 = new Point(OX, this.Height);
                gr.DrawLine(MainAxesPen, p1, p2);
                p1 = new Point(0, OY);
                p2 = new Point(this.Width, OY);
                gr.DrawLine(MainAxesPen, p1, p2);
                #endregion

                #region Drawing 0, X, Y, Z
                String drawString = "0";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 11, OY);
                drawString = "Y";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot1.Width - 20, OY - 20);
                drawString = "Z";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX + 5, 13);
                #endregion

                #region Drawing Nums And Grid
                if (scale1 > 10)
                {
                    int j = 1;
                    for (int i = OX; i < this.Width; i += scale1)
                    {
                        //grid
                        if ((i != OX) && (GridCheck))
                        {
                            p1 = new Point(i, 0);
                            p2 = new Point(i, OY);
                            gr.DrawLine(GridPen, p1, p2);

                            p1 = new Point(i, OY + 20);
                            p2 = new Point(i, this.Height);
                            gr.DrawLine(GridPen, p1, p2);
                        }
                        if (!HideNumbers)
                        {
                            //lines
                            p1 = new Point(i, OY - 4);
                            p2 = new Point(i, OY + 4);
                            gr.DrawLine(MainAxesPen, p1, p2);
                            //nums
                            drawString = j.ToString();
                            if (j > 9)
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale1 - 7, OY + 5);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale1 - 3, OY + 5);
                            j++;
                        }
                    }
                    j = -1;
                    for (int i = OX; i > 0; i -= scale1)
                    {
                        //grid
                        if ((i != OX) && (GridCheck))
                        {
                            p1 = new Point(i, 0);
                            p2 = new Point(i, OY);
                            gr.DrawLine(GridPen, p1, p2);

                            p1 = new Point(i, OY + 20);
                            p2 = new Point(i, this.Height);
                            gr.DrawLine(GridPen, p1, p2);
                        }
                        if (!HideNumbers)
                        {

                            //lines
                            p1 = new Point(i, OY - 4);
                            p2 = new Point(i, OY + 4);
                            gr.DrawLine(MainAxesPen, p1, p2);
                            //nums
                            drawString = j.ToString();
                            if (j < -9)
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale1 - 10, OY + 5);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale1 - 7, OY + 5);
                            j--;
                        }
                    }
                    j = 1;
                    for (int i = OY; i > 0; i -= scale1)
                    {
                        //grid
                        if ((i != OY) && (GridCheck))
                        {
                            p1 = new Point(0, i);
                            p2 = new Point(OX - 20, i);
                            gr.DrawLine(GridPen, p1, p2);

                            p1 = new Point(OX, i);
                            p2 = new Point(this.Width, i);
                            gr.DrawLine(GridPen, p1, p2);
                        }
                        if (!HideNumbers)
                        {
                            //lines
                            p1 = new Point(OX - 4, i);
                            p2 = new Point(OX + 4, i);
                            gr.DrawLine(MainAxesPen, p1, p2);
                            //nums
                            drawString = j.ToString();
                            if (j > 9)
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i - scale1 - 9);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 16, i - scale1 - 9);
                            j++;
                        }
                    }
                    j = -1;
                    for (int i = OY; i < this.Height; i += scale1)
                    {
                        //grid
                        if ((i != OY) && (GridCheck))
                        {
                            p1 = new Point(0, i);
                            p2 = new Point(OX - 25, i);
                            gr.DrawLine(GridPen, p1, p2);

                            p1 = new Point(OX, i);
                            p2 = new Point(this.Width, i);
                            gr.DrawLine(GridPen, p1, p2);
                        }
                        if (!HideNumbers)
                        {
                            //lines
                            p1 = new Point(OX - 4, i);
                            p2 = new Point(OX + 4, i);
                            gr.DrawLine(MainAxesPen, p1, p2);
                            //nums
                            drawString = j.ToString();
                            if (j < -9)
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 24, i + scale1 - 9);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i + scale1 - 9);
                            j--;
                        }
                    }
                }
                #endregion

                #region Drawing Figure
                if (alpha != 0)
                {
                    y = -length;
                    while (y < length)
                    {
                        d = Math.Pow(2 * ksi * y + 2 * gamma, 2) - (4 * alpha * (beta * y * y + 2 * tetta * y + lyambda));
                        if (d >= 0)
                        {
                            x1 = (-1.0 * (2 * ksi * y + 2 * gamma) + Math.Sqrt(d)) / (2 * alpha);
                            x2 = (-1.0 * (2 * ksi * y + 2 * gamma) - Math.Sqrt(d)) / (2 * alpha);
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale1), OY - (int)(y * scale1), 1, 1));
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x2 * scale1), OY - (int)(y * scale1), 1, 1));
                        }
                        y += accuracy;
                    }
                }
                else if (beta != 0)
                {
                    x = -length;
                    while (x < length)
                    {
                        d = Math.Pow(2 * ksi * x + 2 * tetta, 2) - (4 * beta * (alpha * x * x + 2 * gamma * x + lyambda));
                        if (d >= 0)
                        {
                            y1 = (-1.0 * (2 * ksi * x + 2 * tetta) + Math.Sqrt(d)) / (2 * beta);
                            y2 = (-1.0 * (2 * ksi * x + 2 * tetta) - Math.Sqrt(d)) / (2 * beta);
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale1), OY - (int)(y1 * scale1), 1, 1));
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale1), OY - (int)(y2 * scale1), 1, 1));
                        }
                        x += accuracy;
                    }
                }
                else
                {
                    x = -length;
                    while (x < length)
                    {
                        if (tetta != 0 || ksi != 0)
                        {
                            y1 = (-lyambda - 2 * gamma * x) / (2 * ksi * x + 2 * tetta);
                            if (x < x0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale1), OY - (int)(y1 * scale1), 1, 1));
                            }
                            if ((x + accuracy > x0) && (x - accuracy < x0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > x0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale1), OY - (int)(y1 * scale1), 1, 1));
                            }
                            x += accuracy;
                        }
                        else
                        {
                            x1 = (-lyambda - 2 * tetta * x) / (2 * ksi * x + 2 * gamma);
                            if (x < y0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale1), OY - (int)(x * scale1), 1, 1));
                            }
                            if ((x + accuracy > y0) && (x - accuracy < y0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > y0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale1), OY - (int)(x * scale1), 1, 1));
                            }
                            x += accuracy;
                        }
                    }
                }
                #endregion


                gr.Dispose();
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Paint Function 2
        private void Plot2_Paint()
        {
            try
            {
                I = 0; J = 1; K = 0;// N = 0;
                CalculateFunction();

                Bitmap btmp1 = new Bitmap(this.Width, this.Height);
                Plot2.Image = btmp1;
                Graphics gr = Graphics.FromImage(Plot2.Image);

                #region Pens
                Plot2.BackColor = Color.FromArgb(pbc_r, pbc_g, pbc_b);
                Pen MainAxesPen = new Pen(Color.FromArgb(mac_r, mac_g, mac_b), 1);
                Pen NewAxesPen = new Pen(Color.FromArgb(nac_r, nac_g, nac_b), 1);
                SolidBrush NumsPen = new SolidBrush(Color.FromArgb(nc_r, nc_g, nc_b));
                Pen RotatedAxesPen = new Pen(Color.FromArgb(rac_r, rac_g, rac_b), 1);
                SolidBrush FigurePen = new SolidBrush(Color.FromArgb(pc_r, pc_g, pc_b));
                Pen GridPen = new Pen(Color.FromArgb(gc_r, gc_g, gc_b), 1);
                SolidBrush CrossingPointsPen = new SolidBrush(Color.FromArgb(cpc_r, cpc_g, cpc_b));
                #endregion

                #region Main Axes
                Point p1 = new Point(OX, 0);
                Point p2 = new Point(OX, this.Height);
                gr.DrawLine(MainAxesPen, p1, p2);
                p1 = new Point(0, OY);
                p2 = new Point(this.Width, OY);
                gr.DrawLine(MainAxesPen, p1, p2);
                #endregion

                #region Drawing 0, X, Y, Z
                String drawString = "0";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 11, OY);
                drawString = "X";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot2.Width - 20, OY - 20);
                drawString = "Z";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX + 5, 13);
                #endregion

                #region Drawing Nums And Grid
                if (scale2 > 10)
                {
                    int j = 1;
                    for (int i = OX; i < this.Width; i += scale2)
                    {
                        //grid
                        if ((i != OX) && (GridCheck))
                        {
                            p1 = new Point(i, 0);
                            p2 = new Point(i, OY);
                            gr.DrawLine(GridPen, p1, p2);

                            p1 = new Point(i, OY + 20);
                            p2 = new Point(i, this.Height);
                            gr.DrawLine(GridPen, p1, p2);
                        }
                        if (!HideNumbers)
                        {
                            //lines
                            p1 = new Point(i, OY - 4);
                            p2 = new Point(i, OY + 4);
                            gr.DrawLine(MainAxesPen, p1, p2);
                            //nums
                            drawString = j.ToString();
                            if (j > 9)
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale2 - 7, OY + 5);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale2 - 3, OY + 5);
                            j++;
                        }
                    }
                    j = -1;
                    for (int i = OX; i > 0; i -= scale2)
                    {
                        //grid
                        if ((i != OX) && (GridCheck))
                        {
                            p1 = new Point(i, 0);
                            p2 = new Point(i, OY);
                            gr.DrawLine(GridPen, p1, p2);

                            p1 = new Point(i, OY + 20);
                            p2 = new Point(i, this.Height);
                            gr.DrawLine(GridPen, p1, p2);
                        }
                        if (!HideNumbers)
                        {

                            //lines
                            p1 = new Point(i, OY - 4);
                            p2 = new Point(i, OY + 4);
                            gr.DrawLine(MainAxesPen, p1, p2);
                            //nums
                            drawString = j.ToString();
                            if (j < -9)
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale2 - 10, OY + 5);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale2 - 7, OY + 5);
                            j--;
                        }
                    }
                    j = 1;
                    for (int i = OY; i > 0; i -= scale2)
                    {
                        //grid
                        if ((i != OY) && (GridCheck))
                        {
                            p1 = new Point(0, i);
                            p2 = new Point(OX - 20, i);
                            gr.DrawLine(GridPen, p1, p2);

                            p1 = new Point(OX, i);
                            p2 = new Point(this.Width, i);
                            gr.DrawLine(GridPen, p1, p2);
                        }
                        if (!HideNumbers)
                        {
                            //lines
                            p1 = new Point(OX - 4, i);
                            p2 = new Point(OX + 4, i);
                            gr.DrawLine(MainAxesPen, p1, p2);
                            //nums
                            drawString = j.ToString();
                            if (j > 9)
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i - scale2 - 9);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 16, i - scale2 - 9);
                            j++;
                        }
                    }
                    j = -1;
                    for (int i = OY; i < this.Height; i += scale2)
                    {
                        //grid
                        if ((i != OY) && (GridCheck))
                        {
                            p1 = new Point(0, i);
                            p2 = new Point(OX - 25, i);
                            gr.DrawLine(GridPen, p1, p2);

                            p1 = new Point(OX, i);
                            p2 = new Point(this.Width, i);
                            gr.DrawLine(GridPen, p1, p2);
                        }
                        if (!HideNumbers)
                        {
                            //lines
                            p1 = new Point(OX - 4, i);
                            p2 = new Point(OX + 4, i);
                            gr.DrawLine(MainAxesPen, p1, p2);
                            //nums
                            drawString = j.ToString();
                            if (j < -9)
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 24, i + scale2 - 9);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i + scale2 - 9);
                            j--;
                        }
                    }
                }
                #endregion

                #region Drawing Figure
                if (alpha != 0)
                {
                    y = -length;
                    while (y < length)
                    {
                        d = Math.Pow(2 * ksi * y + 2 * gamma, 2) - (4 * alpha * (beta * y * y + 2 * tetta * y + lyambda));
                        if (d >= 0)
                        {
                            x1 = (-1.0 * (2 * ksi * y + 2 * gamma) + Math.Sqrt(d)) / (2 * alpha);
                            x2 = (-1.0 * (2 * ksi * y + 2 * gamma) - Math.Sqrt(d)) / (2 * alpha);
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale2), OY - (int)(y * scale2), 1, 1));
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x2 * scale2), OY - (int)(y * scale2), 1, 1));
                        }
                        y += accuracy;
                    }
                }
                else if (beta != 0)
                {
                    x = -length;
                    while (x < length)
                    {
                        d = Math.Pow(2 * ksi * x + 2 * tetta, 2) - (4 * beta * (alpha * x * x + 2 * gamma * x + lyambda));
                        if (d >= 0)
                        {
                            y1 = (-1.0 * (2 * ksi * x + 2 * tetta) + Math.Sqrt(d)) / (2 * beta);
                            y2 = (-1.0 * (2 * ksi * x + 2 * tetta) - Math.Sqrt(d)) / (2 * beta);
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale2), OY - (int)(y1 * scale2), 1, 1));
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale2), OY - (int)(y2 * scale2), 1, 1));
                        }
                        x += accuracy;
                    }
                }
                else
                {
                    x = -length;
                    while (x < length)
                    {
                        if (tetta != 0 || ksi != 0)
                        {
                            y1 = (-lyambda - 2 * gamma * x) / (2 * ksi * x + 2 * tetta);
                            if (x < x0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale2), OY - (int)(y1 * scale2), 1, 1));
                            }
                            if ((x + accuracy > x0) && (x - accuracy < x0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > x0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale2), OY - (int)(y1 * scale2), 1, 1));
                            }
                            x += accuracy;
                        }
                        else
                        {
                            x1 = (-lyambda - 2 * tetta * x) / (2 * ksi * x + 2 * gamma);
                            if (x < y0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale2), OY - (int)(x * scale2), 1, 1));
                            }
                            if ((x + accuracy > y0) && (x - accuracy < y0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > y0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale2), OY - (int)(x * scale2), 1, 1));
                            }
                            x += accuracy;
                        }
                    }
                }
                #endregion


                gr.Dispose();
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Paint Function 3
        private void Plot3_Paint()
        {
            try
            {
                I = 0; J = 0; K = 1;// N = 0;
                CalculateFunction();

                Bitmap btmp2 = new Bitmap(this.Width, this.Height);
                Plot3.Image = btmp2;
                Graphics gr = Graphics.FromImage(Plot3.Image);

                #region Pens
                Plot3.BackColor = Color.FromArgb(pbc_r, pbc_g, pbc_b);
                Pen MainAxesPen = new Pen(Color.FromArgb(mac_r, mac_g, mac_b), 1);
                Pen NewAxesPen = new Pen(Color.FromArgb(nac_r, nac_g, nac_b), 1);
                SolidBrush NumsPen = new SolidBrush(Color.FromArgb(nc_r, nc_g, nc_b));
                Pen RotatedAxesPen = new Pen(Color.FromArgb(rac_r, rac_g, rac_b), 1);
                SolidBrush FigurePen = new SolidBrush(Color.FromArgb(pc_r, pc_g, pc_b));
                Pen GridPen = new Pen(Color.FromArgb(gc_r, gc_g, gc_b), 1);
                SolidBrush CrossingPointsPen = new SolidBrush(Color.FromArgb(cpc_r, cpc_g, cpc_b));
                #endregion

                #region Main Axes
                Point p1 = new Point(OX, 0);
                Point p2 = new Point(OX, this.Height);
                gr.DrawLine(MainAxesPen, p1, p2);
                p1 = new Point(0, OY);
                p2 = new Point(this.Width, OY);
                gr.DrawLine(MainAxesPen, p1, p2);
                #endregion

                #region Drawing 0, X, Y, Z
                String drawString = "0";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 11, OY);
                drawString = "X";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot3.Width - 20, OY - 20);
                drawString = "Y";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX + 5, 13);
                #endregion

                #region Drawing Nums And Grid
                if (scale3 > 10)
                {
                    int j = 1;
                    for (int i = OX; i < this.Width; i += scale3)
                    {
                        //grid
                        if ((i != OX) && (GridCheck))
                        {
                            p1 = new Point(i, 0);
                            p2 = new Point(i, OY);
                            gr.DrawLine(GridPen, p1, p2);

                            p1 = new Point(i, OY + 20);
                            p2 = new Point(i, this.Height);
                            gr.DrawLine(GridPen, p1, p2);
                        }
                        if (!HideNumbers)
                        {
                            //lines
                            p1 = new Point(i, OY - 4);
                            p2 = new Point(i, OY + 4);
                            gr.DrawLine(MainAxesPen, p1, p2);
                            //nums
                            drawString = j.ToString();
                            if (j > 9)
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale3 - 7, OY + 5);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale3 - 3, OY + 5);
                            j++;
                        }
                    }
                    j = -1;
                    for (int i = OX; i > 0; i -= scale3)
                    {
                        //grid
                        if ((i != OX) && (GridCheck))
                        {
                            p1 = new Point(i, 0);
                            p2 = new Point(i, OY);
                            gr.DrawLine(GridPen, p1, p2);

                            p1 = new Point(i, OY + 20);
                            p2 = new Point(i, this.Height);
                            gr.DrawLine(GridPen, p1, p2);
                        }
                        if (!HideNumbers)
                        {

                            //lines
                            p1 = new Point(i, OY - 4);
                            p2 = new Point(i, OY + 4);
                            gr.DrawLine(MainAxesPen, p1, p2);
                            //nums
                            drawString = j.ToString();
                            if (j < -9)
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale3 - 10, OY + 5);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale3 - 7, OY + 5);
                            j--;
                        }
                    }
                    j = 1;
                    for (int i = OY; i > 0; i -= scale3)
                    {
                        //grid
                        if ((i != OY) && (GridCheck))
                        {
                            p1 = new Point(0, i);
                            p2 = new Point(OX - 20, i);
                            gr.DrawLine(GridPen, p1, p2);

                            p1 = new Point(OX, i);
                            p2 = new Point(this.Width, i);
                            gr.DrawLine(GridPen, p1, p2);
                        }
                        if (!HideNumbers)
                        {
                            //lines
                            p1 = new Point(OX - 4, i);
                            p2 = new Point(OX + 4, i);
                            gr.DrawLine(MainAxesPen, p1, p2);
                            //nums
                            drawString = j.ToString();
                            if (j > 9)
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i - scale3 - 9);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 16, i - scale3 - 9);
                            j++;
                        }
                    }
                    j = -1;
                    for (int i = OY; i < this.Height; i += scale3)
                    {
                        //grid
                        if ((i != OY) && (GridCheck))
                        {
                            p1 = new Point(0, i);
                            p2 = new Point(OX - 25, i);
                            gr.DrawLine(GridPen, p1, p2);

                            p1 = new Point(OX, i);
                            p2 = new Point(this.Width, i);
                            gr.DrawLine(GridPen, p1, p2);
                        }
                        if (!HideNumbers)
                        {
                            //lines
                            p1 = new Point(OX - 4, i);
                            p2 = new Point(OX + 4, i);
                            gr.DrawLine(MainAxesPen, p1, p2);
                            //nums
                            drawString = j.ToString();
                            if (j < -9)
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 24, i + scale3 - 9);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i + scale3 - 9);
                            j--;
                        }
                    }
                }
                #endregion

                #region Drawing Figure
                if (alpha != 0)
                {
                    y = -length;
                    while (y < length)
                    {
                        d = Math.Pow(2 * ksi * y + 2 * gamma, 2) - (4 * alpha * (beta * y * y + 2 * tetta * y + lyambda));
                        if (d >= 0)
                        {
                            x1 = (-1.0 * (2 * ksi * y + 2 * gamma) + Math.Sqrt(d)) / (2 * alpha);
                            x2 = (-1.0 * (2 * ksi * y + 2 * gamma) - Math.Sqrt(d)) / (2 * alpha);
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale3), OY - (int)(y * scale3), 1, 1));
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x2 * scale3), OY - (int)(y * scale3), 1, 1));
                        }
                        y += accuracy;
                    }
                }
                else if (beta != 0)
                {
                    x = -length;
                    while (x < length)
                    {
                        d = Math.Pow(2 * ksi * x + 2 * tetta, 2) - (4 * beta * (alpha * x * x + 2 * gamma * x + lyambda));
                        if (d >= 0)
                        {
                            y1 = (-1.0 * (2 * ksi * x + 2 * tetta) + Math.Sqrt(d)) / (2 * beta);
                            y2 = (-1.0 * (2 * ksi * x + 2 * tetta) - Math.Sqrt(d)) / (2 * beta);
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale3), OY - (int)(y1 * scale3), 1, 1));
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale3), OY - (int)(y2 * scale3), 1, 1));
                        }
                        x += accuracy;
                    }
                }
                else
                {
                    x = -length;
                    while (x < length)
                    {
                        if (tetta != 0 || ksi != 0)
                        {
                            y1 = (-lyambda - 2 * gamma * x) / (2 * ksi * x + 2 * tetta);
                            if (x < x0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale3), OY - (int)(y1 * scale3), 1, 1));
                            }
                            if ((x + accuracy > x0) && (x - accuracy < x0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > x0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale3), OY - (int)(y1 * scale3), 1, 1));
                            }
                            x += accuracy;
                        }
                        else
                        {
                            x1 = (-lyambda - 2 * tetta * x) / (2 * ksi * x + 2 * gamma);
                            if (x < y0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale3), OY - (int)(x * scale3), 1, 1));
                            }
                            if ((x + accuracy > y0) && (x - accuracy < y0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > y0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale3), OY - (int)(x * scale3), 1, 1));
                            }
                            x += accuracy;
                        }
                    }
                }
                #endregion


                gr.Dispose();
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Read From File
        private void FileReading()
        {
            String line;
            int operation = 0;
            try
            {
                StreamReader file = new StreamReader("GeneralEquation_SOTSO.txt");
                line = file.ReadLine();
                while (line != null)
                {
                    if (operation == 0)
                        textA.Text = line;
                    if (operation == 1)
                        textB.Text = line;
                    if (operation == 2)
                        textC.Text = line;
                    if (operation == 3)
                        textF.Text = line;
                    if (operation == 4)
                        textG.Text = line;
                    if (operation == 5)
                        textH.Text = line;
                    if (operation == 6)
                        textP.Text = line;
                    if (operation == 7)
                        textQ.Text = line;
                    if (operation == 8)
                        textR.Text = line;
                    if (operation == 9)
                        textD.Text = line;
                    if (operation == 10)
                        textAccuracy.Text = line;
                    if (operation == 11)
                        textLength.Text = line;
                    if (operation == 12)
                        scale1 = Convert.ToInt32(line);
                    if (operation == 13)
                        scale2 = Convert.ToInt32(line);
                    if (operation == 14)
                        scale3 = Convert.ToInt32(line);
                    if (operation == 15)
                        trackBar1.Value = Convert.ToInt32(line);
                    if (operation == 16)
                        trackBar2.Value = Convert.ToInt32(line);
                    if (operation == 17)
                        trackBar3.Value = Convert.ToInt32(line);
                    if (operation == 18)
                        Tick = Convert.ToDouble(line);
                    if (operation == 19)
                        MaxTrack = Convert.ToInt32(line);
                    line = file.ReadLine();
                    operation++;
                }
                file.Close();
                A = Convert.ToDouble(textA.Text);
                B = Convert.ToDouble(textB.Text);
                C = Convert.ToDouble(textC.Text);
                F = Convert.ToDouble(textF.Text) / 2.0;
                G = Convert.ToDouble(textG.Text) / 2.0;
                H = Convert.ToDouble(textH.Text) / 2.0;
                P = Convert.ToDouble(textP.Text) / 2.0;
                Q = Convert.ToDouble(textQ.Text) / 2.0;
                R = Convert.ToDouble(textR.Text) / 2.0;
                D = Convert.ToDouble(textD.Text);
                accuracy = Convert.ToDouble(textAccuracy.Text);
                length = Convert.ToDouble(textLength.Text);
                N1 = Tick * trackBar1.Value;
                N2 = Tick * trackBar2.Value;
                N3 = Tick * trackBar3.Value;
                trackBar1.Maximum = MaxTrack;
                trackBar1.Minimum = -MaxTrack;
                trackBar2.Maximum = MaxTrack;
                trackBar2.Minimum = -MaxTrack;
                trackBar3.Maximum = MaxTrack;
                trackBar3.Minimum = -MaxTrack;
                textTick.Text = Convert.ToString(Tick);
                textMaxtrack.Text = Convert.ToString(MaxTrack);
            }
            catch
            {
                return;
            }
            operation = 0;
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
            label9.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label10.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label11.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label12.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            Apply.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            ClosingForm.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
        }
        #endregion

        #region Mouse Things
        void m_MouseWheel1(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if ((scale1 == 1) || (scale1 == 7) || (scale1 == 4))
                    scale1 += 3;
                else
                    scale1 += 5;
            }
            else
            {
                if (scale1 > 10)
                    scale1 -= 5;
                else if ((scale1 == 10) || (scale1 == 7) || (scale1 == 4))
                    scale1 -= 3;
                else if (scale1 == 1)
                    return;
            }
            Plot1_Paint();
        }
        void m_MouseWheel2(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if ((scale2 == 1) || (scale2 == 7) || (scale2 == 4))
                    scale2 += 3;
                else
                    scale2 += 5;
            }
            else
            {
                if (scale2 > 10)
                    scale2 -= 5;
                else if ((scale2 == 10) || (scale2 == 7) || (scale2 == 4))
                    scale2 -= 3;
                else if (scale2 == 1)
                    return;
            }
            Plot2_Paint();
        }
        void m_MouseWheel3(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if ((scale3 == 1) || (scale3 == 7) || (scale3 == 4))
                    scale3 += 3;
                else
                    scale3 += 5;
            }
            else
            {
                if (scale3 > 10)
                    scale3 -= 5;
                else if ((scale3 == 10) || (scale3 == 7) || (scale3 == 4))
                    scale3 -= 3;
                else if (scale3 == 1)
                    return;
            }
            Plot3_Paint();
        }
        #endregion

        #region Close Button
        private void ClosingForm_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter file = new StreamWriter("GeneralEquation_SOTSO.txt");
                file.WriteLine(A);
                file.WriteLine(B);
                file.WriteLine(C);
                file.WriteLine(2 * F);
                file.WriteLine(2 * G);
                file.WriteLine(2 * H);
                file.WriteLine(2 * P);
                file.WriteLine(2 * Q);
                file.WriteLine(2 * R);
                file.WriteLine(D);
                file.WriteLine(accuracy);
                file.WriteLine(length);
                file.WriteLine(scale1);
                file.WriteLine(scale2);
                file.WriteLine(scale3);
                file.WriteLine(trackBar1.Value);
                file.WriteLine(trackBar2.Value);
                file.WriteLine(trackBar3.Value);
                file.WriteLine(Tick);
                file.WriteLine(MaxTrack);
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

        #region Trackbar 1
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            N1 = Tick * trackBar1.Value;
            Plot1_Paint();
        }
        #endregion

        #region Trackbar 2
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            N2 = Tick * trackBar2.Value;
            Plot2_Paint();
        }
        #endregion

        #region Trackbar 3
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            N3 = Tick * trackBar3.Value;
            Plot3_Paint();
        }
        #endregion

        #region Determine Surface
        private void DetSurface()
        {
            if (sigma != 0)
            {
                if ((tau2 > 0) && (tau1 * sigma > 0))
                {
                    if (delta < 0)
                        surface = "Ellipsoid";
                    else if (delta > 0)
                        surface = "Imaginary Ellipsoid";
                    else if (delta == 0)
                        surface = "Imaginary Cone";
                }
                else if ((tau2 <= 0) || (tau1 * sigma <= 0))
                {
                    if (delta < 0)
                        surface = "Two-Strip Hyperboloid";
                    else if (delta > 0)
                        surface = "Single-sheet hyperboloid";
                    else if (delta == 0)
                        surface = "Cone";
                }
            }
            else if (sigma == 0)
            {
                if (delta < 0)
                    surface = "Elliptical Paraboloid";
                else if (delta > 0)
                    surface = "Hyperbolic parabaloid";
                else if (delta == 0)
                {
                    if (tau2 > 0)
                    {
                        if (tau1 * k2 < 0)
                            surface = "Elliptical Cylinder";
                        else if (tau1 * k2 > 0)
                            surface = "Imaginary Elliptical Cylinder";
                        else if (k2 == 0)
                            surface = "Pair of imaginary intersecting planes";
                    }
                    else if (tau2 < 0)
                    {
                        if (k2 != 0)
                            surface = "Hyperbolic Cylinder";
                        else if (k2 == 0)
                            surface = "Pair of intersecting planes";
                    }
                    else if (tau2 == 0)
                    {
                        if (k2 != 0)
                            surface = "Parabolic Cylinder";
                        else if (k2 == 0)
                        {
                            if (k1 < 0)
                                surface = "Pair of parallel planes";
                            else if (k1 > 0)
                                surface = "Pair of imaginary parallel planes";
                            else if (k1 == 0)
                                surface = "Pair of coincident planes";
                        }
                    }
                }
            }
            textSurface.Text = surface;
        }
        #endregion

        #region Key Press
        private void Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | (e.KeyChar == Convert.ToChar("-")) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
        private void textLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
        private void textAccuracy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
        #endregion

        #region Paint All
        private void Paint_All()
        {
            Plot1_Paint();
            Plot2_Paint();
            Plot3_Paint();
        }
        #endregion
    }
}
