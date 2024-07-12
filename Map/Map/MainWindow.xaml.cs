using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Map
{
    public partial class MainWindow : Window
    {
        double mPoint1X;
        double mPoint1Y;
        double mPoint2X;
        double mPoint2Y;
        double ans;
        double jpg = 9.7141;
        Point point1;
        Point point2;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pon.Children.Clear();
            point1 = e.GetPosition(this);
            Ellipse el = new Ellipse
            {
                Width = 6,
                Height = 6,
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Canvas.SetTop(el, point1.Y - 3);
            Canvas.SetLeft(el, point1.X - 3);
            pon.Children.Add(el);
            Lin_Click();
        }

        private void Map_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            pon1.Children.Clear();
            point2 = e.GetPosition(this);
            Ellipse el = new Ellipse
            {
                Width = 6,
                Height = 6,
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                StrokeThickness = 1

            };
            Canvas.SetTop(el, point2.Y - 3);
            Canvas.SetLeft(el, point2.X - 3);
            pon1.Children.Add(el);
            Lin_Click();
        }

        public void Lin_Click()
        {
            mPoint1X = point1.X;
            mPoint1Y = point1.Y;
            mPoint2X = point2.X;
            mPoint2Y = point2.Y;
            if (mPoint1X >= mPoint2X)
            {
                if (mPoint1Y >= mPoint2Y)
                {
                    mPoint1X -= mPoint2X;
                    mPoint1Y -= mPoint2Y;
                    ans = Math.Sqrt(Math.Pow(mPoint1X, 2) + Math.Pow(mPoint1Y, 2));
                }
                else if (mPoint1Y < mPoint2Y)
                {
                    mPoint1X -= mPoint2X;
                    mPoint2Y -= mPoint1Y;
                    ans = Math.Sqrt(Math.Pow(mPoint1X, 2) + Math.Pow(mPoint2Y, 2));
                }
            }
            else if (mPoint1X < mPoint2X)
            {
                if (mPoint1Y >= mPoint2Y)
                {
                    mPoint2X -= mPoint1X;
                    mPoint1Y -= mPoint2Y;
                    ans = Math.Sqrt(Math.Pow(mPoint2X, 2) + Math.Pow(mPoint1Y, 2));
                }
                else if (mPoint1Y < mPoint2Y)
                {
                    mPoint2X -= mPoint1X;
                    mPoint2Y -= mPoint1Y;
                    ans = Math.Sqrt(Math.Pow(mPoint2X, 2) + Math.Pow(mPoint2Y, 2));
                }
            }
            dist.Content = string.Format("{0:0.##}", (ans * jpg)) + "м.";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (box.SelectedIndex)
            {
                case 0:
                    Map.Source = BitmapFrame.Create(new Uri(@"C:\Users\Nikityara\Desktop\Map\Map\Изображения\Эрангель.jpg"));
                    jpg = 9.7141;
                    break; 
                case 1:
                    Map.Source = BitmapFrame.Create(new Uri(@"C:\Users\Nikityara\Desktop\Map\Map\Изображения\Мирамар.jpg"));
                    jpg = 9.7141;
                    break;
                case 2:
                    Map.Source = BitmapFrame.Create(new Uri(@"C:\Users\Nikityara\Desktop\Map\Map\Изображения\Санок.jpg"));
                    jpg = 4.85705;
                    break;
                case 3:
                    Map.Source = BitmapFrame.Create(new Uri(@"C:\Users\Nikityara\Desktop\Map\Map\Изображения\Каракин.jpg"));
                    jpg = 2.4285;
                    break;
                case 4:
                    Map.Source = BitmapFrame.Create(new Uri(@"C:\Users\Nikityara\Desktop\Map\Map\Изображения\Парамо.jpg"));
                    jpg = 3.6427;
                    break;
                case 5:
                    Map.Source = BitmapFrame.Create(new Uri(@"C:\Users\Nikityara\Desktop\Map\Map\Изображения\Таэго.jpg"));
                    jpg = 9.7141;
                    break;
                case 6:
                    Map.Source = BitmapFrame.Create(new Uri(@"C:\Users\Nikityara\Desktop\Map\Map\Изображения\Дестон.jpg"));
                    jpg = 9.7141;
                    break;
                case 7:
                    Map.Source = BitmapFrame.Create(new Uri(@"C:\Users\Nikityara\Desktop\Map\Map\Изображения\Викенди.jpg"));
                    jpg = 9.7141;
                    break;
                case 8:
                    Map.Source = BitmapFrame.Create(new Uri(@"C:\Users\Nikityara\Desktop\Map\Map\Изображения\Рондо.jpg"));
                    jpg = 9.7141;
                    break;
            }
        }

        private void Map_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                Map.Height += 70;
                Map.Width += 70;
                Map.RenderSize = Map.RenderSize;
            }
            else
            {
                Map.Height -= 70;
                Map.Width -= 70;
                Map.RenderSize = Map.RenderSize;
            }
            
        }
    }
}
