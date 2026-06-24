using NewGraphicEditor.Data;
using NewGraphicEditor.Controls;
using NewGraphicEditor.PluginInterfaces;

namespace TrapeziumPlugin
{
    public class TrapeziumPluginEntry : IShapePlugin
    {
        public string ShapeTypeName => "Трапеция";

        public Shapes CreateShape()
        {
            return new Trapezium();
        }

        public IDrawableShape GetDrawer()
        {
            return new TrapeziumDrawer();
        }
    }
}