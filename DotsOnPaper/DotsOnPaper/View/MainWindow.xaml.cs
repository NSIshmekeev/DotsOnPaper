using DotsOnPaper.Models;
using DotsOnPaper.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotsOnPaper
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(GridCanvas);

            if (DataContext is MainViewModel vm && vm.CanvasClickCommand.CanExecute(null))
            {
                vm.CanvasClickCommand.Execute(pos);
            }
        }
    }
}