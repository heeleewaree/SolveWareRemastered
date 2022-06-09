using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SolveWareRemastered
{
    public partial class PlaneSurfaceIntersectionForm : Form
    {
        public PlaneSurfaceIntersectionForm()
        {
            InitializeComponent();
            FileReading();
            CustomApp();
            Plot.MouseWheel += new MouseEventHandler(m_MouseWheel);
            Plot.MouseMove += new MouseEventHandler(mouseMove1);
            Plot.MouseDown += new MouseEventHandler(mouseDown1);
            Plot.MouseUp += new MouseEventHandler(mouseUp1);
        }

        #region Global Variables
        double A, B, C, F, G, H, P, Q, R, D;
        double I, J, K, N;
        double accuracy, length;
        double textOx1, textOx2, textOy1, textOy2;
        bool GridCheck = false;
        bool CrossingPoints = true;
        bool HideNumbers = false;
        bool Ellipse = false;
        int OX = 902 / 2, OY = 509 / 2;
        double tau1, tau2, sigma, delta, k1, k2;
        double alpha, ksi, beta, gamma, tetta, lyambda;
        double Invariant3, Invariant2, Invariant1, K105;
        double angle, x0, y0;
        String figure, result, surface;
        int scale = 40;
        double x, y, x1, x2, y1, y2, d;
        bool status = false;
        int CurX;
        int CurY;
        double Ox1, Ox2, Oy1, Oy2;
        bool check = true;
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

        #region CheckBox Of Crossing Points
        private void checkCrossingPoints_Click(object sender, EventArgs e)
        {
            if (CrossingPoints == false)
                CrossingPoints = true;
            else
                CrossingPoints = false;
        }
        #endregion

        #region CheckBox Of Hide Numbers
        private void checkHideNums_Click(object sender, EventArgs e)
        {
            if (HideNumbers == false)
                HideNumbers = true;
            else
                HideNumbers = false;
        }
        #endregion

        #region CheckBox Of Grid
        private void checkGrid_Click(object sender, EventArgs e)
        {
            if (GridCheck == false)
                GridCheck = true;
            else
                GridCheck = false;
        }
        #endregion

        #region CheckBox Of Reduce
        private void around_Click(object sender, EventArgs e)
        {
            if (check == false)
                check = true;
            else
                check = false;
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
                I = Convert.ToDouble(fA.Text);
                J = Convert.ToDouble(fB.Text);
                K = Convert.ToDouble(fC.Text);
                N = Convert.ToDouble(fD.Text);
                accuracy = Convert.ToDouble(textAccuracy.Text);
                length = Convert.ToDouble(textLength.Text);
            }
            catch
            {
                return;
            }
            if ((A == 0) && (B == 0) && (C == 0) && (F == 0) && (G == 0) && (H == 0))
                return;
            if ((I == 0) && (J == 0) && (K == 0))
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
                gamma = (2 * I * I * Q) - (2 * F * I * N) - (2 * I * J * P) + (2 * A * J * N);//
                tetta = (2 * I * I * R) - (2 * H * I * N) + (2 * A * K * N) - (2 * I * K * P);//
                ksi = (2 * G * I * I) - (2 * H * I * J) - (2 * F * I * K) + (2 * A * J * K);//
                lyambda = (D * I * I) + (A * N * N) - (2 * I * N * P);//
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
                gamma = (2 * N * I * B) - (2 * F * J * N) - (2 * I * J * Q) + (2 * P * J * J);//
                tetta = (2 * J * J * R) - (2 * G * J * N) + (2 * B * K * N) - (2 * J * K * Q);//
                ksi = (2 * K * I * B) - (2 * F * K * J) - (2 * G * I * J) + (2 * J * J * H);//
                lyambda = (B * N * N) + (D * J * J) - (2 * J * N * Q);//
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
                gamma = (2 * N * I * C) - (2 * H * K * N) - (2 * I * K * R) + (2 * P * K * K);//
                tetta = (2 * K * K * Q) - (2 * G * K * N) + (2 * C * J * N) - (2 * J * K * R);//
                ksi = (2 * C * I * J) - (2 * G * K * I) - (2 * H * K * J) + (2 * K * K * F);//
                lyambda = (C * N * N) + (D * K * K) - (2 * K * N * R);//
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
            // around function
            if (check)
            {
                for (int u = 10000; u > 1; u--)
                {
                    while ((alpha / u == (int)(alpha / u)) && (beta / u == (int)(beta / u)) && ((2 * ksi) / u == (int)(2 * ksi / u)) && ((2 * gamma) / u == (int)(2 * gamma / u)) && ((2 * tetta) / u == (int)(2 * tetta / u)) && (lyambda / u == (int)(lyambda / u)))
                    {
                        alpha = alpha / u;
                        beta = beta / u;
                        gamma = gamma / u;
                        tetta = tetta / u;
                        ksi = ksi / u;
                        lyambda = lyambda / u;
                    }
                }
            }
            // change signs
            if ((alpha < 0) && (beta < 0))
            {
                alpha = -alpha;
                beta = -beta;
                ksi = -ksi;
                gamma = -gamma;
                tetta = -tetta;
                lyambda = -lyambda;
            }

            if (Math.Abs(alpha - beta) == 0)
                angle = 0;

            result = "";
            int i = 0;
            if (alpha != 0)
            {
                if (alpha != 1)
                {
                    if (alpha == -1)
                        result += "-";
                    else
                        result += Convert.ToString(alpha);
                }
                result += "x^2";
                i++;
            }
            if (ksi != 0)
            {
                //if (ksi > 0)
                {
                    if ((i != 0) && (ksi > 0))
                        result += "+";
                    if (2 * ksi != 1)
                    {
                        if (2 * ksi == -1)
                            result += "-";
                        else
                            result += Convert.ToString(2 * ksi);
                    }
                }
                //else
                //result += Convert.ToString(2 * ksi);
                result += "xy";
                i++;
            }
            if (beta != 0)
            {
                //if (beta > 0)
                {
                    if ((i != 0) && (beta > 0))
                        result += "+";
                    if (beta != 1)
                    {
                        if (beta == -1)
                            result += "-";
                        else
                            result += Convert.ToString(beta);
                    }
                }
                //else
                //result += Convert.ToString(beta);
                result += "y^2";
                i++;
            }
            if (gamma != 0)
            {
                //if (gamma > 0)
                {
                    if ((i != 0) && (gamma > 0))
                        result += "+";
                    if (2 * gamma != 1)
                    {
                        if (2 * gamma == -1)
                            result += "-";
                        else
                            result += Convert.ToString(2 * gamma);
                    }
                }
                //else
                //result += Convert.ToString(2 * gamma);
                result += "x";
                i++;
            }
            if (tetta != 0)
            {
                //if (tetta > 0)
                {
                    if ((i != 0) && (tetta > 0))
                        result += "+";
                    if (2 * tetta != 1)
                    {
                        if (2 * tetta == -1)
                            result += "-";
                        else
                            result += Convert.ToString(2 * tetta);
                    }
                }
                //else
                //result += Convert.ToString(2 * tetta);
                result += "y";
                i++;
            }
            if (lyambda != 0)
            {
                if (lyambda > 0)
                    result += "+";
                result += Convert.ToString(lyambda);
            }
            result += "=0";
            textResult.Text = result;
            Invariant1 = alpha + beta; // Invariant1
            Invariant2 = alpha * beta - (ksi * ksi); // Invariant2
            Invariant3 = (alpha * beta * lyambda) + (ksi * tetta * gamma) + (ksi * tetta * gamma) - ((gamma * gamma * beta) + (tetta * tetta * alpha) + (ksi * ksi * lyambda)); // Invariant3
            K105 = ((alpha * lyambda) - (gamma * gamma)) + ((beta * lyambda) - (tetta * tetta)); // K(B)
            DetFigure();
            DetSurface();
        }

        #endregion

        #region Ellipse Plane
        private void EllipsePlane()
        {
            if (Ellipse)
            {
                textEllipse.Text = "S = ";
                double g = 2.0 / (Math.Sqrt(4 * alpha * beta - (2 * ksi) * (2 * ksi)) / (-(Invariant3 / Invariant2)));
                if (g != 1)
                    textEllipse.Text += Convert.ToString(g) + "Pi";
                else
                    textEllipse.Text += "Pi";
            }
            else
                textEllipse.Text = "";
        }
        #endregion

        #region Determine Figure
        private void DetFigure()
        {
            if (Invariant2 != 0)
            {
                //Solve solve = new Solve();
                if (Invariant2 > 0)
                {
                    if (Invariant3 < 0)
                    {
                        figure = "Ellipse";
                        Ellipse = true;
                    }
                    else if (Invariant3 == 0)
                    {
                        figure = "Point (a pair of imaginary intersecting lines)";
                        Ellipse = false;
                    }
                    else if (Invariant3 > 0)
                    {
                        figure = "Imaginary ellipse";
                        Ellipse = false;
                    }
                }
                if (Invariant2 < 0)
                {
                    if (Invariant3 == 0)
                    {
                        figure = "A pair of intersecting straight lines";
                        Ellipse = false;
                    }
                    else if (Invariant3 != 0)
                    {
                        figure = "Hyperbola";
                        Ellipse = false;
                    }
                }
            }
            else if (Invariant2 == 0)
            {
                if (Invariant3 != 0)
                {
                    figure = "Parabola";
                    Ellipse = false;
                }
                else if (Invariant3 == 0)
                {
                    if (K105 < 0)
                    {
                        figure = "A pair of parallel straight lines";
                        Ellipse = false;
                    }
                    else if (K105 == 0)
                    {
                        figure = "Straight";
                        Ellipse = false;
                    }
                    else if (K105 > 0)
                    {
                        figure = "A pair of imaginary parallel lines";
                        Ellipse = false;
                    }
                }
            }
            textFigure.Text = figure;
            EllipsePlane();
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

        #region Paint Function
            private void Plot_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Bitmap btmp = new Bitmap(this.Width, this.Height);
                Plot.Image = btmp;
                Graphics gr = Graphics.FromImage(Plot.Image);

                #region Pens
                Plot.BackColor = Color.FromArgb(pbc_r, pbc_g, pbc_b);
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

                #region New Axes
                if (x0 != 0)
                {
                    p1 = new Point(OX + (int)(x0 * scale), 0);
                    p2 = new Point(OX + (int)(x0 * scale), 100 * OY);
                    gr.DrawLine(NewAxesPen, p1, p2);
                }
                if (y0 != 0)
                {
                    p1 = new Point(0, OY - (int)(y0 * scale));
                    p2 = new Point(100 * OX + (int)(x0 * scale), OY - (int)(y0 * scale));
                    gr.DrawLine(NewAxesPen, p1, p2);
                }
                #endregion

                #region Drawing 0, X, Y
                String drawString = "0";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 11, OY);
                drawString = "Xf";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot.Width - 20, OY - 20);
                drawString = "Yf";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX + 5, 13);
                #endregion

                #region Drawing Nums And Grid
                if (scale > 10)
                {
                    int j = 1;
                    for (int i = OX; i < this.Width; i += scale)
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
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale - 7, OY + 5);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i + scale - 3, OY + 5);
                            j++;
                        }
                    }
                    j = -1;
                    for (int i = OX; i > 0; i -= scale)
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
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale - 10, OY + 5);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, i - scale - 7, OY + 5);
                            j--;
                        }
                    }
                    j = 1;
                    for (int i = OY; i > 0; i -= scale)
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
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i - scale - 9);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 16, i - scale - 9);
                            j++;
                        }
                    }
                    j = -1;
                    for (int i = OY; i < this.Height; i += scale)
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
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 24, i + scale - 9);
                            else
                                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, OX - 20, i + scale - 9);
                            j--;
                        }
                    }
                }
                #endregion

                #region Rotated Axes
                if (ksi != 0)
                {
                    double m1, m2, n1, n2;

                    double XY2 = -this.Width;
                    double XY1 = 0;
                    m1 = XY1 * Math.Cos(angle) - XY2 * Math.Sin(angle); // rotated x0
                    m2 = XY1 * Math.Sin(angle) + XY2 * Math.Cos(angle); // rotated y0
                    XY2 = this.Width;
                    n1 = XY1 * Math.Cos(angle) - XY2 * Math.Sin(angle); // rotated x0
                    n2 = XY1 * Math.Sin(angle) + XY2 * Math.Cos(angle); // rotated y0
                    p1 = new Point(OX + (int)(x0 * scale) + (int)(m1 * scale), OY - (int)(y0 * scale) - (int)(m2 * scale));
                    p2 = new Point(OX + (int)(x0 * scale) + (int)(n1 * scale), OY - (int)(y0 * scale) - (int)(n2 * scale));
                    gr.DrawLine(RotatedAxesPen, p1, p2);

                    XY1 = -this.Width;
                    XY2 = 0;
                    m1 = XY1 * Math.Cos(angle) - XY2 * Math.Sin(angle); // rotated x0
                    m2 = XY1 * Math.Sin(angle) + XY2 * Math.Cos(angle); // rotated y0
                    XY1 = this.Width;
                    n1 = XY1 * Math.Cos(angle) - XY2 * Math.Sin(angle); // rotated x0
                    n2 = XY1 * Math.Sin(angle) + XY2 * Math.Cos(angle); // rotated y0
                    p1 = new Point(OX + (int)(x0 * scale) + (int)(m1 * scale), OY - (int)(y0 * scale) - (int)(m2 * scale));
                    p2 = new Point(OX + (int)(x0 * scale) + (int)(n1 * scale), OY - (int)(y0 * scale) - (int)(n2 * scale));
                    gr.DrawLine(RotatedAxesPen, p1, p2);
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
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale), OY - (int)(y * scale), 1, 1));
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x2 * scale), OY - (int)(y * scale), 1, 1));
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
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale), OY - (int)(y1 * scale), 1, 1));
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale), OY - (int)(y2 * scale), 1, 1));
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
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale), OY - (int)(y1 * scale), 1, 1));
                            }
                            if ((x + accuracy > x0) && (x - accuracy < x0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > x0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x * scale), OY - (int)(y1 * scale), 1, 1));
                            }
                            x += accuracy;
                        }
                        else
                        {
                            x1 = (-lyambda - 2 * tetta * x) / (2 * ksi * x + 2 * gamma);
                            if (x < y0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale), OY - (int)(x * scale), 1, 1));
                            }
                            if ((x + accuracy > y0) && (x - accuracy < y0))
                            {
                                x += accuracy * 10;
                            }
                            if (x > y0)
                            {
                                gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale), OY - (int)(x * scale), 1, 1));
                            }
                            x += accuracy;
                        }
                    }
                }
                #endregion

                #region Drawing Crossing Points
                // Crossing w/ a vertical axe
                d = Math.Pow(2 * tetta, 2) - (4 * (beta + 0.00000001) * lyambda);
                Oy1 = (-1.0 * (2 * tetta) + Math.Sqrt(d)) / (2 * (beta + 0.00000001));
                Oy2 = (-1.0 * (2 * tetta) - Math.Sqrt(d)) / (2 * (beta + 0.00000001));
                // Crossing w/ a horizontal axe
                d = Math.Pow(2 * gamma, 2) - (4 * (alpha + 0.00000001) * lyambda);
                Ox1 = (-1.0 * (2 * gamma) + Math.Sqrt(d)) / (2 * (alpha + 0.00000001));
                Ox2 = (-1.0 * (2 * gamma) - Math.Sqrt(d)) / (2 * (alpha + 0.00000001));

                double swap;
                if (Oy1 > Oy2)
                {
                    swap = Oy2;
                    Oy2 = Oy1;
                    Oy1 = swap;
                }
                if (Ox1 > Ox2)
                {
                    swap = Ox2;
                    Ox2 = Ox1;
                    Ox1 = swap;
                }
                if (Ox1 < -50000)
                    Ox1 = double.NegativeInfinity;
                if (Ox1 > 50000)
                    Ox1 = double.PositiveInfinity;

                if (Ox2 < -50000)
                    Ox2 = double.NegativeInfinity;
                if (Ox2 > 50000)
                    Ox2 = double.PositiveInfinity;

                if (Oy1 < -50000)
                    Oy1 = double.NegativeInfinity;
                if (Oy1 > 50000)
                    Oy1 = double.PositiveInfinity;

                if (Oy2 < -50000)
                    Oy2 = double.NegativeInfinity;
                if (Oy2 > 50000)
                    Oy2 = double.PositiveInfinity;

                TextFunction();

                if (CrossingPoints)
                {
                    // points of crossing w/ main axes
                    if ((Ox1 < double.PositiveInfinity) && (Ox1 > double.NegativeInfinity) && (Ox1 != double.NaN))
                        gr.FillEllipse(CrossingPointsPen, new Rectangle(OX + (int)(Ox1 * scale) - 3, OY - 3, 6, 6));
                    if ((Ox2 < double.PositiveInfinity) && (Ox2 > double.NegativeInfinity) && (Ox2 != double.NaN))
                        gr.FillEllipse(CrossingPointsPen, new Rectangle(OX + (int)(Ox2 * scale) - 3, OY - 3, 6, 6));
                    if ((Oy1 < double.PositiveInfinity) && (Oy1 > double.NegativeInfinity) && (Oy1 != double.NaN))
                        gr.FillEllipse(CrossingPointsPen, new Rectangle(OX - 3, OY - (int)(Oy1 * scale) - 3, 6, 6));
                    if ((Oy2 < double.PositiveInfinity) && (Oy2 > double.NegativeInfinity) && (Oy2 != double.NaN))
                        gr.FillEllipse(CrossingPointsPen, new Rectangle(OX - 3, OY - (int)(Oy2 * scale) - 3, 6, 6));
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
            I = Convert.ToDouble(fA.Text);
            J = Convert.ToDouble(fB.Text);
            K = Convert.ToDouble(fC.Text);
            N = Convert.ToDouble(fD.Text);
            CalculateFunction();
        }
        #endregion

        #region Close Button
        private void ClosingForm_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter file = new StreamWriter("PlaneSurfaceIntersection.txt");
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
                file.WriteLine(I);
                file.WriteLine(J);
                file.WriteLine(K);
                file.WriteLine(N);
                file.WriteLine(accuracy);
                file.WriteLine(length);
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

        #region Mouse Things
        void m_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if ((scale == 1) || (scale == 7) || (scale == 4))
                    scale += 3;
                else
                    scale += 5;
            }
            else
            {
                if (scale > 10)
                    scale -= 5;
                else if ((scale == 10) || (scale == 7) || (scale == 4))
                    scale -= 3;
                else if (scale == 1)
                    return;
            }
        }
        void mouseMove1(object sender, MouseEventArgs e)
        {
            if (status)
            {
                CurX -= Cursor.Position.X;
                CurY -= Cursor.Position.Y;
                OX -= CurX;
                OY -= CurY;
                CurX = Cursor.Position.X;
                CurY = Cursor.Position.Y;
            }
        }
        void mouseDown1(object sender, MouseEventArgs e)
        {
            status = true;
            CurX = Cursor.Position.X;
            CurY = Cursor.Position.Y;
        }
        void mouseUp1(object sender, MouseEventArgs e)
        {
            status = false;
        }
        #endregion

        #region Text Of Crossing W/ Axes, And New Point Axes, And Angle
        private void TextFunction()
        {
            Oox.Text = "⋂ Ox(" + Math.Round(Ox1, 3) + "; " + Math.Round(Ox2, 3) + ")"; // ⋂ OX
            Ooy.Text = "⋂ Oy(" + Math.Round(Oy1, 3) + "; " + Math.Round(Oy2, 3) + ")"; // ⋂ OX
            y = -length;

            if ((alpha != 0) && (Invariant2 == 0))
            {
                while (y < length)
                {
                    d = Math.Pow(2 * ksi * y + 2 * gamma, 2) - (4 * (alpha + 0.00000001) * ((beta + 0.00000001) * y * y + 2 * tetta * y + lyambda));
                    if ((d + 0.2 >= 0) && (d - 0.2 <= 0))
                    {
                        y0 = y;
                        x0 = (x1 + x2) / 2.0;
                    }
                    if (d >= 0)
                    {
                        x1 = (-1.0 * (2 * ksi * y + 2 * gamma) + Math.Sqrt(d)) / (2 * (alpha + 0.00000001));
                        x2 = (-1.0 * (2 * ksi * y + 2 * gamma) - Math.Sqrt(d)) / (2 * (alpha + 0.00000001));
                    }
                    y += 0.0001;
                }
            }
            x = -length;
            if ((beta != 0) && (Invariant2 == 0))
            {
                while (x < length)
                {
                    d = Math.Pow(2 * ksi * x + 2 * tetta, 2) - (4 * (beta + 0.00000001) * ((alpha + 0.00000001) * x * x + 2 * gamma * x + lyambda));
                    if ((d + 0.2 >= 0) && (d - 0.2 <= 0))
                    {
                        x0 = x;
                        y0 = (y1 + y2) / 2.0;
                    }
                    if (d >= 0)
                    {
                        y1 = (-1.0 * (2 * ksi * x + 2 * tetta) + Math.Sqrt(d)) / (2 * (beta + 0.00000001));
                        y2 = (-1.0 * (2 * ksi * x + 2 * tetta) - Math.Sqrt(d)) / (2 * (beta + 0.00000001));
                    }
                    x += 0.0001;
                }
            }
            Oxy.Text = "O(" + Math.Round(x0, 3) + "; " + Math.Round(y0, 3) + ")"; // O(x, y)
            textAngle.Text = "Angle: " + (float)(angle * 180.0 / Math.PI) + "°"; // Angle
        }
        #endregion

        #region Resize Form
        private void PlaneSurfaceIntersectionForm_Resize(object sender, EventArgs e)
        {
            OX = Plot.Width / 2;
            OY = Plot.Height / 2;
        }
        #endregion

        #region Centering Axes
        private void Center_Click(object sender, EventArgs e)
        {
            OX = Plot.Width / 2;
            OY = Plot.Height / 2;
            scale = 40;
        }
        #endregion

        #region Read From File
        private void FileReading()
        {
            String line;
            int operation = 0;
            try
            {
                StreamReader file = new StreamReader("PlaneSurfaceIntersection.txt");
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
                        fA.Text = line;
                    if (operation == 11)
                        fB.Text = line;
                    if (operation == 12)
                        fC.Text = line;
                    if (operation == 13)
                        fD.Text = line;
                    if (operation == 14)
                        textAccuracy.Text = line;
                    if (operation == 15)
                        textLength.Text = line;
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
                I = Convert.ToDouble(fA.Text);
                J = Convert.ToDouble(fB.Text);
                K = Convert.ToDouble(fC.Text);
                N = Convert.ToDouble(fD.Text);
                accuracy = Convert.ToDouble(textAccuracy.Text);
                length = Convert.ToDouble(textLength.Text);
                CalculateFunction();
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
            label13.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label14.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label15.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label16.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label17.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label18.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            label19.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            Apply.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            Center.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            ClosingForm.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            Oxy.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            textAngle.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            Oox.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            Ooy.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            checkCrossingPoints.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            checkHideNums.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            checkGrid.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            around.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            textFigure.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
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
    }
}
