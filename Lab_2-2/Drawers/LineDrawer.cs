using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab_2_2.Drawers
{
    class LineDrawer : IDrawer
    {
        public void Draw(Canvas DrawPlace, Shape shape)
        {
            Line figure = new Line();
            figure.StrokeThickness = 2;
            figure.Stroke = new SolidColorBrush(Colors.RosyBrown);
            figure.Fill = new SolidColorBrush(Colors.Beige);
            figure.X1 = shape.StartPoint.X;
            figure.Y1 = shape.StartPoint.Y;
            figure.X2 = shape.EndPoint.X;
            figure.Y2 = shape.EndPoint.Y;
            DrawPlace.Children.Add(figure);
        }
    }
}
