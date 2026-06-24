using NewGraphicEditor.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace NewGraphicEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyCanvas.MouseLeftButtonDown += MyCanvas_MouseLeftButtonDown;
        }

        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(MyCanvas);
            if (DataContext is ApplicationMainClass vm)
            {
                vm.InputX = (int)pos.X;
                vm.InputY = (int)pos.Y;
            }
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}