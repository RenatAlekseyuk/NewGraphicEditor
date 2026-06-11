using NewGraphicEditor.Controls;
using NewGraphicEditor.Data;
using NewGraphicEditor.Models;
using NewGraphicEditor.Models.ModelsShapes;
using NewGraphicEditor.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace NewGraphicEditor.ViewModels
{
    /// <summary>
    /// Lab 2: Graphic Editor
    /// - UI shape creation (ComboBox + Create button)
    /// - No switch/if (using ShapeFactory with Dictionary)
    /// - Shapes don't contain Draw method (separate drawers)
    /// </summary>
    public class ApplicationMainClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        // Collections
        public ShapesCollection CollectionShapes { get; set; }
        public ObservableCollection<string> ShapeTypeNames { get; set; }

        // Selected items
        private Shapes _selectedShape;
        public Shapes SelectedShape
        {
            get { return _selectedShape; }
            set
            {
                _selectedShape = value;
                OnPropertyChanged("SelectedShape");
            }
        }

        private string _selectedShapeType;
        public string SelectedShapeType
        {
            get { return _selectedShapeType; }
            set
            {
                _selectedShapeType = value;
                OnPropertyChanged("SelectedShapeType");
            }
        }

        // Coordinates input
        private int _inputX;
        public int InputX
        {
            get { return _inputX; }
            set
            {
                _inputX = value;
                OnPropertyChanged("InputX");
            }
        }

        private int _inputY;
        public int InputY
        {
            get { return _inputY; }
            set
            {
                _inputY = value;
                OnPropertyChanged("InputY");
            }
        }

        private int _currentPointIndex = 0;

        // Commands
        private ApplicationCommands _createShapeCommand;
        private ApplicationCommands _addPointCommand;
        private ApplicationCommands _drawAllShapesCommand;
        private ApplicationCommands _deleteShapeCommand;

        // Constructor
        public ApplicationMainClass()
        {
            CollectionShapes = new ShapesCollection();
            ShapeTypeNames = new ObservableCollection<string>(ShapeFactory.GetShapeNames());

            if (ShapeTypeNames.Count > 0)
                SelectedShapeType = ShapeTypeNames[0];
        }

        // ============ COMMANDS PROPERTIES ============

        public ApplicationCommands CreateShapeCommand
        {
            get
            {
                if (_createShapeCommand == null)
                {
                    _createShapeCommand = new ApplicationCommands(obj =>
                    {
                        if (string.IsNullOrEmpty(SelectedShapeType)) return;

                        Shapes newShape = ShapeFactory.Create(SelectedShapeType);
                        newShape.NameShape = SelectedShapeType;
                        newShape.Info = "Выберите " + (GetPointsCount(newShape) / 2) + " точек";

                        CollectionShapes.Add(newShape);
                        SelectedShape = newShape;

                        MessageBox.Show("Создана фигура: " + SelectedShapeType, "Успех",
                                       MessageBoxButton.OK, MessageBoxImage.Information);
                    });
                }
                return _createShapeCommand;
            }
        }

        public ApplicationCommands AddPointCommand
        {
            get
            {
                if (_addPointCommand == null)
                {
                    _addPointCommand = new ApplicationCommands(obj =>
                    {
                        var canvas = obj as Canvas;
                        if (canvas == null || SelectedShape == null) return;

                        int needed = GetPointsCount(SelectedShape);

                        if (_currentPointIndex < SelectedShape.point.Length)
                        {
                            SelectedShape.point[_currentPointIndex] = InputX;
                            SelectedShape.point[_currentPointIndex + 1] = InputY;
                            _currentPointIndex += 2;

                            SelectedShape.Info = "Точка (" + InputX + "," + InputY + "). Осталось: " + ((needed - _currentPointIndex) / 2);

                            if (_currentPointIndex >= needed)
                            {
                                var drawer = DrawerFactory.GetDrawer(SelectedShape);
                                if (drawer != null)
                                    drawer.Draw(canvas, SelectedShape);

                                _currentPointIndex = 0;
                                SelectedShape.Info = "Фигура готова!";
                                InputX = 0;
                                InputY = 0;

                                // Redraw all shapes
                                var drawCmd = DrawAllShapesCommand;
                                if (drawCmd != null)
                                    drawCmd.Execute(canvas);
                            }
                        }
                    });
                }
                return _addPointCommand;
            }
        }

        public ApplicationCommands DrawAllShapesCommand
        {
            get
            {
                if (_drawAllShapesCommand == null)
                {
                    _drawAllShapesCommand = new ApplicationCommands(obj =>
                    {
                        var canvas = obj as Canvas;
                        if (canvas == null) return;

                        canvas.Children.Clear();
                        foreach (var shape in CollectionShapes)
                        {
                            var drawer = DrawerFactory.GetDrawer(shape);
                            if (drawer != null)
                                drawer.Draw(canvas, shape);
                        }
                    });
                }
                return _drawAllShapesCommand;
            }
        }

        public ApplicationCommands DeleteShapeCommand
        {
            get
            {
                if (_deleteShapeCommand == null)
                {
                    _deleteShapeCommand = new ApplicationCommands(obj =>
                    {
                        if (SelectedShape != null)
                        {
                            CollectionShapes.RemoveNewShape(SelectedShape);
                            if (CollectionShapes.ListShapes.Count > 0)
                                SelectedShape = CollectionShapes.ListShapes[0];
                            else
                                SelectedShape = null;

                            MessageBox.Show("Фигура удалена");
                        }
                    },
                    obj => SelectedShape != null);
                }
                return _deleteShapeCommand;
            }
        }

        // Helper: get required points count for shape
        private int GetPointsCount(Shapes shape)
        {
            if (shape is Lines) return 4;
            if (shape is Triangle) return 6;
            if (shape is Circle) return 6;
            if (shape is Ellipses) return 6;
            if (shape is Rectangles) return 8;
            if (shape is ClientModel) return 10;
            return 6;
        }
    }
}