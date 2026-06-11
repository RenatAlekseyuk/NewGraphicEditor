using NewGraphicEditor.Data;

namespace NewGraphicEditor.Models.ModelsShapes
{
    /// <summary>
    /// Circle shape (subclass of Ellipses with equal radius)
    /// </summary>
    public class Circle : Ellipses
    {
        private int[] _point = new int[6];
        public override int[] point => _point;
        public override string nameShapes => "Circle";
        protected override int countPoint => 6;

        public Circle()
        {
            NameShape = "Круг";
            Info = "Поочередно вводить координаты: (x центра, y центра); (x, y радиус); (x, y радиус)";
        }
    }
}