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
using System.Windows.Threading;

namespace S.F
{
    /// <summary>
    /// Логика взаимодействия для Bek.xaml
    /// </summary>
    public partial class Bek : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        int minutes = 0;
        int seconds = 0;

        public Bek() // скрытие и открытие элементов 
        {
            InitializeComponent();

            Bek_text_zd.Visibility = Visibility.Visible;
            Start.Visibility = Visibility.Visible;
            Test.Visibility = Visibility.Hidden;
            Res.Visibility = Visibility.Hidden;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += SecondsTick;
         
        }

        void SecondsTick(object sender, EventArgs e) // секундамет 
        {

            if (seconds == 59)
            {
                minutes++;
                seconds = 0;
            }
            seconds++;
            if (minutes < 10)
                tmr.Text = ("0" + minutes + ":").ToString();
            else tmr.Text = (minutes + ":").ToString();
            if (seconds < 10) tmr.Text += "0" + seconds.ToString();
            else tmr.Text += seconds.ToString();
        }

        public void IQ_calc() // подсчёт результатов 
        {
            if (minutes < 10)
                time_sec.Text = ("0" + minutes + ":").ToString();
            else tmr.Text = (minutes + ":").ToString();
            if (seconds < 10) time_sec.Text += "0" + seconds.ToString();
            else time_sec.Text += seconds.ToString();

            if (bl >= 0 || bl <= 9) res.Text = "Отсутствие депрессивных симптомов";
            if (bl >= 10 || bl <= 15) res.Text = "Легкая депрессия (субдепрессия)";
            if (bl >= 16 || bl <= 19) res.Text = "Умеренная депрессия";
            if (bl >= 20 || bl <= 29) res.Text = "Выраженная депрессия (средней тяжести)";
            if (bl >= 30 || bl <= 63) res.Text = "Тяжёлая депрессия";



        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) // плавное скрытие формы 
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var animation = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(1));
            animation.Completed += (s, _) => Hide();
            BeginAnimation(UIElement.OpacityProperty, animation);
            S.F.MainWindow.ts5 = false;
        }

        // массив вопросав 
        string[,] vopr = new string[21, 4] {
 {"Я не чувствую себя расстроенным, печальным.","Я расстроен.","Я все время расстроен и не могу от этого отключиться.","Я настолько расстроен и несчастлив, что не могу это выдержать." },
  {"Я не тревожусь о своем будущем.","Я чувствую, что озадачен будущим.","Я чувствую, что меня ничего не ждет в будущем. ","Мое будущее безнадежно, и ничто не может измениться к лучшему." },
 {"Я не чувствую себя неудачником.","Я чувствую, что терпел больше неудач, чем другие люди.","Когда я оглядываюсь на свою жизнь, я вижу в ней много неудач.","Я чувствую, что как личность я - полный неудачник." },
 {"Я получаю столько же удовлетворения от жизни, как раньше.","Я не получаю столько же удовлетворения от жизни, как раньше.","Я больше не получаю удовлетворения ни от чего.","Я полностью не удовлетворен жизнью и мне все надоело." },
 {"Я не чувствую себя в чем-нибудь виноватым.","Достаточно часто я чувствую себя виноватым.","Большую часть времени я чувствую себя виноватым.","Я постоянно испытываю чувство вины." },
 {"Я не чувствую, что могу быть наказанным за что-либо.","Я чувствую, что могу быть наказан.","Я ожидаю, что могу быть наказан.","Я чувствую себя уже наказанным." },
 {"Я не разочаровался в себе.","Я разочаровался в себе.","Я себе противен.","Я себя ненавижу." },
 {"Я знаю, что я не хуже других.","Я критикую себя за ошибки и слабости.","Я все время обвиняю себя за свои поступки.","Я виню себя во всем плохом, что происходит." },
 {"Я никогда не думал покончить с собой.","Ко мне приходят мысли покончить с собой, но я не буду их осуществлять.","Я хотел бы покончить с собой.","Я бы убил себя, если бы представился случай." },
 {"Я плачу не больше, чем обычно.","Сейчас я плачу чаще, чем раньше.","Теперь я все время плачу.","Раньше я мог плакать, а сейчас не могу, даже если мне хочется." },
 {"Сейчас я раздражителен не более, чем обычно.","Я более легко раздражаюсь, чем раньше.","Теперь я постоянно чувствую, что раздражен.","Я стал равнодушен к вещам, которые меня раньше раздражали." },
 {"Я не утратил интереса к другим людям.","Я меньше интересуюсь другими людьми, чем раньше.","Я почти потерял интерес к другим людям.","Я полностью утратил интерес к другим людям." },
 {"Я откладываю принятие решения иногда, как и раньше.","Я чаще, чем раньше, откладываю принятие решения.","Мне труднее принимать решения, чем раньше.","Я больше не могу принимать решения." },
 {"Я не чувствую, что выгляжу хуже, чем обычно.","Меня тревожит, что я выгляжу старым и непривлекательным.","Я знаю, что в моей внешности произошли существенные изменения, делающие меня непривлекательным.","Я знаю, что выгляжу безобразно." },
 {"Я могу работать так же хорошо, как и раньше.","Мне необходимо сделать дополнительное усилие, чтобы начать делать что-нибудь.","Я с трудом заставляю себя делать что-либо.","Я совсем не могу выполнять никакую работу." },
 {"Я сплю так же хорошо, как и раньше.","Сейчас я сплю хуже, чем раньше.","Я просыпаюсь на 1-2 часа раньше, и мне трудно заснуть опять.","Я просыпаюсь на несколько часов раньше обычного и больше не могу заснуть." },
 {"Я устаю не больше, чем обычно.","Теперь я устаю быстрее, чем раньше.","Я устаю почти от всего, что я делаю.","Я не могу ничего делать из-за усталости." },
 {"Мой аппетит не хуже, чем обычно.","Мой аппетит стал хуже, чем раньше.","Мой аппетит теперь значительно хуже.","У меня вообще нет аппетита." },
 {"В последнее время я не похудел или потеря веса была незначительной.","За последнее время я потерял более 2 кг.","Я потерял более 5 кг.","Я потерял более 7 кr." },
 {"Я беспокоюсь о своем здоровье не больше, чем обычно.","Меня тревожат проблемы моего физического здоровья, такие, как боли, расстройство желудка, запоры и т.д.","Я очень обеспокоен своим физическим состоянием, и мне трудно думать о чем-либо другом.","Я настолько обеспокоен своим физическим состоянием, что больше ни о чем не могу думать." },
 {"В последнее время я не замечал изменения своего интереса к близости.","Меня меньше занимают проблемы близости, чем раньше.","Сейчас я значительно меньше интересуюсь межполовыми отношениями, чем раньше.","Я полностью утратил либидо интерес." }
        };
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bek_text_zd.Visibility = Visibility.Hidden;
                Start.Visibility = Visibility.Hidden;
            Test.Visibility = Visibility.Visible;
            timer.Start();
            vp(od);
            od++;
        }
        int bl = 0;
        int od = 0;
        public void br() // заполнение progressbar
        {
            var maximum = bar.Maximum;
            Action action = () => { bar.Value++; }; 

            bar.Dispatcher.Invoke(action);
            int proc = Convert.ToInt32((bar.Value * 100) / 21);
            nom_vopr.Text = Convert.ToString(bar.Value) + " из 21  " + "(" + Convert.ToString(proc) + "%" + ")";
        }

       public void vp(int raz) // смена вопросав 
        {
            _1.Content = vopr[raz, 0];
            _2.Content = vopr[raz, 1];
            _3.Content = vopr[raz, 2];
            _4.Content = vopr[raz, 3];
            if (raz==20)
            {
                Test.Visibility = Visibility.Hidden;
                time.Text = DateTime.Now.ToShortDateString() + "  " + DateTime.Now.ToShortTimeString();
                IQ_calc();
                Res.Visibility = Visibility.Visible;
                timer.Stop();
            }

        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {
           
            bl += 0;
            br();
            vp(od);
            od++;
        }

        private void _2_Click(object sender, RoutedEventArgs e)
        {
            bl += 1;
            br();
            vp(od);
            od++;
        }

        private void _3_Click(object sender, RoutedEventArgs e)
        {
            bl += 2;
            br();
            vp(od);
            od++;
        }

        private void _4_Click(object sender, RoutedEventArgs e)
        {
            bl += 3;
            br();
            vp(od);
            od++;
        }
    }
}
