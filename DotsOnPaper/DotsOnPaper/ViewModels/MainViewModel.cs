using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using DotsOnPaper.Commands;
using DotsOnPaper.Models;

namespace DotsOnPaper.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {
        public ICommand CanvasClickCommand { get; }
        public ObservableCollection<LineModel> Lines { get;  } = new ObservableCollection<LineModel>();
        public ObservableCollection<PointModel> PointsModelR { get; } = new ObservableCollection<PointModel>();
        public ObservableCollection<PointModel> PointsModelB { get; } = new ObservableCollection<PointModel>();

        private Player _currentPlayer;
        public Player CurrentPlayer
        {
            get => _currentPlayer;
            private set
            {
                if (_currentPlayer != value)
                { 
                    _currentPlayer = value;
                    OnPropertyChanged();
                }
            }
        }


        private const double CellSize = 50;
        private const double CanvasWidth = 800;
        private const double CanvasHeight = 800;

        public MainViewModel()
        {
            CanvasClickCommand = new RelayCommand(OnCanvasClick);

            for (double x = 0; x <= CanvasWidth; x+=CellSize)
            {
                Lines.Add(new LineModel { X1 = x, Y1 = 0, X2 = x, Y2 = CanvasHeight });
            }

            for (double y = 0; y <= CanvasHeight; y += CellSize)
            {
                Lines.Add(new LineModel { X1 = 0, Y1 = y, X2 = CanvasWidth, Y2 = y });
            }
        }

        private void OnCanvasClick(object? parameter)
        {
            if (parameter is Point clickPosition)
            {
                double snappedX = Math.Round(clickPosition.X / CellSize) * CellSize;
                double snappedY = Math.Round(clickPosition.Y / CellSize) * CellSize;

                if (snappedX < 0 || snappedX > CanvasWidth || snappedY < 0 || snappedY > CanvasHeight)
                {
                    return;
                }

                if (PointsModelR.Any(p => p.X == snappedX && p.Y == snappedY) || PointsModelB.Any(p => p.X == snappedX && p.Y == snappedY))
                {
                    return; 
                }
                var newPoint = new PointModel { X = snappedX, Y = snappedY };

                if (CurrentPlayer == Player.Player1)
                {
                    PointsModelR.Add(newPoint);
                    CurrentPlayer = Player.Player2;
                }
                else
                {
                    PointsModelB.Add(newPoint);
                    CurrentPlayer = Player.Player1;
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
