using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicApp
{
    public partial class Form1 : Form
    {
        private Point startPoint;
        private Point endPoint;
        private bool drawing;
        private string currentShape = "Line";
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);

            var panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            this.Controls.Add(panel);

            var lineButton = new Button { Text = "Линия", Dock = DockStyle.Top };
            var circleButton = new Button { Text = "Круг", Dock = DockStyle.Top };
            var rectangleButton = new Button { Text = "Прямоугольник", Dock = DockStyle.Top };

            lineButton.Click += (s, e) => currentShape = "Line";
            circleButton.Click += (s, e) => currentShape = "Circle";
            rectangleButton.Click += (s, e) => currentShape = "Rectangle";

            var buttonPanel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 30 };
            buttonPanel.Controls.Add(lineButton);
            buttonPanel.Controls.Add(circleButton);
            buttonPanel.Controls.Add(rectangleButton);

            this.Controls.Add(buttonPanel);

            panel.MouseDown += (s, e) =>
            {
                drawing = true;
                startPoint = e.Location;
            };

            panel.MouseMove += (s, e) =>
            {
                if (drawing)
                {
                    endPoint = e.Location;
                    panel.Invalidate();
                }
            };

            panel.MouseUp += (s, e) =>
            {
                drawing = false;
                endPoint = e.Location;
                using (Graphics g = panel.CreateGraphics())
                {
                    DrawShape(g);
                }
            };

            panel.Paint += (s, e) =>
            {
                if (drawing)
                {
                    DrawShape(e.Graphics);
                }
            };
        }

        private void DrawShape(Graphics g)
        {
            switch (currentShape)
            {
                case "Line":
                    g.DrawLine(Pens.Black, startPoint, endPoint);
                    break;
                case "Circle":
                    g.DrawEllipse(Pens.Black, GetRectangle(startPoint, endPoint));
                    break;
                case "Rectangle":
                    g.DrawRectangle(Pens.Black, GetRectangle(startPoint, endPoint));
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


    

