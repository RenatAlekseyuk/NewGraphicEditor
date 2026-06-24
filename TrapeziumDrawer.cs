using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using NewGraphicEditor.Controls;
using NewGraphicEditor.Data;

namespace TrapeziumPlugin
{
    public class TrapeziumDrawer : IDrawableShape
    {
        public void Draw(Canvas canvas, Shapes shape)
        {
            if (shape is Trapezium trap)
            {
                // Трапеция: 4 точки = 8 координат
                // Точка 1: верхнее левое основание
                // Точка 2: верхнее правое основание  
                // Точка 3: нижнее правое основание
                // Точка 4: нижнее левое основание

                double x1 = trap.point[0];
                double y1 = trap.point[1];
                double x2 = trap.point[2];
                double y2 = trap.point[3];
                double x3 = trap.point[4];
                double y3 = trap.point[5];
                double x4 = trap.point[6];
                double y4 = trap.point[7];

                var points = new PointCollection();
                points.Add(new Point(x1, y1)); // верхняя левая
                points.Add(new Point(x2, y2)); // верхняя правая
                points.Add(new Point(x3, y3)); // нижняя правая
                points.Add(new Point(x4, y4)); // нижняя левая

                var polygon = new Polygon
                {
                    Points = points,
                    Stroke = Brushes.Purple,
                    StrokeThickness = 3,
                    Fill = Brushes.Lavender
                };
                canvas.Children.Add(polygon);

                // Рисуем точки для наглядности
                DrawPoint(canvas, x1, y1, Brushes.Red);
                DrawPoint(canvas, x2, y2, Brushes.Red);
                DrawPoint(canvas, x3, y3, Brushes.Red);
                DrawPoint(canvas, x4, y4, Brushes.Red);
            }
        }

        private void DrawPoint(Canvas canvas, double x, double y, Brush color)
        {
            var point = new Ellipse
            {
                Width = 5,
                Height = 5,
                Fill = color
            };
            Canvas.SetLeft(point, x - 2.5);
            Canvas.SetTop(point, y - 2.5);
            canvas.Children.Add(point);
        }
    }
}