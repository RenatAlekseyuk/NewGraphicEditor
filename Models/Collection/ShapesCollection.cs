using NewGraphicEditor.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace NewGraphicEditor.Models
{
    [Serializable]
    //реализую собствыенную коллекцию фигур
    public class ShapesCollection : IEnumerable<Shapes>
    {
        private ObservableCollection<Shapes> _listShapes = new ObservableCollection<Shapes>();
        public ShapesCollection() { }
        public void Add(Shapes shape) => _listShapes.Add(shape);
        public void RemoveNewShape(Shapes shape) => _listShapes.Remove(shape);
        public IEnumerator<Shapes> GetEnumerator() => _listShapes.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public ObservableCollection<Shapes> ListShapes => _listShapes;
    }
}
