using NewGraphicEditor.Controls;
using NewGraphicEditor.Data;
using NewGraphicEditor.Models;
using NewGraphicEditor.Models.ModelsShapes;
using System.Windows.Controls;

namespace NewGraphicEditor.ViewModels
{
    public class ApplicationMainClass
    {
        public ShapesCollection CollectionShapes { get; set; }

        public ApplicationMainClass()
        {
            CollectionShapes = new ShapesCollection();
            AddSixDifferentShapes();
        }

        private void AddSixDifferentShapes()
        {
            // 1. ОТРЕЗОК (Line)
            var line = new Lines { NameShape = "Отрезок" };
            line.point[0] = 50;
            line.point[1] = 50;
            line.point[2] = 200;
            line.point[3] = 50;
            CollectionShapes.Add(line);

            // 2. ТРЕУГОЛЬНИК (Triangle)
            var triangle = new Triangle { NameShape = "Треугольник" };
            triangle.point[0] = 80;
            triangle.point[1] = 120;
            triangle.point[2] = 30;
            triangle.point[3] = 190;
            triangle.point[4] = 130;
            triangle.point[5] = 190;
            CollectionShapes.Add(triangle);

            // 3. КРУГ (Circle) - отдельный класс!
            var circle = new Circle { NameShape = "Круг" };
            circle.point[0] = 300;
            circle.point[1] = 80;   // центр
            circle.point[2] = 350;
            circle.point[3] = 80;   // радиус X
            circle.point[4] = 300;
            circle.point[5] = 130;  // радиус Y (равен радиусу X для круга)
            CollectionShapes.Add(circle);

            // 4. ЭЛЛИПС (Ellipse) - вытянутый
            var ellipse = new Ellipses { NameShape = "Эллипс" };
            ellipse.point[0] = 80;
            ellipse.point[1] = 310;
            ellipse.point[2] = 130;
            ellipse.point[3] = 250;
            ellipse.point[4] = 80;
            ellipse.point[5] = 330;
            CollectionShapes.Add(ellipse);

            // 5. ПРЯМОУГОЛЬНИК (Rectangle)
            var rectangle = new Rectangles { NameShape = "Прямоугольник" };
            rectangle.point[0] = 200;
            rectangle.point[1] = 240;  // верхний левый
            rectangle.point[2] = 200;
            rectangle.point[3] = 330;  // нижний левый
            rectangle.point[4] = 350;
            rectangle.point[5] = 240;  // верхний правый
            CollectionShapes.Add(rectangle);

            // 6. ПЯТИУГОЛЬНИК (ClientModel)
            var pentagon = new ClientModel { NameShape = "Пятиугольник" };
            pentagon.point[0] = 450;
            pentagon.point[1] = 140;
            pentagon.point[2] = 410;
            pentagon.point[3] = 200;
            pentagon.point[4] = 440;
            pentagon.point[5] = 260;
            pentagon.point[6] = 500;
            pentagon.point[7] = 260;
            pentagon.point[8] = 530;
            pentagon.point[9] = 200;
            CollectionShapes.Add(pentagon);
        }

        public void DrawAllShapes(Canvas canvas)
        {
            canvas.Children.Clear();

            foreach (var shape in CollectionShapes)
            {
                var drawer = DrawerFactory.GetDrawer(shape);
                drawer?.Draw(canvas, shape);
            }
        }
    }
}