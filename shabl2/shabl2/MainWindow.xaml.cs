using System;
using System.Windows;
using System.Windows.Controls;

namespace ObserverPatternDemo
{
    public partial class MainWindow : Window
    {
        private SliderObserver _sliderObserver;

        public MainWindow()
        {
            InitializeComponent();
            _sliderObserver = new SliderObserver(slider, textBlock);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _sliderObserver.OnValueChanged(sender, e);
        }
    }

    public class SliderObserver
    {
        private readonly Slider _slider;
        private readonly TextBlock _textBlock;

        public SliderObserver(Slider slider, TextBlock textBlock)
        {
            _slider = slider;
            _textBlock = textBlock;
            _slider.ValueChanged += OnValueChanged;
        }

        public void OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _textBlock.Text = _slider.Value.ToString();
        }
    }
}
