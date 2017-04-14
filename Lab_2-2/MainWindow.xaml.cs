using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Lab_2_2.Drawers;

namespace Lab_2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum Figures { Line, Rectangle, Square, Ellipse, Circle };
    public partial class MainWindow : Window
    {
        private delegate IDrawer DrawerCreator();
        struct Controller
        {
            public string Name { get; set; }
            public DrawerCreator Creator { get; set; }
            public Figures FigureType;

        }
        Point firstPoint, endPoint;
        bool firstClick = true;
        bool secondClick = false;
        bool buf = false;
        Shape currShape = new Shape();
        Figures chosenType;
        private Dictionary<int, Controller> DrawerDictionary;

        public MainWindow()
        {
            InitializeComponent();
            DrawerDictionary = new Dictionary<int, Controller>
            {
                { 0, new Controller() { Name = "Line", FigureType = Figures.Line, Creator = () => { return new LineDrawer(); } } },
                { 1, new Controller() { Name = "Rectangle", FigureType = Figures.Rectangle, Creator = () => { return new RectangleDrawer(); } } },
                { 2, new Controller() { Name = "Square", FigureType = Figures.Square, Creator = () => { return new SquareDrawer(); } } },
                { 3, new Controller() { Name = "Ellipse", FigureType = Figures.Ellipse, Creator = () => { return new EllipseDrawer(); } } },
                { 4, new Controller() { Name = "Circle", FigureType = Figures.Circle, Creator = () => { return new CircleDrawer(); } } }
            };
        }

        private void FiguresList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chosenType = (Figures)FiguresList.SelectedIndex;
        }

        private void DrawPlace_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (secondClick)
            {
                buf = true;
                endPoint = e.GetPosition(this);
                secondClick = false;
                IDrawer currentDrawer = DrawerDictionary[FiguresList.SelectedIndex].Creator();
                if (currentDrawer != null)
                {
                    currShape.StartPoint = firstPoint;
                    currShape.EndPoint = endPoint;
                    currShape.Type = chosenType;
                    currentDrawer.Draw(DrawPlace, currShape);
                }
            }
            if (firstClick)
            {
                firstClick = false;
                firstPoint = e.GetPosition(this);
                secondClick = true;
            }
            if (buf)
            {
                buf = false;
                firstClick = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in DrawerDictionary)
                FiguresList.Items.Add(DrawerDictionary[item.Key].Name);
            FiguresList.SelectedIndex = 0;
        }

    }
}
