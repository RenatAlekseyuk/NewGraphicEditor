using NewGraphicEditor.Data;

namespace TrapeziumPlugin
{
    public class Trapezium : Shapes
    {
        // Своё поле для координат (не трогает Shapes.point)
        public int[] MyPoints { get; set; } = new int[8];

        // Реализуем point только для чтения (get)
        public override int[] point
        {
            get { return MyPoints; }
        }

        public override string nameShapes => "Trapezium";
        protected override int countPoint => 8;

        public Trapezium()
        {
            NameShape = "Трапеция";
            Info = "Введите 4 точки (8 координат)";
        }
    }
}