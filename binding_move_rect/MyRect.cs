using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows;
using System.ComponentModel;
using System.Windows.Media;

namespace binding_move_rect
{
    internal class MyRect : Border, INotifyPropertyChanged
    {
        Point _downPoint;
        bool _isDragMode;
        double _left = 100;
        double _top = 100;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_isDragMode)
            {
                Point currentPos = e.GetPosition(this);
                Point delta = new Point(currentPos.X - _downPoint.X, currentPos.Y - _downPoint.Y);

                _left = (int)(Canvas.GetLeft(this) + delta.X);
                LeftRect = _left;
                _top = (int)(Canvas.GetTop(this) + delta.Y);
                TopRect = _top;

                Canvas.SetLeft(this, _left);
                Canvas.SetTop(this, _top);
            }
            
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            _downPoint = e.GetPosition(this);
            _isDragMode = true;

            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            _isDragMode = false;
            base.OnMouseUp(e);
        }
        public double LeftRect
        {
            get => _left;
            set
            {
                this._left = value;
                Canvas.SetLeft(this, _left);
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(LeftRect)));
            }
        }
        public double TopRect
        {
            get => _top;
            set
            {
                this._top = value;
                Canvas.SetTop(this, _top);
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(TopRect)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
