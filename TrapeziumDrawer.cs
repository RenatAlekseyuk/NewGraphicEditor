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
                // Проверяем, что все координаты заданы (не нули)
                bool hasAllPoints = true;
                for (int i = 0; i < 8; i++)
                {
                    if (trap.point[i] == 0 && i > 0)
                    {
                        hasAllPoints = false;
                        break;
                    }
                }

                if (!hasAllPoints)
                {
                    System.Windows.MessageBox.Show("Трапеция: не все точки заданы!");
                    return;
                }

                var points = new PointCollection();
                points.Add(new Point(trap.point[0], trap.point[1])); // точка 1
                points.Add(new Point(trap.point[2], trap.point[3])); // точка 2
                points.Add(new Point(trap.point[4], trap.point[5])); // точка 3
                points.Add(new Point(trap.point[6], trap.point[7])); // точка 4

                var polygon = new Polygon
                {
                    Points = points,
                    Stroke = Brushes.Purple,
                    StrokeThickness = 3,
                    Fill = Brushes.Lavender
                };
                canvas.Children.Add(polygon);
            }
        }
    }
}