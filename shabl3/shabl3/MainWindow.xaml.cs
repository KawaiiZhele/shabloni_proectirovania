using System.Security.Claims;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace ThemeDecoratorDemo
{
    public abstract class ThemeDecorator
    {
        protected Grid grid;
        public ThemeDecorator(Grid grid)
        {
            this.grid = grid;
        }
        public abstract void ApplyTheme(TextBlock textBlock1, TextBlock textBlock2);
    }
    public class LightThemeDecorator : ThemeDecorator
    {
        public LightThemeDecorator(Grid grid) : base(grid) { }
        public override void ApplyTheme(TextBlock textBlock1, TextBlock textBlock2)
        {
            grid.Background = Brushes.White;
            textBlock1.Foreground = Brushes.Black;
            textBlock2.Foreground = Brushes.Black;
        }
    }
    public class DarkThemeDecorator : ThemeDecorator
    {
        public DarkThemeDecorator(Grid grid) : base(grid) { }
        public override void ApplyTheme(TextBlock textBlock1, TextBlock textBlock2)
        {
            grid.Background = Brushes.Black;
            textBlock1.Foreground = Brushes.White;
            textBlock2.Foreground = Brushes.White;
        }
    }
    public partial class MainWindow : Window
    {
        private ThemeDecorator themeDecorator;
        public MainWindow()
        {
            InitializeComponent();
            themeDecorator = new LightThemeDecorator(MainGrid);
        }
        private void ButtonLightClick(object sender, RoutedEventArgs e)
        {
            themeDecorator = new LightThemeDecorator(MainGrid);
            themeDecorator.ApplyTheme(TextBlock1, TextBlock2);
        }
        private void ButtonDarkClick(object sender, RoutedEventArgs e)
        {
            themeDecorator = new DarkThemeDecorator(MainGrid);
            themeDecorator.ApplyTheme(TextBlock1, TextBlock2);
        }
    }
}