using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfImageButton
{
    public partial class MainWindow : Window
    {
        private bool _isOk = true;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _isOk = !_isOk;
            btnImage.ImageSource = _isOk
                ? new BitmapImage(
                    new Uri("pack://application:,,,/WpfImageButton;component/ok.png"))
                : new BitmapImage(
                    new Uri("pack://application:,,,/WpfImageButton;component/cancel.png"));
        }
    }
}
