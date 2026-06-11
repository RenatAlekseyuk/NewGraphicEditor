using NewGraphicEditor.Controls;
using NewGraphicEditor.Data;
using NewGraphicEditor.Models.ModelsShapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NewGraphicEditor.Models.FactoryMethodDrawing
{
    public class ClientModelFactory : IDrawableShape
    {
        public void Draw(Canvas canvas, Shapes shape)
        {
            if (shape is ClientModel model)
            {
                var points = new PointCollection();

                // Собираем все точки, которые не равны 0
                for (int i = 0; i < model.point.Length && i < 10; i += 2)
                {
                    // Пропускаем нулевые координаты (если точка не задана)
                    if (model.point[i] == 0 && model.point[i + 1] == 0 && i > 0)
                        continue;
                    points.Add(new Point(model.point[i], model.point[i + 1]));
                }

                if (points.Count >= 3)
                {
                    var polygon = new System.Windows.Shapes.Polygon
                    {
                        Points = points,
                        Stroke = Brushes.Purple,
                        StrokeThickness = 2,
                        Fill = Brushes.Lavender
                    };
                    canvas.Children.Add(polygon);
                }
            }
        }
    }
}