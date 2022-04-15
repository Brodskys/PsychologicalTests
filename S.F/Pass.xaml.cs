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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace S.F
{
    /// <summary>
    /// Логика взаимодействия для Pass.xaml
    /// </summary>
    public partial class Pass : Window
    {
        public Pass()
        {
            InitializeComponent();
        }
        private void Username_MouseEnter(object sender, MouseEventArgs e)
        {

            if (!keypress_username)
                Username.Text = string.Empty;

        }

        private void Password_MouseEnter(object sender, MouseEventArgs e)
        {
            if(!keypress_pass) 
            Password.Text = string.Empty;
        }

        private void GlowFrame_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (Username.Text == "admin" && Password.Text == "admin"  ) // ввод логина и пароля 
            //{
                MainWindow form = new MainWindow();
                form.Show(); // открытие основной формы
                Hide(); // скрытие формы
            //}
            //else
            //{
            //    MessageBox.Show("Неверный логин или пароль","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error); // вывод ошибки
            //}
        }
        public bool keypress_pass=false;
        public bool keypress_username = false;
        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            keypress_username = true;
           
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            keypress_pass = true;
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.Key == Key.Enter) // событие при нажатии на Enter
            {
                if (Username.Text == "admin" && Password.Text == "admin") // ввод логина и пароля 
                {


                    MainWindow form = new MainWindow();
                    form.Show(); // открытие основной формы
                    Hide(); // скрытие формы
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль"); // вывод ошибки
                }
            }

           
        }
    }
}