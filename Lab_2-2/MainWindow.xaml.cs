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
    public partial class MainWindow : Window
    {
        public enum Figures { line, rectangle, square, ellipse, circle };
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
            DrawerDictionary = new Dictionary<int, Controller>();
            DrawerDictionary.Add(0, new Controller() { Name = "line", FigureType = Figures.line, Creator = () => { return new LineDrawer(); } });
        }
    }
}
