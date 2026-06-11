using NewGraphicEditor.Controls;
using NewGraphicEditor.Data;
using NewGraphicEditor.Models.ModelsShapes;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace NewGraphicEditor.Models.FactoryMethodDrawing
{
    /// <summary>
    /// Drawer ONLY for Ellipse shapes (not for Circle)
    /// </summary>
    public class EllipseDrawing : IDrawableShape
    {
        public void Draw(Canvas canvas, Shapes shape)
        {
            // Рисуем ТОЛЬКО если это Ellipses 
            if (shape is Ellipses ellipse && !(shape is Circle))
            {
                double width = Math.Abs(ellipse.point[2] - ellipse.point[0]) * 2;
                double height = Math.Abs(ellipse.point[5] - ellipse.point[1]) * 2;

                var ellipce = new System.Windows.Shapes.Ellipse
                {
                    Width = width,
                    Height = height,
                    Stroke = Brushes.Orange,
                    Fill = Brushes.LightYellow,
                    StrokeThickness = 2
                };

                Canvas.SetLeft(ellipce, ellipse.point[0] - (width / 2));
                Canvas.SetTop(ellipce, ellipse.point[1] - (height / 2));
                canvas.Children.Add(ellipce);
            }
        }
    }
}