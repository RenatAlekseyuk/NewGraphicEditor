using NewGraphicEditor.Data;

namespace NewGraphicEditor.Models.ModelsShapes
{
    public class ClientModel : Shapes
    {
        private int[] _point = new int[10]; // 5 точек = 10 координат
        public override int[] point => _point;
        public override string nameShapes => "ClientModel";
        protected override int countPoint => 10;

        public ClientModel()
        {
            NameShape = "Пользовательская фигура";
            Info = "5 точек для пятиугольника";
        }
    }
}