using Habanero.Faces.Base;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace S.F
{
    /// <summary>
    /// Логика взаимодействия для Test_Rorschach.xaml
    /// </summary>
    public partial class Test_Rorschach : Window
    {
        public Test_Rorschach() // открытие и скрытие элементов 
        {
            InitializeComponent();
            Text_Rorschach.Visibility = Visibility.Visible;
            Start.Visibility = Visibility.Visible;
            Img.Visibility = Visibility.Hidden;
            bt_otv_1.Visibility = Visibility.Hidden;
            bt_otv_2.Visibility = Visibility.Hidden;
            bt_otv_3.Visibility = Visibility.Hidden;
            bt_otv_4.Visibility = Visibility.Hidden;
            bt_otv_5.Visibility = Visibility.Hidden;
            res_text.Visibility = Visibility.Hidden;
            Rh_otv.Visibility = Visibility.Hidden;
            M.Visibility = Visibility.Visible;
            W.Visibility = Visibility.Visible;
            verh.Visibility = Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) // плавное закрытие формы 
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var animation = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(1));
            animation.Completed += (s, _) => Hide();
            BeginAnimation(UIElement.OpacityProperty, animation);
            S.F.MainWindow.ts2 = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (M.IsChecked == true || W.IsChecked == true) // открытие элементов при нажатии выбора пола
            {

                Text_Rorschach.Visibility = Visibility.Hidden;
                Start.Visibility = Visibility.Hidden;
                Img.Visibility = Visibility.Visible;
                bt_otv_1.Visibility = Visibility.Visible;
                bt_otv_2.Visibility = Visibility.Visible;
                bt_otv_3.Visibility = Visibility.Visible;
                bt_otv_4.Visibility = Visibility.Visible;
                bt_otv_5.Visibility = Visibility.Visible;

             M.Visibility = Visibility.Hidden;
               W.Visibility = Visibility.Hidden;

            }
            else
            {
                MessageBox.Show("Выберите свой пол", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); // вывод ошибки 
                M.BorderBrush= Brushes.Red;
                W.BorderBrush = Brushes.Red;
            }
        }
        int raz = 1;

        string[,] text = new string[,] {  // массив с результатами 
        {"Боязнь внешнего мира и скрытых внутриличностных проблем. ","Уязвимость, а также  неспособность устоять перед проблемами. ","Способность расти, меняться и преодолевать трудности. ","Человек одинок, и в некоторой степени испытывает ощущение заброшенности. ","Боязнь внешнего мира. " },
        {"Созависимость, одержимость сексом, неоднозначные чувства в отношении секса или зацикленность на отношениях. ","Эгоцентризм или Самолюбование. Это может быть и отрицательная, и положительная черта, в зависимости от чувств человека. ","Преданный и верный друг. ","Склонен к раздумьям. ","Агрессия, конкуренция, независимость, восстановление, а также — чувство уязвимости, незащищенность или открытость и честность. " },
        {"В социальных взаимодействиях вы занимаете позицию соперника. ","Ощущение своей нечистоты, незащищенности или же параноидальный страх. ","Активная общественная жизнь. ","Эгоцентризм, пренебрежение другими или несостоятельность воспринимать людей такими, какие они есть. ","" },
        {"Неполноценность, сильный страх перед авторитетами или представителями власти, в частности перед отцом. ","Существенный дискомфорт, связанный с темой отца. С другой стороны, может свидетельствовать, что нет проблем с авторитетностью и неполноценностью. ","","","" },
        {"Глубокие личные проблемы. ","Глубокие личные проблемы. ","Глубокие личные проблемы. ","","" },
        {"Нежелании вступать в тесные отношения с другими людьми. ","Изолированность от общества, душевная пустота. ","Скрытая депрессия. ","Различные страхи сексуального содержания. ","" },
        {"Сложные отношения с женским полом. ","Обостренный материнский инстинкт, а также необходимость в заботе, ласке. ","Желаник быть любимым, стремлении создать отношения. ","Сложность в половой жизни. ","Конфликт с матерью. " },
        {"Нахождение в сложной жизненной ситуации. ","Расслабленность и эмоциональное спокойствие. ","Детализированное и фрагментарное мышление, иногда мелочность. ","","" },
        {"Невозможность существовать без чётких границ и рамок, важность того, что бы всё было разложено по полочкам. ","Способность быстро создать порядок из неорганизованной информации. ","","","" },
        {"Привязанность к людям и вещам, терпимость. ","Терпимость, сила противостоять проблемам, но при этом боязнь причинить вред себе и своим близким. ","Страх, ощущение запутанности или свидетельствование, что вы оказались в неудобном положении из-за собственной лжи. ","Чувство обмана, опасности. ","Возможный рост как личности. " }
        };

        void vivod_inf(int raz, Button but) // вывод результата  
        {
            switch (but.Name)
            {
                case "bt_otv_1":

                    if (raz==7)
                    {
                        if (M.IsChecked==true)
                        {
                            Vivod_text.Text += text[raz - 1, 0] ;
                        }
                        if (W.IsChecked == true)
                        {
                            Vivod_text.Text += text[raz - 1, 4];
                        }
                    }
                    else
                    Vivod_text.Text += text[raz - 1, 0];
                    break;
                case "bt_otv_2":
                    Vivod_text.Text += text[raz - 1, 1];
                    break;
                case "bt_otv_3":
                    Vivod_text.Text += text[raz - 1, 2] ;
                    break;
                case "bt_otv_4":
                    Vivod_text.Text += text[raz - 1, 3] ;
                    break;
                case "bt_otv_5":
                    Vivod_text.Text += text[raz - 1, 4];
                    break;
                default:
                    break;
            }
        }

        void ChangePhoto(int raz,Button but) // смена названия кнопак 
        {
            switch (raz)
            {
                case 2:
                    bt_otv_1.Content = "Две фигуры";
                    bt_otv_2.Content = "Человек, который смотрит на себя в зеркало";
                    bt_otv_3.Content = "Собака";
                    bt_otv_4.Content = "Слон"; 
                    bt_otv_5.Content = "Медведь";
                    Img.Source = new BitmapImage(new Uri(@"Image/Test Rorschach/2.jpg", UriKind.RelativeOrAbsolute));
                    break;

                case 3:
                    bt_otv_1.Content = "Два человека играют в игру";
                    bt_otv_2.Content = "Люди моют руки";
                    bt_otv_3.Content = "Люди за едой";
                    bt_otv_4.Content = "Человек, смотрящий в зеркало";
                    bt_otv_5.Visibility = Visibility.Hidden;
                    Img.Source = new BitmapImage(new Uri(@"Image/Test Rorschach/3.jpg", UriKind.RelativeOrAbsolute));
                    break;

                case 4:
                    bt_otv_1.Content = "Монстр";
                    bt_otv_2.Content = "Шкура животного";
                    bt_otv_3.Visibility = Visibility.Hidden;
                    bt_otv_4.Visibility = Visibility.Hidden;
                    bt_otv_5.Visibility = Visibility.Hidden;
                    Img.Source = new BitmapImage(new Uri(@"Image/Test Rorschach/4.jpg", UriKind.RelativeOrAbsolute));
                    break;

                case 5:
                    bt_otv_1.Content = "Летучая мышь";
                    bt_otv_2.Content = "Бабочка";
                    bt_otv_3.Content = "Моль";
                    bt_otv_4.Content = "Что-то другое";
                    bt_otv_3.Visibility = Visibility.Visible;
                    bt_otv_4.Visibility = Visibility.Visible;
                    bt_otv_5.Visibility = Visibility.Hidden;

                    Img.Source = new BitmapImage(new Uri(@"Image/Test Rorschach/5.jpg", UriKind.RelativeOrAbsolute));
                    break;

                case 6:
                    bt_otv_1.Content = "Шкура животного";
                    bt_otv_2.Content = "Нора";
                    bt_otv_3.Content = "Страхи или ответы сексуального содержания";
                    bt_otv_4.Content = "Половой акт, и при этом вызывает ощущение шока";
                    bt_otv_4.Visibility = Visibility.Visible;
                    Img.Source = new BitmapImage(new Uri(@"Image/Test Rorschach/6.jpg", UriKind.RelativeOrAbsolute));
                    break;

                case 7:
                    bt_otv_1.Content = "Что-то другое";
                    bt_otv_2.Content = "Женские головы или дети";
                    bt_otv_3.Content = "Поцелуй";
                    bt_otv_4.Content = "Женский половой орган";

                    Img.Source = new BitmapImage(new Uri(@"Image/Test Rorschach/7.jpg", UriKind.RelativeOrAbsolute));
                    break;

                case 8:
                    bt_otv_1.Content = "Что-то другое";
                    bt_otv_2.Content = "Четвероногое животное";
                    bt_otv_3.Content = "Несколько образов";
                    bt_otv_4.Visibility = Visibility.Hidden;
                    bt_otv_5.Visibility = Visibility.Hidden;


                    Img.Source = new BitmapImage(new Uri(@"Image/Test Rorschach/8.jpg", UriKind.RelativeOrAbsolute));
                    break;

                case 9:

                    bt_otv_1.Content = "Фигура человека";
                    bt_otv_2.Content = "Таинственное и мистическое ";
                    bt_otv_3.Visibility = Visibility.Hidden;
                    bt_otv_4.Visibility = Visibility.Hidden;
                    bt_otv_5.Visibility = Visibility.Hidden;
                    Img.Source = new BitmapImage(new Uri(@"Image/Test Rorschach/9.jpg", UriKind.RelativeOrAbsolute));
                    break;

                case 10:
                    bt_otv_1.Content = "Краб";
                    bt_otv_2.Content = "Лобстер";
                    bt_otv_3.Content = "Паук";
                    bt_otv_4.Content = "Змеи";
                    bt_otv_5.Content = "Гусеница";
                    bt_otv_3.Visibility = Visibility.Visible;
                    bt_otv_4.Visibility = Visibility.Visible;
                    bt_otv_5.Visibility = Visibility.Visible;
                    Img.Source = new BitmapImage(new Uri(@"Image/Test Rorschach/10.jpg", UriKind.RelativeOrAbsolute));                      
                    break;
                case 11:

                    Img.Visibility = Visibility.Hidden;
                    bt_otv_1.Visibility = Visibility.Hidden;
                    bt_otv_2.Visibility = Visibility.Hidden;
                    bt_otv_3.Visibility = Visibility.Hidden;
                    bt_otv_4.Visibility = Visibility.Hidden;
                    bt_otv_5.Visibility = Visibility.Hidden;
                    Rh_otv.Visibility = Visibility.Visible;
                    res_text.Visibility = Visibility.Visible;
                    verh.Visibility = Visibility.Visible;
                    break;

                default:
                    break;
            }           
        }
        private void Bt_otv_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;


            vivod_inf(raz, but);
            raz++;
            ChangePhoto(raz, but);
        }

        private void M_Checked(object sender, RoutedEventArgs e)
        {
            M.BorderBrush = Brushes.Gray;
            W.BorderBrush = Brushes.Gray;
            if (M.IsChecked ==true)        
                W.IsChecked = false;


        }

        private void W_Checked(object sender, RoutedEventArgs e)
        {
            M.BorderBrush = Brushes.Gray;
            W.BorderBrush = Brushes.Gray;
            if (W.IsChecked == true)
                M.IsChecked = false;

        }
        private void Bt_otv_1_MouseEnter(object sender, MouseEventArgs e) // смена цвета при навидении 
        {
            var bc = new BrushConverter();
            bt_otv_1.Background = (Brush)bc.ConvertFrom("#FFFFE179");
        }

        private void Bt_otv_1_MouseLeave(object sender, MouseEventArgs e) // смена цвета при навидении 
        {
            var bc = new BrushConverter();
            bt_otv_1.Background = (Brush)bc.ConvertFrom("#FFF9C821");
        }

        private void Bt_otv_2_MouseEnter(object sender, MouseEventArgs e) // смена цвета при навидении 
        {
            var bc = new BrushConverter();
            bt_otv_2.Background = (Brush)bc.ConvertFrom("#FFFFE179");
        }

        private void Bt_otv_2_MouseLeave(object sender, MouseEventArgs e) // смена цвета при навидении 
        {
            var bc = new BrushConverter();
            bt_otv_2.Background = (Brush)bc.ConvertFrom("#FFF9C821");
        }

        private void Bt_otv_3_MouseEnter(object sender, MouseEventArgs e) // смена цвета при навидении 
        {
            var bc = new BrushConverter();
            bt_otv_3.Background = (Brush)bc.ConvertFrom("#FFFFE179");
        }

        private void Bt_otv_3_MouseLeave(object sender, MouseEventArgs e) // смена цвета при навидении 
        {
            var bc = new BrushConverter();
            bt_otv_3.Background = (Brush)bc.ConvertFrom("#FFF9C821");
        }

        private void Bt_otv_4_MouseEnter(object sender, MouseEventArgs e) // смена цвета при навидении 
        {
            var bc = new BrushConverter();
            bt_otv_4.Background = (Brush)bc.ConvertFrom("#FFFFE179");
        }

        private void Bt_otv_4_MouseLeave(object sender, MouseEventArgs e) // смена цвета при навидении 
        {
            var bc = new BrushConverter();
            bt_otv_4.Background = (Brush)bc.ConvertFrom("#FFF9C821");
        }

        private void Bt_otv_5_MouseEnter(object sender, MouseEventArgs e) // смена цвета при навидении 
        {
            var bc = new BrushConverter();
            bt_otv_5.Background = (Brush)bc.ConvertFrom("#FFFFE179");
        }

        private void Bt_otv_5_MouseLeave(object sender, MouseEventArgs e) // смена цвета при навидении 
        {
            var bc = new BrushConverter();
            bt_otv_5.Background = (Brush)bc.ConvertFrom("#FFF9C821");
        }
    }
}
