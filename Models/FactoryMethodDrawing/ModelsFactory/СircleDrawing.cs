using NewGraphicEditor.Controls;
using NewGraphicEditor.Data;
using NewGraphicEditor.Models.ModelsShapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace NewGraphicEditor.Models.FactoryMethodDrawing
{
    /// <summary>
    /// Drawer specifically for Circle shapes
    /// </summary>
    public class CircleDrawing : IDrawableShape
    {
        public void Draw(Canvas canvas, Shapes shape)
        {
            if (shape is Circle circle)
            {
                // Вычисляем радиус (расстояние от центра до точки радиуса)
                double radiusX = System.Math.Abs(circle.point[2] - circle.point[0]);
                double radiusY = System.Math.Abs(circle.point[5] - circle.point[1]);
                double radius = (radiusX + radiusY) / 2; // средний радиус для круга

                var ellipse = new System.Windows.Shapes.Ellipse
                {
                    Width = radius * 2,
                    Height = radius * 2,
                    Stroke = Brushes.Red,
                    Fill = Brushes.LightCoral,
                    StrokeThickness = 2
                };

                Canvas.SetLeft(ellipse, circle.point[0] - radius);
                Canvas.SetTop(ellipse, circle.point[1] - radius);
                canvas.Children.Add(ellipse);
            }
        }
    }
}