using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace S.F
{
    /// <summary>
    /// Логика взаимодействия для Eysenck_IQ.xaml
    /// </summary>
    public partial class Eysenck_IQ : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        int minutes = 30;
        int seconds = 0;



        public Eysenck_IQ()
        {
            InitializeComponent();

            Eysenck_IQ_Text.Visibility = Visibility.Visible;
            Start.Visibility = Visibility.Visible;
            niz.Visibility = Visibility.Visible;
            nom_vopr.Visibility = Visibility.Hidden;

            tmr.Visibility = Visibility.Hidden;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += SecondsTick;

            gr_vr.Visibility = Visibility.Hidden;
            vb_1.Visibility = Visibility.Hidden;
            text_vpr.Visibility = Visibility.Hidden;
            Cont.Visibility = Visibility.Hidden;
            End_bt.Visibility = Visibility.Hidden;
            End.Visibility = Visibility.Hidden;

        }

        void SecondsTick(object sender, EventArgs e)
        {
            if (seconds == 0 && minutes == 0)
            {
                IQ_calc();
            }
            if (seconds == 0)
            {
                minutes--;
                seconds = 60;
            }
            seconds--;
            if (minutes < 10)
                tmr.Text = ("0" + minutes + ":").ToString();
            else tmr.Text = (minutes + ":").ToString();
            if (seconds < 10) tmr.Text += "0" + seconds.ToString();
            else tmr.Text += seconds.ToString();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var animation = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(1));
            animation.Completed += (s, _) => Hide();
            BeginAnimation(UIElement.OpacityProperty, animation);
            S.F.MainWindow.ts3 = false;
        }

        public void br()
        {
            var maximum = bar.Maximum;
            Action action = () => { bar.Value++; };

            bar.Dispatcher.Invoke(action);
            nom_vopr.Text = Convert.ToString(bar.Value) + " из 40";
        }

        public void IQ_calc()
        {
            End_bt.Visibility = Visibility.Hidden;

            int minutes2 = 29;
            int seconds2 = 60;
            int minutes3 = minutes2 - minutes;
            int seconds3 = seconds2 - seconds;
            if (minutes3 < 10)
                time_sec.Text = ("0" + minutes3 + ":").ToString();
            else time_sec.Text = (minutes3 + ":").ToString();

            if (seconds3 < 10)
                time_sec.Text += "0" + seconds3.ToString();
            else time_sec.Text += seconds3.ToString();

            End.Visibility = Visibility.Visible;
            time.Text = DateTime.Now.ToShortDateString() + "  " + DateTime.Now.ToShortTimeString();

            p_otv.Text = pr_otv.ToString();

            for (int i = 0; i < pr_otv; i++)
            {
                IQ += 2.5;
            }
            Iq.Text = IQ.ToString();
        }




        private void Start_Click(object sender, RoutedEventArgs e)
        {
            tmr.Visibility = Visibility.Visible;

            Eysenck_IQ_Text.Visibility = Visibility.Hidden;
            Start.Visibility = Visibility.Hidden;
            niz.Visibility = Visibility.Hidden;

            nom_vopr.Visibility = Visibility.Visible;
            tmr.Text = "30:00";
            timer.Start();


            bar.Value++;


            gr_vr.Visibility = Visibility.Visible;
            vb_1.Visibility = Visibility.Visible;
            text_vpr.Visibility = Visibility.Visible;

            _1_1.Visibility = Visibility.Visible;
            _2_1.Visibility = Visibility.Visible;
            _3_1.Visibility = Visibility.Visible;
            _4_1.Visibility = Visibility.Visible;
            zd_img.Visibility = Visibility.Visible;
            Cont.Visibility = Visibility.Visible;
            End_bt.Visibility = Visibility.Visible;
        }


        public double pr_otv = 0;
        public double IQ = 70;
        private void Click(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            foreach (Button item in vb_1.Children)
            {
                if (item.Name == (sender as Button).Name) item.BorderBrush = Brushes.Blue;
                else item.BorderBrush = (Brush)bc.ConvertFrom("#FFEFEFF1");
            }
        }

        private void Click2(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            foreach (Button item in vb_9.Children)
            {
                if (item.Name == (sender as Button).Name) item.BorderBrush = Brushes.Blue;
                else item.BorderBrush = (Brush)bc.ConvertFrom("#FFEFEFF1");
            }
        }
        private void Click3(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            foreach (Button item in vb_10.Children)
            {
                if (item.Name == (sender as Button).Name) item.BorderBrush = Brushes.Blue;
                else item.BorderBrush = (Brush)bc.ConvertFrom("#FFEFEFF1");
            }
        }
        private void Click4(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            foreach (Button item in vb_17.Children)
            {
                if (item.Name == (sender as Button).Name) item.BorderBrush = Brushes.Blue;
                else item.BorderBrush = (Brush)bc.ConvertFrom("#FFEFEFF1");
            }
        }
        private void Click5(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            foreach (Button item in vb_18.Children)
            {
                if (item.Name == (sender as Button).Name) item.BorderBrush = Brushes.Blue;
                else item.BorderBrush = (Brush)bc.ConvertFrom("#FFEFEFF1");
            }
        }

        private void Click6(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            foreach (Button item in vb_27.Children)
            {
                if (item.Name == (sender as Button).Name) item.BorderBrush = Brushes.Blue;
                else item.BorderBrush = (Brush)bc.ConvertFrom("#FFEFEFF1");
            }
        }

        private void Click7(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            foreach (Button item in vb_28.Children)
            {
                if (item.Name == (sender as Button).Name) item.BorderBrush = Brushes.Blue;
                else item.BorderBrush = (Brush)bc.ConvertFrom("#FFEFEFF1");
            }
        }

        private void Click8(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            foreach (Button item in vb_29.Children)
            {
                if (item.Name == (sender as Button).Name) item.BorderBrush = Brushes.Blue;
                else item.BorderBrush = (Brush)bc.ConvertFrom("#FFEFEFF1");
            }
        }

        private void Click9(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            foreach (Button item in vb_38.Children)
            {
                if (item.Name == (sender as Button).Name) item.BorderBrush = Brushes.Blue;
                else item.BorderBrush = (Brush)bc.ConvertFrom("#FFEFEFF1");
            }
        }

        private void Click10(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            foreach (Button item in vb_39.Children)
            {
                if (item.Name == (sender as Button).Name) item.BorderBrush = Brushes.Blue;
                else item.BorderBrush = (Brush)bc.ConvertFrom("#FFEFEFF1");
            }
        }

        private void Click11(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            foreach (Button item in vb_40.Children)
            {
                if (item.Name == (sender as Button).Name) item.BorderBrush = Brushes.Blue;
                else item.BorderBrush = (Brush)bc.ConvertFrom("#FFEFEFF1");
            }
        }


        private void Otv_txb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Cont_Click(null, null);
            }
        }

        string[] otvet = new string[] { "_4", "ЧАЙ", "ЧЕМОДАН", "11", "ЖАБА", "21", "3", "ТЕСТО", "_6", "_5", "И", "ШОК", "54", "11", "27", "МИ", "_2", "_2", "18", "76", "КОЖА", "ЛАД", "СКУНС", "КИСТЬ", "С", "ЕЕ", "_2", "_1", "_1", "ГРОТ", "ВИНТ", "64", "ПОРТ", "ВТОРНИК", "7Ж", "ГУБА", "РОСА", "_1", "_6", "_1" };

        private void Cont_Click(object sender, RoutedEventArgs e)
        {

            switch (bar.Value)
            {
                case 1:
                    if (_4_1.BorderBrush == Brushes.Blue) pr_otv += 1;
                    text_vpr.Text = "Вставьте слово, которое служило бы окончанием первого слова и началом второго.";

                    _1_1.Visibility = Visibility.Hidden;
                    _2_1.Visibility = Visibility.Hidden;
                    _3_1.Visibility = Visibility.Hidden;
                    _4_1.Visibility = Visibility.Hidden;
                    zd_img.Visibility = Visibility.Hidden;
                    zd_2.Visibility = Visibility.Visible;
                    vb_gray.Visibility = Visibility.Visible;
                    vb_1.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    if (otv_txb.Text == otvet[1]) pr_otv += 1;
                    text_vpr.Text = "Решите анаграммы и назовите лишнее слово.";
                    vb_gray.Visibility = Visibility.Visible;

                    zd_2.Visibility = Visibility.Hidden;
                    zd_3.Visibility = Visibility.Visible;
                    niz.Visibility = Visibility.Visible;
                    otv_txb.Clear();

                    break;

                case 3:
                    if (otv_txb.Text == otvet[2]) pr_otv += 1;
                    text_vpr.Text = "Вставьте недостающее число.";
                    otv_txb.Clear();

                    zd_3.Visibility = Visibility.Hidden;
                    zd_img.Visibility = Visibility.Visible;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/4/_4.png", UriKind.RelativeOrAbsolute));

                    break;

                case 4:
                    if (otv_txb.Text == otvet[3]) pr_otv += 1;
                    text_vpr.Text = "Вставьте пропущенное слово.";
                    otv_txb.Clear();

                    zd_img.Visibility = Visibility.Hidden;
                    zd_4.Visibility = Visibility.Visible;


                    break;

                case 5:
                    if (otv_txb.Text == otvet[4]) pr_otv += 1;
                    text_vpr.Text = "Вставьте пропущенное число.";
                    otv_txb.Clear();

                    zd_4.Visibility = Visibility.Hidden;
                    zd_5.Visibility = Visibility.Visible;

                    break;

                case 6:
                    if (otv_txb.Text == otvet[5]) pr_otv += 1;
                    text_vpr.Text = "Продолжите ряд чисел.";
                    otv_txb.Clear();

                    zd_5.Visibility = Visibility.Hidden;
                    zd_6.Visibility = Visibility.Visible;


                    break;

                case 7:
                    text_vpr.Text = "Решите анаграммы и назовите лишнее слово.";
                    if (otv_txb.Text == otvet[6]) pr_otv += 1;
                    otv_txb.Clear();

                    zd_6.Visibility = Visibility.Hidden;
                    zd_7.Visibility = Visibility.Visible;

                    break;

                case 8:
                    text_vpr.Text = "Выберите нужную фигуру из пронумерованных.";
                    if (otv_txb.Text == otvet[7]) pr_otv += 1;

                    otv_txb.Clear();
                    vb_gray.Visibility = Visibility.Hidden;
                    vb_9.Visibility = Visibility.Visible;
                    zd_7.Visibility = Visibility.Hidden;
                    zd_img.Visibility = Visibility.Visible;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/9/_9.jpg", UriKind.RelativeOrAbsolute));

                    break;

                case 9:
                    text_vpr.Text = "Выберите нужную фигуру из шести пронумерованных.";
                    if (_6_9.BorderBrush == Brushes.Blue) pr_otv += 1;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/10/_10.jpg", UriKind.RelativeOrAbsolute));
                    vb_9.Visibility = Visibility.Hidden;
                    vb_10.Visibility = Visibility.Visible;

                    break;

                case 10:
                    text_vpr.Text = "Вставьте недостающую букву.";
                    if (_5_10.BorderBrush == Brushes.Blue) pr_otv += 1;
                    vb_10.Visibility = Visibility.Hidden;
                    zd_img.Visibility = Visibility.Hidden;
                    zd_11.Visibility = Visibility.Visible;
                    vb_gray.Visibility = Visibility.Visible;
                    break;

                case 11:
                    text_vpr.Text = "Вставьте слово, которое служило бы окончанием первого слова и началом второго.";
                    if (otv_txb.Text == otvet[10]) pr_otv += 1;
                    zd_11.Visibility = Visibility.Hidden;
                    zd_12.Visibility = Visibility.Visible;
                    otv_txb.Clear();

                    break;

                case 12:
                    text_vpr.Text = "Вставьте пропущенное число.";
                    if (otv_txb.Text == otvet[11]) pr_otv += 1;
                    zd_12.Visibility = Visibility.Hidden;
                    zd_img.Visibility = Visibility.Visible;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/13/_13.png", UriKind.RelativeOrAbsolute));

                    otv_txb.Clear();

                    break;

                case 13:
                    text_vpr.Text = "Вставьте недостающее число.";
                    if (otv_txb.Text == otvet[12]) pr_otv += 1;
                    zd_img.Visibility = Visibility.Hidden;
                    zd_14.Visibility = Visibility.Visible;
                    otv_txb.Clear();

                    break;

                case 14:
                    text_vpr.Text = "Вставьте недостающее число.";
                    if (otv_txb.Text == otvet[13]) pr_otv += 1;
                    zd_14.Visibility = Visibility.Hidden;
                    zd_15.Visibility = Visibility.Visible;
                    otv_txb.Clear();

                    break;

                case 15:
                    text_vpr.Text = "Вставьте недостающие буквы без пробелов.";
                    if (otv_txb.Text == otvet[14]) pr_otv += 1;
                    zd_15.Visibility = Visibility.Hidden;
                    zd_img.Visibility = Visibility.Visible;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/16/_16.png", UriKind.RelativeOrAbsolute));
                    otv_txb.Clear();

                    break;

                case 16:
                    text_vpr.Text = "Выберите нужную фигуру из шести пронумерованных";
                    if (otv_txb.Text == otvet[15]) pr_otv += 1;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/17/_17.jpg", UriKind.RelativeOrAbsolute));
                    otv_txb.Clear();
                    vb_17.Visibility = Visibility.Visible;
                    break;

                case 17:
                    text_vpr.Text = "Выберите нужную фигуру из пронумерованных.";
                    if (_2_17.BorderBrush == Brushes.Blue) pr_otv += 1;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/18/_18.jpg", UriKind.RelativeOrAbsolute));
                    otv_txb.Clear();
                    vb_17.Visibility = Visibility.Hidden;
                    vb_18.Visibility = Visibility.Visible;
                    break;

                case 18:
                    text_vpr.Text = "Вставьте пропущенное число.";
                    if (_2_18.BorderBrush == Brushes.Blue) pr_otv += 1;
                    otv_txb.Clear();
                    vb_18.Visibility = Visibility.Hidden;
                    zd_img.Visibility = Visibility.Hidden;
                    zd_19.Visibility = Visibility.Visible;
                    vb_gray.Visibility = Visibility.Visible;

                    break;

                case 19:
                    text_vpr.Text = "Вставьте пропущенное число.";
                    if (otv_txb.Text == otvet[18]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_19.Visibility = Visibility.Hidden;
                    zd_20.Visibility = Visibility.Visible;

                    break;

                case 20:
                    text_vpr.Text = "Вставьте пропущенное слово.";
                    if (otv_txb.Text == otvet[19]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_20.Visibility = Visibility.Hidden;
                    zd_21.Visibility = Visibility.Visible;

                    break;

                case 21:
                    text_vpr.Text = "Вставьте слово, которое служило бы окончанием первого слова и началом второго.";
                    if (otv_txb.Text == otvet[20]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_21.Visibility = Visibility.Hidden;
                    zd_22.Visibility = Visibility.Visible;

                    break;

                case 22:
                    text_vpr.Text = "Решите анаграммы и назовите лишнее слово.";
                    if (otv_txb.Text == otvet[21]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_22.Visibility = Visibility.Hidden;
                    zd_23.Visibility = Visibility.Visible;

                    break;

                case 23:
                    text_vpr.Text = "Вставьте слово, которое означало бы то же, что и слова, стоящие вне скобок.";
                    if (otv_txb.Text == otvet[22]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_23.Visibility = Visibility.Hidden;
                    zd_24.Visibility = Visibility.Visible;

                    break;

                case 24:
                    text_vpr.Text = "Вставьте пропущенную букву.";
                    if (otv_txb.Text == otvet[23]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_24.Visibility = Visibility.Hidden;
                    zd_25.Visibility = Visibility.Visible;

                    break;

                case 25:
                    text_vpr.Text = "Вставьте пропущенные буквы без пробелов";
                    if (otv_txb.Text == otvet[24]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_25.Visibility = Visibility.Hidden;
                    zd_img.Visibility = Visibility.Visible;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/26/_26.png", UriKind.RelativeOrAbsolute));

                    break;

                case 26:
                    text_vpr.Text = "Выберите нужную фигуру из шести пронумерованных.";
                    if (otv_txb.Text == otvet[25]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_img.Visibility = Visibility.Visible;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/27/_27.jpg", UriKind.RelativeOrAbsolute));
                    vb_27.Visibility = Visibility.Visible;
                    break;


                case 27:
                    text_vpr.Text = "Выберите нужную фигуру из пронумерованных.";
                    if (_2_27.BorderBrush == Brushes.Blue) pr_otv += 1;
                    otv_txb.Clear();
                    zd_img.Visibility = Visibility.Visible;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/28/_28.jpg", UriKind.RelativeOrAbsolute));
                    vb_27.Visibility = Visibility.Hidden;
                    vb_28.Visibility = Visibility.Visible;

                    break;

                case 28:
                    text_vpr.Text = "Выберите нужную фигуру из шести пронумерованных.";
                    if (_1_28.BorderBrush == Brushes.Blue) pr_otv += 1;
                    otv_txb.Clear();
                    zd_img.Visibility = Visibility.Visible;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/29/_29.jpg", UriKind.RelativeOrAbsolute));
                    vb_28.Visibility = Visibility.Hidden;
                    vb_29.Visibility = Visibility.Visible;

                    break;


                case 29:
                    text_vpr.Text = "Вставьте пропущенное слово.";
                    if (_1_29.BorderBrush == Brushes.Blue) pr_otv += 1;
                    otv_txb.Clear();
                    zd_img.Visibility = Visibility.Hidden;
                    vb_29.Visibility = Visibility.Hidden;
                    zd_30.Visibility = Visibility.Visible;

                    break;

                case 30:
                    text_vpr.Text = "Вставьте слово, которое означало бы то же, что и слова, стоящие вне скобок.";
                    if (otv_txb.Text == otvet[29]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_30.Visibility = Visibility.Hidden;
                    zd_31.Visibility = Visibility.Visible;

                    break;

                case 31:
                    text_vpr.Text = "Вставьте пропущенное число.";
                    if (otv_txb.Text == otvet[30]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_31.Visibility = Visibility.Hidden;
                    zd_32.Visibility = Visibility.Visible;

                    break;


                case 32:
                    text_vpr.Text = "Вставьте пропущенное слово.";
                    if (otv_txb.Text == otvet[31]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_32.Visibility = Visibility.Hidden;
                    zd_33.Visibility = Visibility.Visible;

                    break;

                case 33:
                    text_vpr.Text = "Решите анаграммы и назовите лишнее слово.";
                    if (otv_txb.Text == otvet[32]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_33.Visibility = Visibility.Hidden;
                    zd_34.Visibility = Visibility.Visible;

                    break;

                case 34:
                    text_vpr.Text = "Вставьте пропущенную букву и пропущенное число без пробелов";
                    if (otv_txb.Text == otvet[33]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_34.Visibility = Visibility.Hidden;
                    zd_img.Visibility = Visibility.Visible;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/35/_35.jpg", UriKind.RelativeOrAbsolute));

                    break;

                case 35:
                    text_vpr.Text = "Вставьте слово, которое означало бы то же, что и слова, стоящие вне скобок.";
                    if (otv_txb.Text == otvet[34]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_img.Visibility = Visibility.Hidden;
                    zd_36.Visibility = Visibility.Visible;


                    break;

                case 36:
                    text_vpr.Text = "Вставьте пропущенное слово.";
                    if (otv_txb.Text == otvet[35]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_36.Visibility = Visibility.Hidden;
                    zd_37.Visibility = Visibility.Visible;


                    break;

                case 37:
                    text_vpr.Text = "Выберите нужную фигуру из шести пронумерованных";
                    if (otv_txb.Text == otvet[36]) pr_otv += 1;
                    otv_txb.Clear();
                    zd_37.Visibility = Visibility.Hidden;
                    vb_gray.Visibility = Visibility.Hidden;
                    zd_img.Visibility = Visibility.Visible;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/38/_38.jpg", UriKind.RelativeOrAbsolute));
                    vb_38.Visibility = Visibility.Visible;

                    break;

                case 38:
                    text_vpr.Text = "Выберите нужную фигуру из шести пронумерованных";
                    if (_1_38.BorderBrush == Brushes.Blue) pr_otv += 1;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/39/_39.jpg", UriKind.RelativeOrAbsolute));
                    vb_38.Visibility = Visibility.Hidden;
                    vb_39.Visibility = Visibility.Visible;

                    break;

                case 39:
                    text_vpr.Text = "Выберите нужную фигуру из шести пронумерованных";
                    if (_6_39.BorderBrush == Brushes.Blue) pr_otv += 1;
                    zd_img.Source = new BitmapImage(new Uri(@"Image/Eysenck_IQ/40/_40.jpg", UriKind.RelativeOrAbsolute));
                    vb_39.Visibility = Visibility.Hidden;
                    vb_40.Visibility = Visibility.Visible;

                    break;
                case 40:
                    text_vpr.Text = "Выберите нужную фигуру из четырех пронумерованных";
                    if (_1_40.BorderBrush == Brushes.Blue) pr_otv += 1;
                    IQ_calc();


                    break;
                default:
                    break;
            }
            br();

        }

        private void End_bt_Click(object sender, RoutedEventArgs e)
        {
            IQ_calc();

        }
    }
}
