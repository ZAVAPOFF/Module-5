using System;
using System.Drawing;
using System.Windows.Forms;

namespace Picture
{
    public partial class Form1 : Form
    {
        private Image Img;
        private int K = 1;
        private string currentShape = "Line";
        private Point startPoint;
        private Point endPoint;
        private bool drawing = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (Img != null)
                e.Graphics.DrawImage(Img, new Rectangle(10, 10, 10 * K, 10 * K));

            if (drawing)
                DrawShape(e.Graphics);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            K = trackBar1.Value;
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Img = Image.FromFile(ofd.FileName);
                pictureBox1.Invalidate();
            }
        }

        private void ShapeButton_Click(object sender, EventArgs e)
        {
            currentShape = (sender as Button).Text;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            startPoint = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                endPoint = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
            endPoint = e.Location;
            using (Graphics g = pictureBox1.CreateGraphics())
                DrawShape(g);
        }

        private void DrawShape(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            switch (currentShape)
            {
                case "Line":
                    g.DrawLine(pen, startPoint, endPoint);
                    break;
                case "Circle":
                    g.DrawEllipse(pen, GetRectangle(startPoint, endPoint));
                    break;
                case "Rectangle":
                    g.DrawRectangle(pen, GetRectangle(startPoint, endPoint));
                    break;
            }
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y),
                                 Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
        }
    }
}
