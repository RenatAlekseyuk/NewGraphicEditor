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
    /// Factory for getting shape drawers
    /// No switch/if - uses Dictionary
    /// </summary>
    public static class DrawerFactory
    {
        private static Dictionary<Type, IDrawableShape> _drawers = new Dictionary<Type, IDrawableShape>();

        static DrawerFactory()
        {
            // Register all shape-drawer pairs
            _drawers.Add(typeof(Lines), new LinesDrawer());
            _drawers.Add(typeof(Triangle), new TriangleDrawing());
            _drawers.Add(typeof(Circle), new CircleDrawing());
            _drawers.Add(typeof(Ellipses), new EllipseDrawing());
            _drawers.Add(typeof(Rectangles), new RectanglesDrawing());
            _drawers.Add(typeof(ClientModel), new ClientModelFactory());
        }

        public static IDrawableShape GetDrawer(Shapes shape)
        {
            if (shape == null)
            {
                throw new ArgumentNullException("shape");
            }

            Type shapeType = shape.GetType();

            if (_drawers.ContainsKey(shapeType))
            {
                return _drawers[shapeType];
            }

            throw new ArgumentException("Unknown shape type: " + shapeType.Name);
        }
    }
}