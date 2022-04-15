using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace S.F
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var animation = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(1));
            animation.Completed += (s, _) => Environment.Exit(0);
            BeginAnimation(UIElement.OpacityProperty, animation);
        }

    static public bool ts1 = false;
    static public bool ts2 = false;
    static public bool ts3 = false;
    static public bool ts4 = false;
    static public bool ts5 = false;
    static public bool help = false;
        private void Image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ts1==false)
            {
                Test_Sondi f1 = new Test_Sondi();
                f1.Show();
                ts1 = true;
               
            }          
        }

        private void Image_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (ts2 == false)
            {
                Test_Rorschach f2 = new Test_Rorschach();
                f2.Show();
                ts2 = true;

            }
        }

        private void Image_PreviewMouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            if (ts3 == false)
            {
                Eysenck_IQ f3 = new Eysenck_IQ();
                f3.Show();
                ts3 = true;

            }
        }

        private void Image_PreviewMouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            if (ts4 == false)
            {
                Eysenck_tempr f4 = new Eysenck_tempr();
                f4.Show();
                ts4 = true;

            }
        }

        private void Image_PreviewMouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {
            if (ts5 == false)
            {
                Bek f5 = new Bek();
                f5.Show();
                ts5 = true;

            }
        }

        private void TextBlock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (help == false)
            {
                Help h = new Help();
                h.Show();
                help = true;

            }
        }
    }
}
