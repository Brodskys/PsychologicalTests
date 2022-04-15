using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Логика взаимодействия для Eysenck_tempr.xaml
    /// </summary>
    public partial class Eysenck_tempr : Window
    {

        string[] question = new string[57];

        int[] neir_ = { 2, 4, 7, 9, 11, 14, 16, 19, 21, 23, 26, 28, 31, 33, 35, 38, 40, 43, 45, 47, 50, 52, 55, 57 };
        int[] extr_yes = { 1, 3, 8, 10, 13, 17, 22, 25, 27, 39, 44, 46, 49, 53, 56 };
        int[] extr_no = { 5, 15, 20, 29, 32, 34, 37, 41, 51 };
        int[] lie_no = { 12, 18, 30, 42, 48, 54 };
        int[] lie_yes = { 6, 24, 36 };

        DispatcherTimer timer;

        int extr = 0;
        int neir = 0;
        string[] trueanswers = new string[57]
        {
            "EY","N","EY","N","EN",//5
            "LY","N","EY","N","EY",//10
            "N","LN","EN","N","EN",//15
            "N","EY","LN","N","EN",//20
            "N","EY","N","LY","EY",//25
            "N","EY","N","EN","LN",//30
            "N","EN","N","EN","N",//35
            "LY","EN","N","EY","N",//40
            "EN","LN","N","EY","N",//45
            "EY","N","LN","EY","N",//50
            "EY","N","EY","LN","N",//55
            "EY","N"//57
        };
        int lie = 0;
        char[] answers = new char[57];

        public void List()
        {
            Text_Eysenck.Visibility = Visibility.Visible;
            Start.Visibility = Visibility.Visible;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Invisibility;
            using (StreamReader file = new StreamReader(@"/S.F/S.F/Image/Eysenck_tempr/aizenk temp.txt", Encoding.UTF8))
            {
                int i = 0;
                while (!file.EndOfStream)
                {
                    question[i] = file.ReadLine();
                    Questions.Items.Add(question[i]);
                    List<CheckBox> checkBoxes = new List<CheckBox>() { new CheckBox(), new CheckBox() };
                    checkBoxes[0].Name = "Y" + i.ToString();
                    checkBoxes[1].Name = "N" + i.ToString();
                    checkBoxes[0].Content = "Да";
                    checkBoxes[1].Content = "Нет";
                    checkBoxes[0].Checked += CheckBox_Checked;
                    checkBoxes[1].Checked += CheckBox_Checked;
                    Questions.Items.Add(checkBoxes[0]);
                    Questions.Items.Add(checkBoxes[1]);
                    i++;
                }

            }
            Questions.Visibility = Visibility.Hidden;
            CompleteAnswer.Visibility = Visibility.Hidden;
            End.Visibility = Visibility.Hidden;
            r_t.Visibility = Visibility.Hidden;


        }
        public Eysenck_tempr()
        {
            InitializeComponent();
            //Text_Eysenck.Visibility = Visibility.Visible;
            //Start.Visibility = Visibility.Visible;

            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(2); 
            //timer.Tick += Invisibility;
            //using (StreamReader file = new StreamReader(@"/S.F/S.F/Image/Eysenck_tempr/aizenk temp.txt", Encoding.UTF8))
            //{
            //    int i = 0;
            //    while (!file.EndOfStream)
            //    {
            //        question[i] = file.ReadLine();
            //        Questions.Items.Add(question[i]);
            //        List<CheckBox> checkBoxes = new List<CheckBox>() { new CheckBox(), new CheckBox() };
            //        checkBoxes[0].Name = "Y" + i.ToString();
            //        checkBoxes[1].Name = "N" + i.ToString();
            //        checkBoxes[0].Content = "Да";
            //        checkBoxes[1].Content = "Нет";
            //        checkBoxes[0].Checked += CheckBox_Checked;
            //        checkBoxes[1].Checked += CheckBox_Checked;
            //        Questions.Items.Add(checkBoxes[0]);
            //        Questions.Items.Add(checkBoxes[1]);
            //        i++;
            //    }

            //}
            //Questions.Visibility = Visibility.Hidden;
            //CompleteAnswer.Visibility = Visibility.Hidden;
            //End.Visibility = Visibility.Hidden;
            //r_t.Visibility = Visibility.Hidden;
            List();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var animation = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(1));
            animation.Completed += (s, _) => Hide();
            BeginAnimation(UIElement.OpacityProperty, animation);
            S.F.MainWindow.ts4 = false;
        }


        void Invisibility(object sender, EventArgs e)
        {
            DoubleAnimation das = new DoubleAnimation(0, TimeSpan.FromSeconds(2));
            timer.Stop();
        }

        void GetResult()
        {
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == 'Y')
                {
                    if (trueanswers[i][0] == 'L') lie++;
                    if (trueanswers[i][0] == 'E') extr++;
                    continue;
                }
                else if (answers[i] == 'N')
                {
                    if (trueanswers[i][0] == 'L') lie--;
                    if (trueanswers[i][0] == 'E') extr--;
                    continue;
                }
                neir++;
            }



            if (lie > 4) lsh1.Text = "   Неискренность в ответах, свидетельствующая также о некоторой демонстративности поведения и ориентированности испытуемого на социальное одобрение.";
            else lsh1.Text += "Норма.";

            if (extr >= 15) t_l.Text = "Экстраверт";
            if (extr <= 14) t_l.Text = "Интроверт";

            if (extr > 15 || neir < 14) t_t.Text = "Сангвиник";
            if (extr >= 15 || neir >= 14) t_t.Text = "Холерик";
            if (extr <= 9 || neir <= 14) t_t.Text = "Флегматик";
            if (extr <= 9 || neir >= 14) t_t.Text = "Меланхолик";

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chb = sender as CheckBox;
            if (chb.Name[0] == 'Y')
            {
                (Questions.Items[Questions.Items.IndexOf(chb) + 1] as CheckBox).IsChecked = false;
                answers[int.Parse(chb.Name.Substring(1, chb.Name.Length - 1))] = 'Y';
                (Questions.Items[Questions.Items.IndexOf(chb)] as CheckBox).BorderBrush = Brushes.Black;
                (Questions.Items[Questions.Items.IndexOf(chb) + 1] as CheckBox).BorderBrush = Brushes.Black;
            }
            else
            {
                (Questions.Items[Questions.Items.IndexOf(chb) - 1] as CheckBox).IsChecked = false;
                answers[int.Parse(chb.Name.Substring(1, chb.Name.Length - 1))] = 'N';
                (Questions.Items[Questions.Items.IndexOf(chb)] as CheckBox).BorderBrush = Brushes.Black;
                (Questions.Items[Questions.Items.IndexOf(chb) - 1] as CheckBox).BorderBrush = Brushes.Black;
            }
            End.Visibility = Visibility.Visible;

        }




        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Text_Eysenck.Visibility = Visibility.Hidden;
            Start.Visibility = Visibility.Hidden;

            Questions.Visibility = Visibility.Visible;          
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {

            int countof = 0;

                for (int i = 1; i < Questions.Items.Count; i += 3)
                {
                    if (Questions.Items[i].GetType() == typeof(CheckBox))
                    {
                        if ((Questions.Items[i] as CheckBox).IsChecked == false && (Questions.Items[i + 1] as CheckBox).IsChecked == false)
                        {

                            (Questions.Items[i] as CheckBox).BorderBrush = Brushes.Red;
                            (Questions.Items[i + 1] as CheckBox).BorderBrush = Brushes.Red;


                        }
                        else
                        {
                            countof++;
                            (Questions.Items[i] as CheckBox).BorderBrush = Brushes.Black;
                            (Questions.Items[i + 1] as CheckBox).BorderBrush = Brushes.Black;
                        }
                    }
                }
                if (countof < 57)
                {
                    DoubleAnimation das = new DoubleAnimation(1, TimeSpan.FromSeconds(0.3));
                    MessageBox.Show("Отвечено не навсе вопросы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    timer.Start();
                }
                else
                {
                    Questions.Visibility = Visibility.Hidden;
                    GetResult();
                    CompleteAnswer.Visibility = Visibility.Visible;

                r_t.Visibility = Visibility.Visible;
                End.Visibility = Visibility.Hidden;
                Res.Visibility = Visibility.Visible;

            }

        }

        private void T_l_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Res.Visibility = Visibility.Hidden;
            if (extr > 15) Ekst_text.Visibility = Visibility.Visible; Left.Visibility = Visibility.Visible;
            if (extr < 9) Intr_text.Visibility = Visibility.Visible; Left.Visibility = Visibility.Visible;
        }


        private void T_l_MouseEnter(object sender, MouseEventArgs e)
        {

            t_l.Background = new SolidColorBrush(Color.FromRgb(13, 190, 152));
            t_l.Foreground = Brushes.Black;

        }

        private void T_l_MouseLeave(object sender, MouseEventArgs e)
        {

            t_l.Foreground = new SolidColorBrush(Color.FromRgb(13, 190, 152));
            t_l.Background = Brushes.White;
        }

        private void T_T_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Res.Visibility = Visibility.Hidden;

            if (extr > 15 || neir < 14) Sang_text.Visibility = Visibility.Visible; Left.Visibility = Visibility.Visible;
            if (extr >= 15 || neir >= 14) Holr_text.Visibility = Visibility.Visible; Left.Visibility = Visibility.Visible;
            if (extr <= 9 || neir <= 14) Fleg_text.Visibility = Visibility.Visible; Left.Visibility = Visibility.Visible;
            if (extr <= 9 || neir >= 14) Melan_text.Visibility = Visibility.Visible; Left.Visibility = Visibility.Visible;
        }

        private void T_T_MouseEnter(object sender, MouseEventArgs e)
        {

            t_t.Background = new SolidColorBrush(Color.FromRgb(13, 190, 152));
            t_t.Foreground = Brushes.Black;

        }

        private void T_T_MouseLeave(object sender, MouseEventArgs e)
        {

            t_t.Foreground = new SolidColorBrush(Color.FromRgb(13, 190, 152));
            t_t.Background = Brushes.White;
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            Left.Visibility = Visibility.Hidden;
            Res.Visibility = Visibility.Visible;

            Ekst_text.Visibility = Visibility.Hidden;
            Intr_text.Visibility = Visibility.Hidden; 

            Sang_text.Visibility = Visibility.Hidden;
            Holr_text.Visibility = Visibility.Hidden;
            Fleg_text.Visibility = Visibility.Hidden;
            Melan_text.Visibility = Visibility.Hidden;
        }

        private void Res_Click(object sender, RoutedEventArgs e)
        {
            Text_Eysenck.Visibility = Visibility.Hidden;
            Start.Visibility = Visibility.Hidden;
            r_t.Visibility = Visibility.Hidden;
            Questions.Visibility = Visibility.Visible;
            Res.Visibility = Visibility.Hidden;
            End.Visibility = Visibility.Visible;

            Questions.Items.Clear();
            List();

        }
    }
}
