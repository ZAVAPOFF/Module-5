using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicApp
{
    public partial class Form1 : Form
    {
        private Point startPoint;
        private Point endPoint;
        private bool drawing;
        private string currentShape = "Line";
        private List<Shape> shapes = new List<Shape>();

        public Form1()
        {
            InitializeComponent();

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
                shapes.Add(new Shape(currentShape, startPoint, endPoint));
                panel.Invalidate();
            };

            panel.Paint += (s, e) =>
            {
                foreach (var shape in shapes)
                {
                    shape.Draw(e.Graphics);
                }

                if (drawing)
                {
                    DrawShape(e.Graphics);
                }
            };
        }

        private void DrawShape(Graphics g)
        {
            Pen pen = Pens.Black;

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

    public class Shape
    {
        public string ShapeType { get; }
        public Point StartPoint { get; }
        public Point EndPoint { get; }

        public Shape(string shapeType, Point startPoint, Point endPoint)
        {
            ShapeType = shapeType;
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public void Draw(Graphics g)
        {
            Pen pen = Pens.Black;
            switch (ShapeType)
            {
                case "Line":
                    g.DrawLine(pen, StartPoint, EndPoint);
                    break;
                case "Circle":
                    g.DrawEllipse(pen, GetRectangle(StartPoint, EndPoint));
                    break;
                case "Rectangle":
                    g.DrawRectangle(pen, GetRectangle(StartPoint, EndPoint));
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
