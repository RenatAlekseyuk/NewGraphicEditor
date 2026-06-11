using NewGraphicEditor.ViewModels;
using System.Windows;

namespace NewGraphicEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Get ViewModel and draw shapes automatically
            if (DataContext is ApplicationMainClass vm)
            {
                vm.DrawAllShapes(MyCanvas);
            }
        }
    }
}