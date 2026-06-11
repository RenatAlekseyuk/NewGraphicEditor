using NewGraphicEditor.Controls;
using NewGraphicEditor.Data;
using NewGraphicEditor.Models.ModelsShapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NewGraphicEditor.Models.FactoryMethodDrawing
{
    public class TriangleDrawing : IDrawableShape
    {
        public void Draw(Canvas canvas, Shapes shape)
        {
            if (shape is Triangle triangle)
            {
                var points = new PointCollection();
                for (int i = 0; i < 6; i += 2)
                {
                    points.Add(new Point(triangle.point[i], triangle.point[i + 1]));
                }

                var polygon = new System.Windows.Shapes.Polygon
                {
                    Points = points,
                    Stroke = Brushes.Green,
                    StrokeThickness = 2,
                    Fill = Brushes.LightGreen
                };
                canvas.Children.Add(polygon);
            }
        }
    }
}