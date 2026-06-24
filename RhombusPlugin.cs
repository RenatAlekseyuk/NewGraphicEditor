using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ForeignRhombusPlugin
{
    public class RhombusPlugin : IRhombusPlugin
    {
        private int[] _points = new int[8];

        public string GetName() => "Ромб";
        public string GetDescription() => "Ромб: четыре равные стороны";

        public int[] GetPoints() => _points;

        public void SetPoints(int[] points)
        {
            if (points != null && points.Length == 8)
                _points = points;
        }

        public void Render(object canvas)
        {
            if (canvas is Canvas c)
            {
                var points = new PointCollection();
                for (int i = 0; i < 8; i += 2)
                {
                    points.Add(new Point(_points[i], _points[i + 1]));
                }

                var polygon = new Polygon
                {
                    Points = points,
                    Stroke = Brushes.Orange,
                    StrokeThickness = 3,
                    Fill = Brushes.LightYellow
                };
                c.Children.Add(polygon);
            }
        }
    }
}