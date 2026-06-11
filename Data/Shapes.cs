using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace NewGraphicEditor.Data
{
    [Serializable]
    public abstract class Shapes : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _nameShape;
        public string NameShape
        {
            get { return _nameShape; }
            set
            {
                _nameShape = value;
                OnPropertyChanged(nameof(NameShape));
            }
        }

        [XmlIgnore]
        public abstract int[] point { get; }

        [XmlIgnore]
        public abstract string nameShapes { get; }

        [XmlIgnore]
        protected abstract int countPoint { get; }

        private string _info;
        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;
                OnPropertyChanged(nameof(Info));
            }
        }

        public Shapes()
        {
        }
    }
}