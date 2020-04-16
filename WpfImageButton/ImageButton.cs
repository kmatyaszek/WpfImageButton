using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfImageButton
{
    public class ImageButton : Button
    {
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        public ImageButton()
        {
            this.SetCurrentValue(ImageButton.ImageLocationProperty, WpfImageButton.ImageLocation.Left);
        }

        public int ImageWidth
        {
            get { return (int)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register("ImageWidth", typeof(int), typeof(ImageButton), new PropertyMetadata(30));
        
        public int ImageHeight
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register("ImageHeight", typeof(int), typeof(ImageButton), new PropertyMetadata(30));
        
        public ImageLocation? ImageLocation
        {
            get { return (ImageLocation)GetValue(ImageLocationProperty); }
            set { SetValue(ImageLocationProperty, value); }
        }

        public static readonly DependencyProperty ImageLocationProperty =
            DependencyProperty.Register("ImageLocation", typeof(ImageLocation?), typeof(ImageButton), new PropertyMetadata(null, PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var imageButton = (ImageButton)d;
            var newLocation = (ImageLocation?) e.NewValue ?? WpfImageButton.ImageLocation.Left;

            switch (newLocation)
            {
                case WpfImageButton.ImageLocation.Left:
                    imageButton.SetCurrentValue(ImageButton.RowIndexProperty, 1);
                    imageButton.SetCurrentValue(ImageButton.ColumnIndexProperty, 0);
                    break;
                case WpfImageButton.ImageLocation.Top:
                    imageButton.SetCurrentValue(ImageButton.RowIndexProperty, 0);
                    imageButton.SetCurrentValue(ImageButton.ColumnIndexProperty, 1);
                    break;
                case WpfImageButton.ImageLocation.Right:
                    imageButton.SetCurrentValue(ImageButton.RowIndexProperty, 1);
                    imageButton.SetCurrentValue(ImageButton.ColumnIndexProperty, 2);
                    break;
                case WpfImageButton.ImageLocation.Bottom:
                    imageButton.SetCurrentValue(ImageButton.RowIndexProperty, 2);
                    imageButton.SetCurrentValue(ImageButton.ColumnIndexProperty, 1);
                    break;
                case WpfImageButton.ImageLocation.Center:
                    imageButton.SetCurrentValue(ImageButton.RowIndexProperty, 1);
                    imageButton.SetCurrentValue(ImageButton.ColumnIndexProperty, 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null));

        public int RowIndex
        {
            get { return (int)GetValue(RowIndexProperty); }
            set { SetValue(RowIndexProperty, value); }
        }

        public static readonly DependencyProperty RowIndexProperty =
            DependencyProperty.Register("RowIndex", typeof(int), typeof(ImageButton), new PropertyMetadata(0));

        public int ColumnIndex
        {
            get { return (int)GetValue(ColumnIndexProperty); }
            set { SetValue(ColumnIndexProperty, value); }
        }

        public static readonly DependencyProperty ColumnIndexProperty =
            DependencyProperty.Register("ColumnIndex", typeof(int), typeof(ImageButton), new PropertyMetadata(0));
    }

    public enum ImageLocation
    {
        Left,
        Top,
        Right,
        Bottom,
        Center
    }
}
