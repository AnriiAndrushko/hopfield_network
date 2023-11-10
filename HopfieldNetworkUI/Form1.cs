namespace HopfieldNetworkUI
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;
        private Bitmap canvas;
        private int MHeight = 10;
        private int MWidth = 10;
        private Color penColor = Color.Black;
        private int cellWidth, cellHeight;
        private HopfieldNetwork net;
        private List<Image> savedPatterns = new();
        private Image? currentSavedPattern = null;
        private int savedPhotoIndex = -1;

        private double[,] paintingField;

        public Form1()
        {
            InitializeComponent();
            net = new HopfieldNetwork(MHeight, MWidth);
            paintingField = new double[MHeight, MWidth];
            for (int i = 0; i< MHeight; i++)
            {
                for (int j = 0; j < MWidth; j++)
                {
                    paintingField[i, j] = -1;
                }
            }
            pictureBox1.Height -= pictureBox1.Height%MWidth-1;
            pictureBox1.Width -= pictureBox1.Width % MHeight-1;
            cellWidth = pictureBox1.Width / MWidth;
            cellHeight = pictureBox1.Height / MHeight;

            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
            }

            pictureBox1.Image = canvas;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (Pen p = new Pen(Color.Black)) {
                for (int y = 0; y <= MHeight; y++)
                {
                    g.DrawLine(p, 0, y * cellHeight, pictureBox1.Width, y * cellHeight);
                }

                for (int x = 0; x <= MWidth; x++)
                {
                    g.DrawLine(p, x * cellWidth, 0, x * cellWidth, pictureBox1.Height);
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(canvas))
                {
                    using (Pen pen = new Pen(penColor, 2))
                    {
                        int x = e.X / cellWidth * cellWidth;
                        int y = e.Y / cellHeight * cellHeight;
                        g.FillRectangle(pen.Brush, x, y, cellWidth, cellHeight);
                        if ((y / cellHeight<MHeight)&&(x/ cellWidth<MWidth)&&x>=0&&y>=0)
                        {
                            paintingField[y / cellHeight, x / cellWidth] = penColor == Color.Black ? 1 : -1;
                        }
                    }
                }
                pictureBox1.Invalidate();
            }
        }

        private void swichErather_Click(object sender, EventArgs e)
        {
            penColor = Color.White;
        }

        private void swichPen_Click(object sender, EventArgs e)
        {
            penColor = Color.Black;
        }

        private void addToNet_Click(object sender, EventArgs e)
        {
            if (savedPhotoIndex == -1)
            {
                savedPhotoIndex = 0;
            }
            net.AddData(paintingField);
            Image toAdd = Resize(pictureBox1.Image, savedPhotos.Width, savedPhotos.Height);
            savedPatterns.Add(toAdd);
            savedPhotos.Image = toAdd;
            savedPhotos.Invalidate();
            ClearGrid();
        }
        private Image Resize(Image img, int iWidth, int iHeight)
        {
            Bitmap bmp = new Bitmap(iWidth, iHeight);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(img, 0, 0, iWidth, iHeight);

            return (Image)bmp;
        }

        private void ClearGrid()
        {
            paintingField = new double[MHeight, MWidth];
            for (int i = 0; i < MHeight; i++)
            {
                for (int j = 0; j < MWidth; j++)
                {
                    paintingField[i, j] = -1;
                }
            }
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
            }
            pictureBox1.Image = canvas;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearGrid();
        }

        private void solveBtn_Click(object sender, EventArgs e)
        {
            var tmp = net.Predict(paintingField);
            if (tmp == null)
            {
                return;
            }
            double[,] result = tmp;

            paintingField = new double[MHeight, MWidth];
            for (int i = 0; i < MHeight; i++)
            {
                for (int j = 0; j < MWidth; j++)
                {
                    paintingField[i, j] = -1;
                }
            }

            double[,] res = new double[MHeight, MWidth];

            int m = 0;
            int k = 0;
            for (int j = 0; j < MWidth * MHeight; j++)
            {
                res[k, m] = result[j, 0];
                m++;
                if (m >= MWidth) { m = 0; k++; if (k >= MHeight) { k = 0; } };
            }

            using (Graphics g = Graphics.FromImage(canvas))
            {
                using (Pen pen = new Pen(penColor, 2))
                {
                    for (int i = 0; i < MHeight; i++)
                    {
                        for (int j = 0; j < MWidth; j++)
                        {

                            int x = j * cellWidth;
                            int y = i * cellHeight;
                            pen.Color = res[i,j]==-1?Color.White:Color.Black;
                            paintingField[i, j] = res[i, j];
                            g.FillRectangle(pen.Brush, x, y, cellWidth, cellHeight);
                        }
                    }

                    pictureBox1.Invalidate();
                }
            }
        }

        private void clearDataBtn_Click(object sender, EventArgs e)
        {
            net.ClearMemory();
            ClearGrid();
            savedPatterns.Clear();
            currentSavedPattern = null;
            savedPhotos.Image = null;
            savedPhotoIndex = -1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            canvas.Dispose();
        }

        private void rightBtn_Click(object sender, EventArgs e)
        {
            if (savedPhotoIndex==-1)
            {
                return;
            }

            savedPhotoIndex++;
            if (savedPhotoIndex>=savedPatterns.Count)
            {
                savedPhotoIndex = 0;
            }
            currentSavedPattern = savedPatterns[savedPhotoIndex];
            savedPhotos.Image = currentSavedPattern;
            savedPhotos.Invalidate();
        }

        private void leftBtn_Click(object sender, EventArgs e)
        {
            if (savedPhotoIndex == -1)
            {
                return;
            }
            savedPhotoIndex--;
            if (savedPhotoIndex < 0)
            {
                savedPhotoIndex = savedPatterns.Count-1;
            }
            currentSavedPattern = savedPatterns[savedPhotoIndex];
            savedPhotos.Image = currentSavedPattern;
            savedPhotos.Invalidate();
        }

    }
}