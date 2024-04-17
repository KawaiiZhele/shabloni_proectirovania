using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace shabl1
{
    public partial class MainWindow : Window
    {
        private ButtonContext _buttonContext;
        public MainWindow()
        {
            InitializeComponent();
            _buttonContext = new ButtonContext(MyButton);
        }
        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            _buttonContext.HandleClick();
        }
        private void MyButton_MouseEnter(object sender,
       System.Windows.Input.MouseEventArgs e)
        {
            _buttonContext.SetState(new HoverState());
            MyButton.Background = Brushes.DarkGray;
        }
        private void MyButton_MouseLeave(object sender,
       System.Windows.Input.MouseEventArgs e)
        {
            _buttonContext.SetState(new NormalState());
            MyButton.Background = Brushes.LightGray;
        }
        private void MyButton_MouseDown(object sender,
       System.Windows.Input.MouseButtonEventArgs e)
        {
            _buttonContext.SetState(new PressedState());
            MyButton.Background = Brushes.DarkRed;
        }
        private void MyButton_MouseUp(object sender,
       System.Windows.Input.MouseButtonEventArgs e)
        {
            _buttonContext.SetState(new HoverState());
            MyButton.Background = Brushes.DarkGray;
        }
    }
    public interface IButtonState
    {
        void HandleClick();
    }
    public class NormalState : IButtonState
    {
        public void HandleClick() { }
    }
    public class HoverState : IButtonState
    {
        public void HandleClick() { }
    }
    public class PressedState : IButtonState
    {
        public void HandleClick() { }
    }
    public class ButtonContext
    {
        private Button _button;
        private IButtonState _currentState;
        public ButtonContext(Button button)
        {
            _button = button;
            _currentState = new NormalState();
        }
        public void SetState(IButtonState state)
        {
            _currentState = state;
        }
        public void HandleClick()
        {
            _currentState.HandleClick();
        }
    }
}
