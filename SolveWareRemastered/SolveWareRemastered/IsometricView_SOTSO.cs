using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SolveWareRemastered
{
    public partial class IsometricView_SOTSO : Form
    {
        public IsometricView_SOTSO()
        {
            InitializeComponent();
        }
        #region Vectors Graphics
        public struct vektor3d
        {
            public float x, y, z;
        }

        public struct surfSides
        {
            public vektor3d[] pt;
            public int idp;

        }
        #endregion

        #region Vars
        surfSides[] sidesStart;
        surfSides[] sidesEnd;

        float a1, a2, b1, b2;
        int M, N;
        Single a, b, c;
        int nnn1, odindva;

        float[,] matrixSurfDec;
        int[,] matrixSurfDisp;

        float[,] matrixAxStartCord;
        float[,] matrixAxEndCord;
        float[,] matrixAxDecCord;
        int[,] matrixAxDispCord;
        float[,] matrixTransf;

        float[,] surfaceXOY;
        float[,] surfaceXOYEnd;
        float[,] surfaceXOYDec;
        int[,] surfaceXOYDisp;

        float[,] surfaceXOZ;
        float[,] surfaceXOZEnd;
        float[,] surfaceXOZDec;
        int[,] surfaceXOZDisp;

        float[,] surfaceYOZ;
        float[,] surfaceYOZEnd;
        float[,] surfaceYOZDec;
        int[,] surfaceYOZDisp;


        float ma, mb, mc, mp, md, me, mf, mq, mg, mh, mi, mr, ml, mm, mn, ms;

        float[,] matrixAxTrRotY;
        float[,] matrixAxTrRotX;
        float[,] matrixOrtogZ;
        float[,] matrixGenTr;

        int W, H;
        float cAx, mmh, mmw, hh, ww;
        float degSt;
        int rotY;
        int rotX;

        Graphics graph;
        Graphics gr;
        Bitmap fromBitmap;
        Font f;

        bool iAmStarted = false;
        bool drawSurface = false;
        #endregion

        #region Load
        private void Form1_Load(object sender, EventArgs e)
        {
            W = picDraw.Width;
            H = picDraw.Height;
            cAx = 10;
            mmw = W / (2 * (cAx + 1));
            mmh = H / (2 * (cAx + 1));

            degSt = (float)Math.PI / 180;

            rotX = 0;
            rotY = 0;
            ml = 0;
            mm = 0;
            mn = 0;
            ms = 1;
            //transformation matrix
            matrixTransf = new float[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { ml, mm, mn, ms } };
            matrixAxStartCord = new float[6, 4] { { -cAx, 0, 0, 1 }, { cAx, 0, 0, 1 },
                                                   { 0, -cAx, 0, 1 }, {  0, cAx, 0, 1 },
                                                    { 0,  0, -cAx, 1 }, {  0,  0, cAx, 1 }};

            matrixAxTrRotY = new float[4, 4] { {(float)Math.Cos(degSt * rotY),0,(float)-Math.Sin(degSt *rotY),0},
                                        {0,1,0,0},
                                   {(float)Math.Sin(degSt * rotY),0,(float)Math.Cos(degSt * rotY),0},
                                        {0,0,0,1}};
            matrixAxTrRotX = new float[4, 4] { { 1, 0, 0, 0 },
                               { 0, (float)Math.Cos(degSt * rotX), (float)Math.Sin(degSt * rotX), 0 },
                              { 0, (float)-Math.Sin(degSt * rotX), (float)Math.Cos(degSt * rotX), 0 },
                              { 0, 0, 0, 1 } };

            matrixOrtogZ = new float[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 1 } };

            //redimation matrix
            matrixGenTr = new float[4, 4];
            matrixAxEndCord = new float[6, 4];
            matrixAxDecCord = new float[6, 4];
            matrixAxDispCord = new int[6, 4];

            //surface XOY
            surfaceXOY = new float[4, 4] { { -cAx, cAx, 0, 1 }, { cAx, cAx, 0, 1 }, { cAx, -cAx, 0, 1 }, { -cAx, -cAx, 0, 1 } };
            surfaceXOYEnd = new float[4, 4];
            surfaceXOYDec = new float[4, 4];
            surfaceXOYDisp = new int[4, 4];

            //surface XOZ
            surfaceXOZ = new float[4, 4] { { -cAx, 0, -cAx, 1 }, { cAx, 0, -cAx, 1 }, { cAx, 0, cAx, 1 }, { -cAx, 0, cAx, 1 } };
            surfaceXOZEnd = new float[4, 4];
            surfaceXOZDec = new float[4, 4];
            surfaceXOZDisp = new int[4, 4];

            //surface YOZ
            surfaceYOZ = new float[4, 4] { { 0, -cAx, -cAx, 1 }, { 0, -cAx, cAx, 1 }, { 0, cAx, cAx, 1 }, { 0, cAx, -cAx, 1 } };
            surfaceYOZEnd = new float[4, 4];
            surfaceYOZDec = new float[4, 4];
            surfaceYOZDisp = new int[4, 4];

            //плоскость
            a1 = 0; a2 = 1; b1 = 0; b2 = 1;
            a = 1; b = 1; c = 1;
            nnn1 = 1;
            odindva = 0;


            //data grid view
            dgvAxisStart.RowCount = 6;
            dgvAxisFin.RowCount = 6;
            dgvAxisDec.RowCount = 6;
            dgvAxisEkr.RowCount = 6;
            dgvTransf.RowCount = 4;

            //fill matrix
            fillmatrixmxn(matrixAxStartCord, dgvAxisStart);
            fillmatrixmxn(matrixTransf, dgvTransf);
            //graphic
            f = new Font("Arial", 10);
            graph = picDraw.CreateGraphics();
            fromBitmap = new Bitmap(W, H);
            gr = Graphics.FromImage(fromBitmap);
            picDraw.Image = fromBitmap;

            //starting
            startGeneral();
            //logical
            iAmStarted = true;

        }
        #endregion

        #region General
        private void startGeneral()
        {
            mathGeneral();
            graphGeneral();
        }
        private void mathGeneral()
        {
            createGeneralTransfMx();
            matrixAxTransformation();
            homogToDec(matrixAxEndCord, matrixAxDecCord);
            fillmatrixmxn(matrixAxDecCord, dgvAxisDec);
            calculateDispCord(matrixAxDispCord, matrixAxDecCord, dgvAxisEkr);

            //трансформация плоскостей координатной системы
            if (chbSurface.Checked == true)
            {
                matrixTransformationSurface();

                homogToDec(surfaceXOYEnd, surfaceXOYDec);
                calculateDispCord(surfaceXOYDisp, surfaceXOYDec);

                homogToDec(surfaceXOZEnd, surfaceXOZDec);
                calculateDispCord(surfaceXOZDisp, surfaceXOZDec);

                homogToDec(surfaceYOZEnd, surfaceYOZDec);
                calculateDispCord(surfaceYOZDisp, surfaceYOZDec);
            }

            if (drawSurface == true)
            {
                crateSurfPointArray();

            }

        }
        private void graphGeneral()
        {
            drawAxis(matrixAxDispCord);
            writeAxisLeter(matrixAxDispCord);

            //surface
            if (chbSurface.Checked == true)
            {
                DrawSurface(surfaceXOYDisp);
                DrawSurface(surfaceXOZDisp);
                DrawSurface(surfaceYOZDisp);
                //filling
                if (chbFillSurface.Checked == true)
                {

                    fillColorShort(surfaceXOYDisp);
                    fillColorShort(surfaceXOZDisp);
                    fillColorShort(surfaceYOZDisp);
                }
            }
            if (drawSurface == true)
            {
                drawSurf();
            }

        }
        #endregion

        #region DGV Fill
        private void fillmatrixmxn(float[,] m, DataGridView dgv)
        {
            int i, j;
            int arajinmatricaerk = 0;
            int arajinmatricalayn = 0;
            arajinmatricaerk = m.GetLength(0);
            arajinmatricalayn = m.GetLength(1);
            dgv.RowCount = arajinmatricaerk;
            if (arajinmatricaerk > dgv.RowCount)
            {
                MessageBox.Show("datagride Rows count must be greater " +
                                    "than matrix rows count", "Important");
                return;
            }
            for (i = 0; i < arajinmatricaerk; i++)
            {
                for (j = 0; j < arajinmatricalayn; j++)
                {
                    dgv.Rows[i].Cells[j].Value = m[i, j];
                }
            }
        }

        private void fillmatrixmxn(int[,] m, DataGridView dgv)
        {
            int i, j;
            int arajinmatricaerk = 0;
            int arajinmatricalayn = 0;
            arajinmatricaerk = m.GetLength(0);
            arajinmatricalayn = m.GetLength(1);
            dgv.RowCount = arajinmatricaerk;
            if (arajinmatricaerk > dgv.RowCount)
            {
                MessageBox.Show("datagride Rows count must be greater " +
                                    "than matrix rows count", "Important");
                return;
            }
            for (i = 0; i < arajinmatricaerk; i++)
            {
                for (j = 0; j < arajinmatricalayn; j++)
                {
                    dgv.Rows[i].Cells[j].Value = m[i, j];
                }
            }
        }
        #endregion

        #region Multiply Matrix
        private void multipleMatrixnxm(float[,] m1, float[,] m2, float[,] rez)
        {
            int i, j, r;
            int firstMxRow = 0;
            int firstMxCol = 0;
            int secondMxRow = 0;
            int secondMxCol = 0;
            int rezMxRow = 0;
            int rezMxCol = 0;

            firstMxRow = m1.GetLength(0);
            firstMxCol = m1.GetLength(1);
            secondMxRow = m2.GetLength(0);
            secondMxCol = m2.GetLength(1);
            rezMxRow = rez.GetLength(0);
            rezMxCol = rez.GetLength(1);

            for (i = 0; i < rezMxRow; i++)
            {
                for (j = 0; j < rezMxCol; j++)
                {
                    rez[i, j] = 0;
                }

            }

            if (firstMxCol == secondMxRow)
            {
                for (i = 0; i < firstMxRow; i++)
                {
                    for (j = 0; j < secondMxCol; j++)
                    {
                        for (r = 0; r < firstMxCol; r++)
                        {
                            rez[i, j] = rez[i, j] + m1[i, r] * m2[r, j];
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("The firdt matrix Columns count and the second" +
                    "matrix Rows count must be equals", "Important");
                return;

            }

        }
        #endregion

        #region System Of Coordinates
        private void homogToDec(float[,] endCord, float[,] decCord)
        {
            //из однородной системы координат переходим в декартовую систему
            //нормирование координат трансформированного объекта
            int mi = 0;
            int mj = 0;

            int firstMxRow = endCord.GetLength(0);     //количество строк первой матрицы
            int firstMxCol = endCord.GetLength(1);     //количество столбцов первой матрицы


            for (mi = 0; mi < firstMxRow; mi++)
                for (mj = 0; mj < firstMxCol; mj++)
                {
                    if (endCord[mi, 3] != 1)
                    {
                        if (endCord[mi, 3] == 0)
                        {
                            endCord[mi, 3] = 0.01f;
                        }
                        else
                        {
                            decCord[mi, mj] = endCord[mi, mj] / endCord[mi, 3];
                        }
                    }
                    else
                    {
                        decCord[mi, mj] = endCord[mi, mj];
                    }
                }

        }

        private void calculateDispCord(int[,] mDisp, float[,] mDek, DataGridView dgvDisp)
        {
            int i, j;
            int mDekerk = mDek.GetLength(0);
            int mDeklayn = mDek.GetLength(1);

            for (i = 0; i < mDekerk; i++)
            {
                for (j = 0; j < mDeklayn - 1; j++)
                {
                    if (j == 0)
                    {
                        mDisp[i, 0] = (int)(W / 2 + (mmw * mDek[i, j]));
                    }
                    if (j == 1)
                    {
                        mDisp[i, 1] = (int)(H / 2 - (mmh * mDek[i, j]));
                    }
                }
            }
            fillmatrixmxn(mDisp, dgvDisp);
        }

        private void calculateDispCord(int[,] mDisp, float[,] mDek)
        {
            int i, j;
            int mDekerk = mDek.GetLength(0);
            int mDeklayn = mDek.GetLength(1);

            for (i = 0; i < mDekerk; i++)
            {
                for (j = 0; j < mDeklayn - 1; j++)
                {
                    if (j == 0)
                    {
                        mDisp[i, 0] = (int)(W / 2 + (mmw * mDek[i, j]));
                    }
                    if (j == 1)
                    {
                        mDisp[i, 1] = (int)(H / 2 - (mmh * mDek[i, j]));
                    }
                }
            }
        }
        #endregion

        #region Matrix Transform
        private void createGeneralTransfMx()
        {
            float[,] tempM = new float[4, 4];
            multipleMatrixnxm(matrixAxTrRotY, matrixAxTrRotX, tempM);
            multipleMatrixnxm(tempM, matrixOrtogZ, matrixGenTr);
        }

        private void matrixAxTransformation()
        {
            multipleMatrixnxm(matrixAxStartCord, matrixGenTr, matrixAxEndCord);
            fillmatrixmxn(matrixAxEndCord, dgvAxisFin);
        }
        #endregion

        #region Drawing
        private void drawAxis(int[,] matrEkr)
        {
            Pen pendr = new Pen(new SolidBrush(Color.White), 1);
            gr.DrawLine(pendr, matrEkr[0, 0], matrEkr[0, 1], matrEkr[1, 0], matrEkr[1, 1]);
            gr.DrawLine(pendr, matrEkr[2, 0], matrEkr[2, 1], matrEkr[3, 0], matrEkr[3, 1]);
            gr.DrawLine(pendr, matrEkr[4, 0], matrEkr[4, 1], matrEkr[5, 0], matrEkr[5, 1]);
        }

        private void writeAxisLeter(int[,] matrEkr)
        {
            Font tf = new Font("Arial", 8);
            gr.DrawString("X", tf, Brushes.White, matrEkr[1, 0], matrEkr[1, 1]);
            gr.DrawString("Y", tf, Brushes.White, matrEkr[3, 0], matrEkr[3, 1]);
            gr.DrawString("Z", tf, Brushes.White, matrEkr[5, 0], matrEkr[5, 1]);
        }
        #endregion

        #region Update
        private void updatePicBox()
        {
            gr.Clear(picDraw.BackColor);
            startGeneral();
            picDraw.Image = fromBitmap;
        }

        private void gloabalUpdate()
        {
            W = picDraw.Width;
            H = picDraw.Height;

            mmw = W / (2 * (cAx + 1));
            mmh = H / (2 * (cAx + 1));

            graph = picDraw.CreateGraphics();
            fromBitmap = new Bitmap(W, H);
            gr = Graphics.FromImage(fromBitmap);
            picDraw.Image = fromBitmap;

            startGeneral();


        }
        #endregion

        #region Track Bars
        private void trbRotY_ValueChanged(object sender, EventArgs e)
        {
            rotY = trbRotY.Value;
            txtRotY.Text = rotY.ToString();
            matrixAxTrRotY[0, 0] = (float)Math.Cos(degSt * rotY); matrixAxTrRotY[0, 1] = 0;
            matrixAxTrRotY[0, 2] = (float)-Math.Sin(degSt * rotY); matrixAxTrRotY[0, 3] = 0;

            matrixAxTrRotY[1, 0] = 0; matrixAxTrRotY[1, 1] = 1; matrixAxTrRotY[1, 2] = 0;
            matrixAxTrRotY[1, 3] = 0;

            matrixAxTrRotY[2, 0] = (float)Math.Sin(degSt * rotY); matrixAxTrRotY[2, 1] = 0;
            matrixAxTrRotY[2, 2] = (float)Math.Cos(degSt * rotY); matrixAxTrRotY[2, 3] = 0;

            matrixAxTrRotY[3, 0] = 0; matrixAxTrRotY[3, 1] = 0; matrixAxTrRotY[3, 2] = 0;
            matrixAxTrRotY[3, 3] = 1;

            updatePicBox();

        }

        private void trbRotX_ValueChanged(object sender, EventArgs e)
        {
            rotX = trbRotX.Value;
            txtRotX.Text = rotX.ToString();
            matrixAxTrRotX[0, 0] = 1; matrixAxTrRotX[0, 1] = 0; matrixAxTrRotX[0, 2] = 0;
            matrixAxTrRotX[0, 3] = 0;

            matrixAxTrRotX[1, 0] = 0; matrixAxTrRotX[1, 1] = (float)Math.Cos(degSt * rotX);
            matrixAxTrRotX[1, 2] = (float)Math.Sin(degSt * rotX); matrixAxTrRotX[1, 3] = 0;

            matrixAxTrRotX[2, 0] = 0; matrixAxTrRotX[2, 1] = (float)-Math.Sin(degSt * rotX);
            matrixAxTrRotX[2, 2] = (float)Math.Cos(degSt * rotX); matrixAxTrRotX[2, 3] = 0;

            matrixAxTrRotX[3, 0] = 0; matrixAxTrRotX[3, 1] = 0; matrixAxTrRotX[3, 2] = 0;
            matrixAxTrRotX[3, 3] = 1;

            updatePicBox();

        }

        private void trbCountAxis_ValueChanged(object sender, EventArgs e)
        {
            if (iAmStarted == true)
            {
                cAx = trbCountAxis.Value;
                txtCountAxis.Text = cAx.ToString();
                gloabalUpdate();
            }
        }
        #endregion

        #region Resize
        private void IsometricView_SOTSO_Resize(object sender, EventArgs e)
        {
            gloabalUpdate();
        }

        private void splitContainer2_Panel2_Resize(object sender, EventArgs e)
        {
            if (iAmStarted == true)
            {
                gloabalUpdate();
            }
        }
        #endregion

        #region Surfaces
        private void matrixTransformationSurface()
        {
            multipleMatrixnxm(surfaceXOY, matrixGenTr, surfaceXOYEnd);
            multipleMatrixnxm(surfaceXOZ, matrixGenTr, surfaceXOZEnd);
            multipleMatrixnxm(surfaceYOZ, matrixGenTr, surfaceYOZEnd);

        }

        private void DrawSurface(int[,] surfCord)
        {
            Pen pendr = new Pen(new SolidBrush(Color.Yellow), 1);
            gr.DrawLine(pendr, surfCord[0, 0], surfCord[0, 1], surfCord[1, 0], surfCord[1, 1]);
            gr.DrawLine(pendr, surfCord[1, 0], surfCord[1, 1], surfCord[2, 0], surfCord[2, 1]);
            gr.DrawLine(pendr, surfCord[2, 0], surfCord[2, 1], surfCord[3, 0], surfCord[3, 1]);
            gr.DrawLine(pendr, surfCord[3, 0], surfCord[3, 1], surfCord[0, 0], surfCord[0, 1]);

        }
        private void fillColorShort(int[,] planeCord)
        {
            Point[] pts ={new Point(planeCord [0,0], planeCord [0,1]),
                          new Point(planeCord [1,0], planeCord [1,1]),
                          new Point(planeCord [2,0], planeCord [2,1]),
                          new Point(planeCord [3,0], planeCord [3,1])};

            GraphicsPath g_path = new GraphicsPath();
            g_path.AddClosedCurve(pts, 0.01f);
            SolidBrush transBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 100));
            gr.FillPath(transBrush, g_path);

        }
        private void crateSurfPointArray()
        {
            N = Convert.ToInt16(nudN.Value);
            M = Convert.ToInt16(nudM.Value);

            int i, j, q, mxn;
            float u, w, h1, h2;


            if (odindva == 0)
            {
                mxn = M * N;
            }
            else
            {
                mxn = 2 * M * N;
            }
            h1 = (a2 - a1) / N;
            h2 = (b2 - b1) / M;

            sidesStart = new surfSides[mxn];
            sidesEnd = new surfSides[mxn];


            float[,] tempm = new float[4, 4];
            float[,] pattemp = new float[4, 4];

            for (i = 0; i < mxn; i++)
            {
                sidesStart[i].pt = new vektor3d[4];
                sidesEnd[i].pt = new vektor3d[4];
            }
            q = -1;
            for (j = 0; j < N; j++)
            {
                for (i = 0; i < M; i++)
                {
                    q += 1;
                    //step 1
                    u = a1 + h1 * (j + 0);
                    w = b1 + h2 * (i + 0);
                    vektor3d tp;
                    tp = calcSurfPoint(u, w, 0);
                    tempm[0, 0] = tp.x;
                    tempm[0, 1] = tp.y;
                    tempm[0, 2] = tp.z;
                    tempm[0, 3] = 1;

                    sidesEnd[q].pt[0] = tp;

                    //step 2
                    u = a1 + h1 * (j + 0);
                    w = b1 + h2 * (i + 1);
                    tp = calcSurfPoint(u, w, 0);
                    tempm[1, 0] = tp.x;
                    tempm[1, 1] = tp.y;
                    tempm[1, 2] = tp.z;
                    tempm[1, 3] = 1;
                    sidesEnd[q].pt[1] = tp;

                    //step 3
                    u = a1 + h1 * (j + 1);
                    w = b1 + h2 * (i + 1);
                    tp = calcSurfPoint(u, w, 0);
                    tempm[2, 0] = tp.x;
                    tempm[2, 1] = tp.y;
                    tempm[2, 2] = tp.z;
                    tempm[2, 3] = 1;
                    sidesEnd[q].pt[2] = tp;
                    //step 4
                    u = a1 + h1 * (j + 1);
                    w = b1 + h2 * (i + 0);
                    tp = calcSurfPoint(u, w, 0);
                    tempm[3, 0] = tp.x;
                    tempm[3, 1] = tp.y;
                    tempm[3, 2] = tp.z;
                    tempm[3, 3] = 1;
                    sidesEnd[q].pt[3] = tp;

                    //transformation
                    trSurf1(tempm, pattemp);
                    //redimation 
                    matrixSurfDec = new float[4, 4];
                    //calculate dek coordinates
                    homogToDec(pattemp, matrixSurfDec);
                    //redimation screen cordinates
                    matrixSurfDisp = new int[4, 4];
                    calculateDispCord(matrixSurfDisp, matrixSurfDec);

                    //saving data in array for using leter
                    sidesStart[q].pt[0].x = matrixSurfDisp[0, 0];
                    sidesStart[q].pt[0].y = matrixSurfDisp[0, 1];
                    sidesStart[q].pt[0].z = matrixSurfDisp[0, 2];

                    sidesStart[q].pt[1].x = matrixSurfDisp[1, 0];
                    sidesStart[q].pt[1].y = matrixSurfDisp[1, 1];
                    sidesStart[q].pt[1].z = matrixSurfDisp[1, 2];

                    sidesStart[q].pt[2].x = matrixSurfDisp[2, 0];
                    sidesStart[q].pt[2].y = matrixSurfDisp[2, 1];
                    sidesStart[q].pt[2].z = matrixSurfDisp[2, 2];

                    sidesStart[q].pt[3].x = matrixSurfDisp[3, 0];
                    sidesStart[q].pt[3].y = matrixSurfDisp[3, 1];
                    sidesStart[q].pt[3].z = matrixSurfDisp[3, 2];

                    if (odindva != 0)
                    {
                        //step 1
                        u = a1 + h1 * (j + 0);
                        w = b1 + h2 * (i + 0);
                        //vektor3d tp;
                        tp = calcSurfPoint(u, w, 0);
                        tempm[0, 0] = tp.x;
                        tempm[0, 1] = -tp.y;
                        tempm[0, 2] = tp.z;
                        tempm[0, 3] = 1;

                        sidesEnd[q + N * M].pt[0] = tp;

                        //step 2
                        u = a1 + h1 * (j + 0);
                        w = b1 + h2 * (i + 1);
                        tp = calcSurfPoint(u, w, 0);
                        tempm[1, 0] = tp.x;
                        tempm[1, 1] = -tp.y;
                        tempm[1, 2] = tp.z;
                        tempm[1, 3] = 1;
                        sidesEnd[q + N * M].pt[1] = tp;

                        //step 3
                        u = a1 + h1 * (j + 1);
                        w = b1 + h2 * (i + 1);
                        tp = calcSurfPoint(u, w, 0);
                        tempm[2, 0] = tp.x;
                        tempm[2, 1] = -tp.y;
                        tempm[2, 2] = tp.z;
                        tempm[2, 3] = 1;
                        sidesEnd[q + N * M].pt[2] = tp;
                        //step 4
                        u = a1 + h1 * (j + 1);
                        w = b1 + h2 * (i + 0);
                        tp = calcSurfPoint(u, w, 0);
                        tempm[3, 0] = tp.x;
                        tempm[3, 1] = -tp.y;
                        tempm[3, 2] = tp.z;
                        tempm[3, 3] = 1;
                        sidesEnd[q + N * M].pt[3] = tp;

                        //transformation
                        trSurf1(tempm, pattemp);
                        //redimation 
                        matrixSurfDec = new float[4, 4];
                        //calculate dek coordinates
                        homogToDec(pattemp, matrixSurfDec);
                        //redimation screen cordinates
                        matrixSurfDisp = new int[4, 4];
                        calculateDispCord(matrixSurfDisp, matrixSurfDec);

                        //saving data in array for using leter
                        sidesStart[q + N * M].pt[0].x = matrixSurfDisp[0, 0];
                        sidesStart[q + N * M].pt[0].y = matrixSurfDisp[0, 1];
                        sidesStart[q + N * M].pt[0].z = matrixSurfDisp[0, 2];

                        sidesStart[q + N * M].pt[1].x = matrixSurfDisp[1, 0];
                        sidesStart[q + N * M].pt[1].y = matrixSurfDisp[1, 1];
                        sidesStart[q + N * M].pt[1].z = matrixSurfDisp[1, 2];

                        sidesStart[q + N * M].pt[2].x = matrixSurfDisp[2, 0];
                        sidesStart[q + N * M].pt[2].y = matrixSurfDisp[2, 1];
                        sidesStart[q + N * M].pt[2].z = matrixSurfDisp[2, 2];

                        sidesStart[q + N * M].pt[3].x = matrixSurfDisp[3, 0];
                        sidesStart[q + N * M].pt[3].y = matrixSurfDisp[3, 1];
                        sidesStart[q + N * M].pt[3].z = matrixSurfDisp[3, 2];
                    }

                }

            }

        }

        #endregion

        #region Calculate Surface Points
        private vektor3d calcSurfPoint(float u1, float w1, float v1)
        {
            vektor3d pat;
            pat.x = 0;
            pat.y = 0;
            pat.z = 0;
            switch (nnn1)
            {
                case 1: //Элипсоид
                    pat.x = a * (float)(Math.Sin(u1) * Math.Cos(w1));
                    pat.y = b * (float)(Math.Sin(u1) * Math.Sin(w1));
                    pat.z = c * (float)(Math.Cos(u1));
                    return pat;

                case 2: //Однополостной Гиперболоид
                    pat.x = a * (float)(expGumh(u1) * Math.Sin(w1));
                    pat.y = b * (float)expHan(u1);
                    pat.z = c * (float)(expGumh(u1) * Math.Cos(w1));
                    return pat;
                case 3: //Двухполостной Гиперболоид
                    pat.x = a * (float)(expHan(u1) * Math.Sin(w1));
                    pat.y = b * (float)expGumh(u1);
                    pat.z = c * (float)(expHan(u1) * Math.Cos(w1));
                    return pat;

                case 4: //Элиптический Конус
                    pat.x = a * u1 * (float)Math.Sin(w1);
                    pat.y = b * u1;
                    pat.z = c * u1 * (float)Math.Cos(w1);
                    return pat;

                case 5: //Гиперболический параболоид
                    pat.x = a * u1 * (float)Math.Sin(w1);
                    pat.y = b * u1 * u1 * (float)Math.Cos(2 * w1);
                    pat.z = c * u1 * (float)Math.Cos(w1);
                    return pat;

                case 6: //Элиптический параболоид
                    pat.x = a * u1 * (float)Math.Sin(w1);
                    pat.y = b * u1 * u1;
                    pat.z = c * u1 * (float)Math.Cos(w1);
                    return pat;

                case 7: //Элиптический цилиндр
                    pat.x = a * (float)Math.Sin(w1);
                    pat.y = b * u1;
                    pat.z = c * (float)Math.Cos(w1);
                    return pat;

                case 8: //Параболический цилиндр
                    pat.x = a * u1 * u1;
                    pat.y = 2 * a * u1;
                    pat.z = w1;
                    return pat;

                case 9: //Гиперболический цилиндр
                    pat.x = a * expHan(w1);
                    pat.y = b * expGumh(w1);
                    pat.z = c * u1;
                    return pat;

                case 10: //Тор
                    pat.x = (a + b * (float)Math.Cos(u1)) * (float)Math.Cos(w1);
                    pat.y = b * (float)Math.Sin(u1);
                    pat.z = (a + b * (float)Math.Cos(u1)) * (float)Math.Sin(w1);
                    return pat;

                default:
                    pat.x = u1;
                    pat.y = w1;
                    pat.z = v1;
                    return pat;

            }

        }
        #endregion

        #region Drawing Surface
        private void trSurf1(float[,] mf1, float[,] mf2)
        {
            multipleMatrixnxm(mf1, matrixGenTr, mf2);
        }
        private void drawSurf()
        {
            int i, L;
            Font f = new Font("Arial", 10);
            //L = M * N;
            if (odindva == 0)
            {
                L = M * N;
            }
            else
            {
                L = 2 * M * N;
            }
            for (i = 0; i < L; i++)
            {
                if (i <= M * N)
                {
                    gr.DrawLine(Pens.White, sidesStart[i].pt[0].x, sidesStart[i].pt[0].y, sidesStart[i].pt[1].x, sidesStart[i].pt[1].y);
                    gr.DrawLine(Pens.White, sidesStart[i].pt[1].x, sidesStart[i].pt[1].y, sidesStart[i].pt[2].x, sidesStart[i].pt[2].y);
                    gr.DrawLine(Pens.White, sidesStart[i].pt[2].x, sidesStart[i].pt[2].y, sidesStart[i].pt[3].x, sidesStart[i].pt[3].y);
                    gr.DrawLine(Pens.White, sidesStart[i].pt[3].x, sidesStart[i].pt[3].y, sidesStart[i].pt[0].x, sidesStart[i].pt[0].y);
                }

                if (i > M * N)
                {
                    gr.DrawLine(Pens.White, sidesStart[i].pt[0].x, sidesStart[i].pt[0].y, sidesStart[i].pt[1].x, sidesStart[i].pt[1].y);
                    gr.DrawLine(Pens.White, sidesStart[i].pt[1].x, sidesStart[i].pt[1].y, sidesStart[i].pt[2].x, sidesStart[i].pt[2].y);
                    gr.DrawLine(Pens.White, sidesStart[i].pt[2].x, sidesStart[i].pt[2].y, sidesStart[i].pt[3].x, sidesStart[i].pt[3].y);
                    gr.DrawLine(Pens.White, sidesStart[i].pt[3].x, sidesStart[i].pt[3].y, sidesStart[i].pt[0].x, sidesStart[i].pt[0].y);
                }

            }
        }
        #endregion

        #region Functions
        private float expGumh(float x)
        {
            //гиперболический косинус ch, Exp(x) = e^x
            float pat;
            pat = (float)(Math.Exp(x) + Math.Exp(-x)) / 2;
            return pat;
        }
        private float expHan(float x)
        {
            //гиперболический синус sh, 
            float pat;
            pat = (float)(Math.Exp(x) - Math.Exp(-x)) / 2;
            return pat;
        }

        private void initObjectData(int numit)
        {
            odindva = 0;
            a = (float)trbA.Value / 10;
            b = (float)trbB.Value / 10;
            c = (float)trbC.Value / 10;
            M = 20; N = 25;
            a1 = -1; a2 = 1;
            b1 = 0; b2 = 2 * (float)Math.PI;

            switch (numit)
            {
                case 1:
                    a1 = 0; a2 = (float)Math.PI;
                    b1 = (float)(-Math.PI); b2 = (float)Math.PI;
                    N = 36;
                    break;

                case 2:
                    a1 = 0; a2 = 3;
                    b1 = (float)(-Math.PI); b2 = (float)(Math.PI);
                    break;

                case 3:
                    odindva = 2;
                    a1 = 0; a2 = 3;

                    break;
                case 4:
                    a1 = 0; a2 = 3;
                    break;

                case 5:
                    a1 = 0; a2 = 3;
                    b1 = 0; b2 = 2 * (float)Math.PI;
                    break;

                case 6:
                    a1 = 0; a2 = 3;
                    break;

                case 7:
                    a1 = -3; a2 = 3;
                    b1 = (float)(-Math.PI); b2 = (float)(Math.PI);
                    break;

                case 8:
                    a1 = -3; a2 = 3;
                    b1 = 0; b2 = (float)(Math.PI);
                    M = 20;
                    break;

                case 9:
                    odindva = 2;
                    a1 = -1; a2 = 1;
                    b1 = 0; b2 = (float)Math.PI;
                    M = 20;
                    break;

                case 10:
                    b = 0.35f;
                    a1 = 0; a2 = 2 * (float)Math.PI;
                    N = 31;
                    break;

            }

            nudM.Value = M;
            nudN.Value = N;
            trbA.Value = (Int32)(10 * a);
            trbB.Value = (Int32)(10 * b);
            trbC.Value = (Int32)(10 * c);
            txtA.Text = a.ToString();
            txtB.Text = b.ToString();
            txtC.Text = c.ToString();

        }
        #endregion

        #region Analytical Surfaces
        private void rbElipsoid_CheckedChanged(object sender, EventArgs e)
        {
            nnn1 = 1;
            drawSurface = true;
            initObjectData(nnn1);
            crateSurfPointArray();
            updatePicBox();

        }

        private void rbOdnopolostnoyGiperboloid_CheckedChanged(object sender, EventArgs e)
        {
            nnn1 = 2;
            drawSurface = true;
            initObjectData(nnn1);
            crateSurfPointArray();
            updatePicBox();
        }

        private void rbDvuxpolosnyGiperboloid_CheckedChanged(object sender, EventArgs e)
        {
            nnn1 = 3;
            drawSurface = true;
            initObjectData(nnn1);
            crateSurfPointArray();
            updatePicBox();
        }

        private void rbElipticheskiyKonus_CheckedChanged(object sender, EventArgs e)
        {
            nnn1 = 4;
            drawSurface = true;
            initObjectData(nnn1);
            crateSurfPointArray();
            updatePicBox();
        }

        private void rbGiperbolicheskiyParaboloid_CheckedChanged(object sender, EventArgs e)
        {
            nnn1 = 5;
            drawSurface = true;
            initObjectData(nnn1);
            crateSurfPointArray();
            updatePicBox();
        }

        private void rbElipticheskiyParaboloid_CheckedChanged(object sender, EventArgs e)
        {
            nnn1 = 6;
            drawSurface = true;
            initObjectData(nnn1);
            crateSurfPointArray();
            updatePicBox();
        }

        private void rbElipticheskiyCilinder_CheckedChanged(object sender, EventArgs e)
        {
            nnn1 = 7;
            drawSurface = true;
            initObjectData(nnn1);
            crateSurfPointArray();
            updatePicBox();
        }

        private void rbParabolicheskiyCilinder_CheckedChanged(object sender, EventArgs e)
        {
            nnn1 = 8;
            drawSurface = true;
            initObjectData(nnn1);
            crateSurfPointArray();
            updatePicBox();
        }

        private void rbGiperbolicheskiyCilinder_CheckedChanged(object sender, EventArgs e)
        {
            nnn1 = 9;
            drawSurface = true;
            initObjectData(nnn1);
            crateSurfPointArray();
            updatePicBox();
        }

        private void rbTor_CheckedChanged(object sender, EventArgs e)
        {
            nnn1 = 10;
            drawSurface = true;
            initObjectData(nnn1);
            crateSurfPointArray();
            updatePicBox();
        }

        private void rbSurf_CheckedChanged(object sender, EventArgs e)
        {
            nnn1 = 11;
            drawSurface = true;
            initObjectData(nnn1);
            crateSurfPointArray();
            updatePicBox();
        }
        #endregion

        #region Track Bars A, B, C
        private void trbA_ValueChanged(object sender, EventArgs e)
        {
            a = (float)trbA.Value / 10;
            txtA.Text = a.ToString();
            crateSurfPointArray();
            updatePicBox();

        }

        private void trbB_ValueChanged(object sender, EventArgs e)
        {
            b = (float)trbB.Value / 10;
            txtB.Text = b.ToString();
            crateSurfPointArray();
            updatePicBox();
        }

        private void trbC_ValueChanged(object sender, EventArgs e)
        {
            c = (float)trbC.Value / 10;
            txtC.Text = c.ToString();
            crateSurfPointArray();
            updatePicBox();
        }
        #endregion
    }
}
