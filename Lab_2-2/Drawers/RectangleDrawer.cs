using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab_2_2.Drawers
{
    class RectangleDrawer : IDrawer
    {
        public void Draw(Canvas DrawPlace, Shape shape)
        {
            Ellipse figure = new Ellipse();
            figure.StrokeThickness = 2;
            figure.Stroke = new SolidColorBrush(Colors.RosyBrown);
            figure.Fill = new SolidColorBrush(Colors.Beige);
            figure.Width = System.Math.Abs(shape.EndPoint.X - shape.StartPoint.X);
            figure.Height = figure.Width;
            Canvas.SetLeft(figure, shape.StartPoint.X);
            Canvas.SetTop(figure, shape.StartPoint.Y);
            DrawPlace.Children.Add(figure);
        }
    }
}
