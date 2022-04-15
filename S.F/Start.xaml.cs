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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace S.F
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Start : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        void NewWindowAsDialog(object sender, RoutedEventArgs e)
        {
            Start myOwnedDialog = new Start();
            myOwnedDialog.Owner = this;
            myOwnedDialog.ShowDialog();
        }
        void NormalNewWindow(object sender, RoutedEventArgs e)
        {
            Start myOwnedWindow = new Start();
            myOwnedWindow.Owner = this;
            myOwnedWindow.Show();
        }
        public Start()
        {

            InitializeComponent();
            timer.Tick += new EventHandler(tmr); //вызываем метод tmr
            timer.Interval = new TimeSpan(0, 0, 5); //задаём интервал
            timer.Start(); //запускаем таймер
        }
        private void tmr(object sender, EventArgs e)
        {

            Pass a = new Pass();
            a.Show(); //Открываем новую форму
            timer.Stop(); //останавливаем таймер
            this.Close(); //закрываем текущую форму 
        }


    }
}

