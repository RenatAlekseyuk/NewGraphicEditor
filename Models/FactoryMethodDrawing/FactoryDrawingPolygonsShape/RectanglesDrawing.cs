using NewGraphicEditor.Controls;
using NewGraphicEditor.Data;
using NewGraphicEditor.Models.ModelsShapes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NewGraphicEditor.Models.FactoryMethodDrawing.FactoryDrawingPolygonsShape
{
    public class RectanglesDrawing : PolygonDrawing
    {
        public override void Draw(Canvas canvas, Shapes shape)
        {
            if (shape is Rectangles rc)
            {
                // Для прямоугольника нужно 3 точки: 
                // точка 1 (x1,y1) - верхний левый угол
                // точка 2 (x2,y2) - нижний левый угол  
                // точка 3 (x3,y3) - верхний правый угол

                double x1 = rc.point[0];
                double y1 = rc.point[1];
                double x2 = rc.point[2];
                double y2 = rc.point[3];
                double x3 = rc.point[4];
                double y3 = rc.point[5];

                // Вычисляем 4-ю точку (нижний правый угол)
                double x4 = x3 + (x2 - x1);
                double y4 = y2 + (y3 - y1);

                var points = new PointCollection();
                points.Add(new Point(x1, y1)); // верхний левый
                points.Add(new Point(x2, y2)); // нижний левый
                points.Add(new Point(x4, y4)); // нижний правый
                points.Add(new Point(x3, y3)); // верхний правый

                var rectangle = new System.Windows.Shapes.Polygon
                {
                    Points = points,
                    Stroke = Brushes.Blue,
                    StrokeThickness = 2,
                    Fill = Brushes.LightBlue
                };
                canvas.Children.Add(rectangle);
            }
        }
    }
}