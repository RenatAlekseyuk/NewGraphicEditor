using NewGraphicEditor.Controls;
using NewGraphicEditor.Data;
using NewGraphicEditor.Models.FactoryMethodDrawing;
using NewGraphicEditor.Models.FactoryMethodDrawing.FactoryDrawingPolygonsShape;
using NewGraphicEditor.Models.ModelsShapes;
using System;
using System.Collections.Generic;

namespace NewGraphicEditor.Models
{
    /// <summary>
    /// Factory for obtaining shape drawers
    /// Factory Method pattern for polymorphic drawing
    /// NO PLUGINS - pure Factory Pattern
    /// </summary>
    public static class DrawerFactory
    {
        private static Dictionary<Type, IDrawableShape> _drawers = new Dictionary<Type, IDrawableShape>();

        static DrawerFactory()
        {
            // Register all shape-drawer pairs (built-in only, no plugins)
            _drawers[typeof(Lines)] = new LinesDrawer();
            _drawers[typeof(Triangle)] = new TriangleDrawing();
            _drawers[typeof(Ellipses)] = new EllipseDrawing();
            _drawers[typeof(Circle)] = new CircleDrawing();
            _drawers[typeof(Rectangles)] = new RectanglesDrawing();
            _drawers[typeof(ClientModel)] = new ClientModelFactory();
        }

        public static IDrawableShape GetDrawer(Shapes shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            Type shapeType = shape.GetType();

            if (_drawers.ContainsKey(shapeType))
            {
                return _drawers[shapeType];
            }

            throw new ArgumentException($"Unknown shape type: {shapeType.Name}");
        }
    }
}