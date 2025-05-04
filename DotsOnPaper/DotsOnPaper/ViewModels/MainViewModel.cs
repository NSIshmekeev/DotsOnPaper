using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Shapes;
using DotsOnPaper.Models;
namespace DotsOnPaper.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<LineModel> Lines { get; } = new();

        private double _canvasWidth = 600;
        public double CanvasWidth
        {
            get => _canvasWidth;
            set
            {
                if (_canvasWidth != value)
                {
                    _canvasWidth = value;
                    OnPropertyChanged(nameof(CanvasWidth));
                    GenerateGrid();
                }
            }
        }

        private double _canvasHeight = 600;
        public double CanvasHeight
        {
            get => _canvasHeight;
            set
            {
                if (_canvasHeight != value)
                {
                    _canvasHeight = value;
                    OnPropertyChanged(nameof(CanvasHeight));
                    GenerateGrid();
                }
            }
        }

        private const double CellSize = 50;

        public MainViewModel()
        {
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            Lines.Clear();

            for (double x = 0; x <= CanvasWidth; x += CellSize)
            {
                Lines.Add(new LineModel { X1 = x, Y1 = 0, X2 = x, Y2 = CanvasHeight });
            }

            for (double y = 0; y <= CanvasHeight; y += CellSize)
            {
                Lines.Add(new LineModel { X1 = 0, Y1 = y, X2 = CanvasWidth, Y2 = y });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
