using System;
using System.Collections.Generic;
using NewGraphicEditor.Data;
using NewGraphicEditor.Models.ModelsShapes;

namespace NewGraphicEditor.Models
{
    public static class ShapeFactory
    {
        private static Dictionary<string, Func<Shapes>> _creators = new Dictionary<string, Func<Shapes>>();

        static ShapeFactory()
        {
            _creators.Add("Отрезок", () => new Lines());
            _creators.Add("Треугольник", () => new Triangle());
            _creators.Add("Круг", () => new Circle());
            _creators.Add("Эллипс", () => new Ellipses());
            _creators.Add("Прямоугольник", () => new Rectangles());
            _creators.Add("Пятиугольник", () => new ClientModel());
        }

        public static Shapes Create(string shapeName)
        {
            if (_creators.ContainsKey(shapeName))
            {
                return _creators[shapeName]();
            }
            throw new ArgumentException("Unknown shape: " + shapeName);
        }

        public static List<string> GetShapeNames()
        {
            return new List<string>(_creators.Keys);
        }
    }
}