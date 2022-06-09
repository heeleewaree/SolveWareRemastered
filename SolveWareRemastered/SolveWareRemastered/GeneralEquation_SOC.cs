using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SolveWareRemastered
{
    public partial class GeneralEquation_SOC : Form
    {
        public GeneralEquation_SOC()
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
        bool GridCheck = false;
        bool CrossingPoints = true;
        bool HideNumbers = false;
        double A, B, C, D, E, F;
        double accuracy, length;
        int OX = 702 / 2, OY = 562 / 2;
        double I1, I2, I3, K;
        double x0 = 0, y0 = 0;
        double angle;
        int scale = 40;
        double x, y, x1, x2, y1, y2, d;
        bool status = false;
        int CurX;
        int CurY;
        double Ox1, Ox2, Oy1, Oy2;
        String figure;
        bool Ellipse = false;
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

        #region Close Button
        private void ClosingForm_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter file = new StreamWriter("GeneralEquation_SOC.txt");
                file.WriteLine(A);
                file.WriteLine(2 * B);
                file.WriteLine(C);
                file.WriteLine(2 * D);
                file.WriteLine(2 * E);
                file.WriteLine(F);
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

        #region Ellipse Plane
        private void EllipsePlane()
        {
            if (Ellipse)
            {
                textEllipse.Text = "S = ";
                double g = 2.0 / (Math.Sqrt(4 * A * C - (2 * B) * (2 * B)) / (-(I3 / I2)));
                if (g != 1)
                    textEllipse.Text += Convert.ToString(g) + "Pi";
                else
                    textEllipse.Text += "Pi";
            }
            else
                textEllipse.Text = "";
        }
        #endregion

        #region Apply Button
        private void Apply_Click(object sender, EventArgs e)
        {
            if ((textA.Text == "0") && (textB.Text == "0") && (textC.Text == "0"))
                return;
            try
            {
                A = Convert.ToDouble(textA.Text);
                B = Convert.ToDouble(textB.Text) / 2.0;
                C = Convert.ToDouble(textC.Text);
                D = Convert.ToDouble(textD.Text) / 2.0;
                E = Convert.ToDouble(textE.Text) / 2.0;
                F = Convert.ToDouble(textF.Text);
                accuracy = Convert.ToDouble(textAccuracy.Text);
                length = Convert.ToDouble(textLength.Text);
                CalculateFunction();
                Figure();
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Function Of Calculating All Values
        private void CalculateFunction()
        {
            if ((A < 0) && (C < 0))
            {
                A = -A;
                B = -B;
                C = -C;
                D = -D;
                E = -E;
                F = -F;
            }
            I1 = A + C;
            I2 = A * C - (B * B);
            I3 = (A * C * F) + (B * E * D) + (B * E * D) - ((D * D * C) + (E * E * A) + (B * B * F));
            K = ((A * F) - (D * D)) + ((C * F) - (E * E));
            if (I2 != 0)
            {
                x0 = (-D * C - (-E * B)) / I2;
                y0 = (-E * A - (-D * B)) / I2;
            }
            angle = Math.Atan((2 * B) / (A - C)) / 2;
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
                drawString = "X";
                gr.DrawString(drawString, new Font("Times New Roman", 9), NumsPen, Plot.Width - 20, OY - 20);
                drawString = "Y";
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
                if (B != 0)
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
                if (A != 0)
                {
                    y = -length;
                    while (y < length)
                    {
                        d = Math.Pow(2 * B * y + 2 * D, 2) - (4 * A * (C * y * y + 2 * E * y + F));
                        if (d >= 0)
                        {
                            x1 = (-1.0 * (2 * B * y + 2 * D) + Math.Sqrt(d)) / (2 * A);
                            x2 = (-1.0 * (2 * B * y + 2 * D) - Math.Sqrt(d)) / (2 * A);
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x1 * scale), OY - (int)(y * scale), 1, 1));
                            gr.FillRectangle(FigurePen, new Rectangle(OX + (int)(x2 * scale), OY - (int)(y * scale), 1, 1));
                        }
                        y += accuracy;
                    }
                }
                else if (C != 0)
                {
                    x = -length;
                    while (x < length)
                    {
                        d = Math.Pow(2 * B * x + 2 * E, 2) - (4 * C * (A * x * x + 2 * D * x + F));
                        if (d >= 0)
                        {
                            y1 = (-1.0 * (2 * B * x + 2 * E) + Math.Sqrt(d)) / (2 * C);
                            y2 = (-1.0 * (2 * B * x + 2 * E) - Math.Sqrt(d)) / (2 * C);
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
                        if (E != 0 || B != 0)
                        {
                            y1 = (-F - 2 * D * x) / (2 * B * x + 2 * E);
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
                            x1 = (-F - 2 * E * x) / (2 * B * x + 2 * D);
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
                d = Math.Pow(2 * E, 2) - (4 * (C + 0.00000001) * F);
                Oy1 = (-1.0 * (2 * E) + Math.Sqrt(d)) / (2 * (C + 0.00000001));
                Oy2 = (-1.0 * (2 * E) - Math.Sqrt(d)) / (2 * (C + 0.00000001));
                // Crossing w/ a horizontal axe
                d = Math.Pow(2 * D, 2) - (4 * (A + 0.00000001) * F);
                Ox1 = (-1.0 * (2 * D) + Math.Sqrt(d)) / (2 * (A + 0.00000001));
                Ox2 = (-1.0 * (2 * D) - Math.Sqrt(d)) / (2 * (A + 0.00000001));

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

        #region Determine Figure
        private void Figure()
        {
            if (I2 != 0)
            {
                if (I2 > 0)
                {
                    if (I3 < 0)
                    {
                        figure = "Ellipse";
                        Ellipse = true;
                    }
                    else if (I3 == 0)
                    {
                        figure = "Point (a pair of imaginary intersecting lines)";
                        Ellipse = false;
                    }
                    else if (I3 > 0)
                    {
                        figure = "Imaginary ellipse";
                        Ellipse = false;
                    }
                }
                if (I2 < 0)
                {
                    if (I3 == 0)
                    {
                        figure = "A pair of intersecting straight lines";
                        Ellipse = false;
                    }
                    else if (I3 != 0)
                    {
                        figure = "Hyperbola";
                        Ellipse = false;
                    }
                }
            }
            else if (I2 == 0)
            {
                if (I3 != 0)
                {
                    figure = "Parabola";
                    Ellipse = false;
                }
                else if (I3 == 0)
                {
                    if (K < 0)
                    {
                        figure = "A pair of parallel straight lines";
                        Ellipse = false;
                    }
                    else if (K == 0)
                    {
                        figure = "Straight";
                        Ellipse = false;
                    }
                    else if (K > 0)
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

        #region Read From File
        private void FileReading()
        {
            String line;
            int operation = 0;
            try
            {
                StreamReader file = new StreamReader("GeneralEquation_SOC.txt");
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
                        textD.Text = line;
                    if (operation == 4)
                        textE.Text = line;
                    if (operation == 5)
                        textF.Text = line;
                    if (operation == 6)
                        textAccuracy.Text = line;
                    if (operation == 7)
                        textLength.Text = line;
                    line = file.ReadLine();
                    operation++;
                }
                file.Close();
                A = Convert.ToDouble(textA.Text);
                B = Convert.ToDouble(textB.Text) / 2.0;
                C = Convert.ToDouble(textC.Text);
                D = Convert.ToDouble(textD.Text) / 2.0;
                E = Convert.ToDouble(textE.Text) / 2.0;
                F = Convert.ToDouble(textF.Text);
                accuracy = Convert.ToDouble(textAccuracy.Text);
                length = Convert.ToDouble(textLength.Text);
                CalculateFunction();
                Figure();
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

        #region KeyPress
        private void Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | (e.KeyChar == Convert.ToChar("-")) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }


        private void textAccuracy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void textLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
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

        #region Resize Form
        private void GeneralEquation_SOC_Resize(object sender, EventArgs e)
        {
            OX = Plot.Width / 2;
            OY = Plot.Height / 2;
        }
        #endregion

        #region Text Of Crossing W/ Axes, And New Point Axes, And Angle
        private void TextFunction()
        {
            Oox.Text = "⋂ Ox(" + Math.Round(Ox1, 3) + "; " + Math.Round(Ox2, 3) + ")"; // ⋂ OX
            Ooy.Text = "⋂ Oy(" + Math.Round(Oy1, 3) + "; " + Math.Round(Oy2, 3) + ")"; // ⋂ OX
            y = -length;

            if ((A != 0) && (I2 == 0))
            {
                while (y < length)
                {
                    d = Math.Pow(2 * B * y + 2 * D, 2) - (4 * (A + 0.00000001) * ((C + 0.00000001) * y * y + 2 * E * y + F));
                    if ((d + 0.2 >= 0) && (d - 0.2 <= 0))
                    {
                        y0 = y;
                        x0 = (x1 + x2) / 2.0;
                    }
                    if (d >= 0)
                    {
                        x1 = (-1.0 * (2 * B * y + 2 * D) + Math.Sqrt(d)) / (2 * (A + 0.00000001));
                        x2 = (-1.0 * (2 * B * y + 2 * D) - Math.Sqrt(d)) / (2 * (A + 0.00000001));
                    }
                    y += 0.0001;
                }
            }
            x = -length;
            if ((C != 0) && (I2 == 0))
            {
                while (x < length)
                {
                    d = Math.Pow(2 * B * x + 2 * E, 2) - (4 * (C + 0.00000001) * ((A + 0.00000001) * x * x + 2 * D * x + F));
                    if ((d + 0.2 >= 0) && (d - 0.2 <= 0))
                    {
                        x0 = x;
                        y0 = (y1 + y2) / 2.0;
                    }
                    if (d >= 0)
                    {
                        y1 = (-1.0 * (2 * B * x + 2 * E) + Math.Sqrt(d)) / (2 * (C + 0.00000001));
                        y2 = (-1.0 * (2 * B * x + 2 * E) - Math.Sqrt(d)) / (2 * (C + 0.00000001));
                    }
                    x += 0.0001;
                }
            }
            Oxy.Text = "O(" + Math.Round(x0, 3) + "; " + Math.Round(y0, 3) + ")"; // O(x, y)
            textAngle.Text = "Angle: " + (float)(angle * 180.0 / Math.PI) + "°"; // Angle
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
            Center.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            ClosingForm.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            Oxy.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            textAngle.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            Oox.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            Ooy.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            checkCrossingPoints.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            checkHideNums.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            checkGrid.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
            textFigure.ForeColor = Color.FromArgb(tc_r, tc_g, tc_b);
        }
        #endregion
    }
}