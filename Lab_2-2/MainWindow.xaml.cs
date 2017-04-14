using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab_2_2.Drawers;

namespace Lab_2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum Figures { line, rectangle, square, ellipse, circle };
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
                { 0, new Controller() { Name = "Line", FigureType = Figures.line, Creator = () => { return new LineDrawer(); } } },
                { 1, new Controller() { Name = "Rectangle", FigureType = Figures.line, Creator = () => { return new RectangleDrawer(); } } },
                { 2, new Controller() { Name = "Square", FigureType = Figures.line, Creator = () => { return new SquareDrawer(); } } },
                { 3, new Controller() { Name = "Ellipse", FigureType = Figures.line, Creator = () => { return new EllipseDrawer(); } } },
                { 4, new Controller() { Name = "Circle", FigureType = Figures.line, Creator = () => { return new CircleDrawer(); } } }
            };
        }

        private void FiguresList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chosenType = (Figures)FiguresList.SelectedIndex;
        }

        private void DrawPlace_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (secondClick)
            {
                buf = true;
                endPoint = e.GetPosition(this);
                secondClick = false;
                IDrawer currentDrawer = DrawerDictionary[FiguresList.SelectedIndex].Creator();
                if (currentDrawer != null)
                {
                    //TODO
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
