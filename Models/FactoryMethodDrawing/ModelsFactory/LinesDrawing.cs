using NewGraphicEditor.Controls;
using NewGraphicEditor.Data;
using NewGraphicEditor.Models.ModelsShapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace NewGraphicEditor.Models.FactoryMethodDrawing
{
    public class LinesDrawer : IDrawableShape
    {
        public void Draw(Canvas canvas, Shapes shape)
        {
            if (shape is Lines line)
            {
                var wpfLine = new System.Windows.Shapes.Line
                {
                    X1 = line.point[0],
                    Y1 = line.point[1],
                    X2 = line.point[2],
                    Y2 = line.point[3],
                    Stroke = Brushes.Red,
                    StrokeThickness = 2
                };
                canvas.Children.Add(wpfLine);
            }
        }
    }
}