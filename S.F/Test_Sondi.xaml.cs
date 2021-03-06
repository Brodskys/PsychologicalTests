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
using System.Windows.Media.Animation;
using System.Data;
using System.Collections.ObjectModel;

namespace S.F
{
    /// <summary>
    /// Логика взаимодействия для Test_Sondi.xaml
    /// </summary>
    public partial class Test_Sondi : Window
    {
       
        public Test_Sondi() // открытие и закрытие элементов 
        {
            InitializeComponent(); 
            Text_Sondi.Visibility = Visibility.Visible;
            Start.Visibility = Visibility.Visible;
            Zadanie.Visibility = Visibility.Hidden;
            Zadanie2.Visibility = Visibility.Hidden;
            _1.Visibility = Visibility.Hidden;
            _2.Visibility = Visibility.Hidden;
            _3.Visibility = Visibility.Hidden;
            _4.Visibility = Visibility.Hidden;
            _5.Visibility = Visibility.Hidden;
            _6.Visibility = Visibility.Hidden;
            _7.Visibility = Visibility.Hidden;
            _8.Visibility = Visibility.Hidden;
            res_text.Visibility = Visibility.Hidden;
            res_rich.Visibility = Visibility.Hidden;
            verh.Visibility = Visibility.Hidden;
            lev.Visibility = Visibility.Hidden;
            prav.Visibility = Visibility.Hidden;
        }
        public int h_plus=0;
        public int h_minus = 0;
        public int s_plus = 0;
        public int s_minus = 0;
        public int e_plus = 0;
        public int e_minus = 0;
        public int hy_plus = 0;
        public int hy_minus = 0;
        public int k_plus = 0;
        public int k_minus = 0;
        public int p_plus = 0;
        public int p_minus = 0;
        public int d_plus = 0;
        public int d_minus = 0;
        public int m_plus = 0;
        public int m_minus = 0;


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) // плавное скрытие формы 
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var animation = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(1));
            animation.Completed += (s, _) => Hide();
            BeginAnimation(UIElement.OpacityProperty, animation);
           S.F.MainWindow.ts1 = false;             
        }
        private void Forms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // событие при нажатиее Enter 
            {
                Text_Sondi.Visibility = Visibility.Hidden;
                Start.Visibility = Visibility.Hidden;
                Zadanie.Visibility = Visibility.Visible;

                _1.Visibility = Visibility.Visible;
                _2.Visibility = Visibility.Visible;
                _3.Visibility = Visibility.Visible;
                _4.Visibility = Visibility.Visible;
                _5.Visibility = Visibility.Visible;
                _6.Visibility = Visibility.Visible;
                _7.Visibility = Visibility.Visible;
                _8.Visibility = Visibility.Visible;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e) // открытие элементов 
        {
            Text_Sondi.Visibility = Visibility.Hidden;
            Start.Visibility = Visibility.Hidden;
            Zadanie.Visibility = Visibility.Visible;

            _1.Visibility = Visibility.Visible;
            _2.Visibility = Visibility.Visible;
            _3.Visibility = Visibility.Visible;
            _4.Visibility = Visibility.Visible;
            _5.Visibility = Visibility.Visible;
            _6.Visibility = Visibility.Visible;
            _7.Visibility = Visibility.Visible;
            _8.Visibility = Visibility.Visible;
        }
      
        List<string> files = new List<string>(); // создание списков 
        int level = 0;
        int stage = 1;

        List<string> badfiles = new List<string>();
        List<string> goodfiles = new List<string>();

        private void _1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) // смена картинок 
        {
            files.Add(_1.Name);
            level++;

            _1.Source = null;
            how();
   
            }

        private void _2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) // смена картинок
        {
            files.Add(_2.Name);
            level++;

            _2.Source = null;
            how();
         
        }

        private void _3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs ee) // смена картинок
        {
            files.Add(_3.Name);
            level++;

            _3.Source = null;
            how();


        }

        private void _4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) // смена картинок
        {
            files.Add(_4.Name);
            level++;

            _4.Source = null;
            how();
 
        }

        private void _5_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) // смена картинок
        {
            files.Add(_5.Name);
            level++;

            _5.Source = null;
            how();

        }

        private void _6_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) // смена картинок
        {
            files.Add(_6.Name);
            level++;

            _6.Source = null;
            how();

        }

        private void _7_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) // смена картинок
        {
            files.Add(_7.Name);
            level++;

            _7.Source = null;
            how();
  
        }

        private void _8_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) // смена картинок
        {
            files.Add(_8.Name);
            level++;

            _8.Source = null;
            how();
   
        }

        private void how() // подсчёт результатов 
        {


            if (level == 2)
            {
            
                goodfiles.AddRange(files);
                Zadanie.Visibility = Visibility.Hidden;
                Zadanie2.Visibility = Visibility.Visible;
                files.Clear();
               
            }
            else if (level == 4)
            {
                Zadanie.Visibility = Visibility.Visible;
                Zadanie2.Visibility = Visibility.Hidden;
                level = 0;
                badfiles.AddRange(files);
                files.Clear();
                stage++;
                if (stage < 7)
                {
                    _1.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/Test Sondi/" + stage.ToString() + ".1.png"));
                    _2.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/Test Sondi/" + stage.ToString() + ".2.png"));
                    _3.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/Test Sondi/" + stage.ToString() + ".3.png"));
                    _4.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/Test Sondi/" + stage.ToString() + ".4.png"));
                    _5.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/Test Sondi/" + stage.ToString() + ".5.png"));
                    _6.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/Test Sondi/" + stage.ToString() + ".6.png"));
                    _7.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/Test Sondi/" + stage.ToString() + ".7.png"));
                    _8.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/Test Sondi/" + stage.ToString() + ".8.png"));
                }
                else
                {
                    Zadanie.Visibility = Visibility.Hidden;
                    Zadanie2.Visibility = Visibility.Hidden;
                    res_text.Visibility = Visibility.Visible;
                    _1.Visibility = Visibility.Hidden;
                    _2.Visibility = Visibility.Hidden;
                    _3.Visibility = Visibility.Hidden;
                    _4.Visibility = Visibility.Hidden;
                    _5.Visibility = Visibility.Hidden;
                    _6.Visibility = Visibility.Hidden;
                    _7.Visibility = Visibility.Hidden;
                    _8.Visibility = Visibility.Hidden;

                    for (int i = 0; i <= goodfiles.Count-1; i++)
                    {
                        switch (goodfiles[i])
                        {
                            case "_1":       
                                h_plus++;
                                break;
                            case "_2":
                                s_plus++;
                                break;
                            case "_3":
                                e_plus++;
                                break;
                            case "_4":
                                hy_plus++;
                                break;
                            case "_5":

                                k_plus++;
                                break;
                            case "_6":

                                p_plus++;
                                break;
                            case "_7":

                                d_plus++;
                                break;
                            case "_8":
                                m_plus++;
                                break;

                            default:
                                break;
                        }
                        switch (badfiles[i])
                        {
                            case "_1":
                                h_minus++;
                                break;
                            case "_2":
                                s_minus++;
                                break;
                            case "_3":
                                e_minus++;
                                break;
                            case "_4":
                                hy_minus++;
                                break;
                            case "_5":

                                k_minus++;
                                break;
                            case "_6":

                                p_minus++;
                                break;
                            case "_7":

                                d_minus++;
                                break;
                            case "_8":
                                m_minus++;
                                break;
                            default:
                                break;
                        }
                        
                    }
 

                    res_rich.Visibility = Visibility.Visible;
                    verh.Visibility = Visibility.Visible;
                    lev.Visibility = Visibility.Visible;
                    prav.Visibility = Visibility.Visible;
                    int[] mas = { h_plus, s_plus, e_plus, hy_plus, k_plus, p_plus, d_plus, m_plus, h_minus, s_minus, e_minus, hy_minus, k_minus, p_minus, d_minus, m_minus};
                    string[] namemas = { "h+", "s+", "e+", "hy+", "k+", "p+", "d+", "m+", "h-", "s-", "e-", "hy-", "k-", "p-", "d-", "m-" };
                    int min = 0;               
                    StringBuilder result = new StringBuilder();
                    for (int i = 0; i < mas.Length; i++)
                    {
                        if (min == mas[i])
                        {
                            result.Append(namemas[i] + ";");
                        }
                        if (min < mas[i]) {
                            min = mas[i];
                            result.Clear();
                            result.Append(namemas[i]+";");
                        }

                    }
                    string[] resmas = result.ToString().Split(';');

                    foreach (string item in resmas)
                    {

                        switch (item) // заполнение результата 
                        {
                            case "h+":
                                Text_1.Text += "(h+) Отличаются преобладанием характеристик чувствительного типа высшей нервной деятельности \n";
                                Text_2.Text += "(h+) Отличается большей теплотой эмоций и конкретной адресованностью эмоциональной привязанности \n";
                                Text_3.Text += "(h+) Это лица, отличающиеся сентиментальностью, экзальтированностью чувств, высокой чувствительностью к средовым воздействиям, их настроение в значительной мере зависит от отношения к ним окружающих; это люди ранимые, впечатлительные, эстетически ориентированные. \n";
                                Text_4.Text += "(h+) Тревожность, ведущая потребность – аффилиативная, то есть потребность в понимании, сочувствии и глубокой привязанности. Реализует эту потребность через привязанность к конкретным людям, через поиск удачи в личной жизни – в семье, в отношениях с мужем (женой), с детьми. Напряженность аффилиативной потребности в связи с тем, что это – ведущая и никогда не насыщаемая полностью потребность, которой могут мешать лишь внешние преграды. Ведущий мотив – избегание неуспеха, стремление найти социальную нишу и защиту в виде более сильной доброжелательной личности. Стиль межличностного поведения: за кажущейся конформностью и зависимостью просматривается бесконфликтная тяга к независимости, стремление уйти от конфронтации с жестким противостоянием сильных личностей в мир идеальных отношений. Застенчивость и ранимость делают человека такого типа внешне более покладистым и уступчивым. Стиль мышления сочетает в себе вербально-аналитические и художественные наклонности. \n";
                                Text_5.Text += "(h+) Служба быта, сфера сервиса, воспитатель детей младшего возраста. При наличии таланта – сфера прикладного искусства, артистическая деятельность, самодеятельность, легко вовлекаются в качестве ведомых в общественную деятельность, в самодеятельные кружки, способны увлекаться танцами, пением, поэзией, религией. \n";
                                Text_6.Text += "(h+) Тяготеют к миссионерской деятельности с тенденцией жертвовать эгоистическими потребностями ради конкретных людей. \n";
                                Text_7.Text += "(h+) Болезненные проявления могут манифестироваться в виде затрудненной сексуальной адаптации и других сексуальных инверсий. Такие люди предпочитают богемный стиль жизни. Отклоняющееся поведение базируется на сексуальной почве. \n";
                                break;
                            case "h-":
                                Text_1.Text += "(h+) Отличаются преобладанием характеристик чувствительного типа высшей нервной деятельности \n";
                                Text_2.Text += "(h+) Черты инфантилизма и отсутствие ярко выраженной мужской или женской дифференцированности, отличаются большей интровертностью и абстрактным направлением аффилиативной потребности. Тип реагирования – сензитивный, меланхолический. \n";
                                Text_3.Text += "(h+) Это лица, отличающиеся сентиментальностью, экзальтированностью чувств, высокой чувствительностью к средовым воздействиям, ведомые, нерешительные, склонные перекладывать принятие решений и ответственность на плечи окружающих, мнительные в отношении своего здоровья; их настроение в значительной мере зависит от отношения к ним окружающих; это люди ранимые, впечатлительные, эстетически ориентированные. \n";
                                Text_4.Text += "(h+) Тревожность, сочетающаяся с пессимистичностью, ведущая потребность – аффилиативная, то есть потребность в понимании, сочувствии и глубокой привязанности. Фрустрированность аффилиативной потребности, реализации которой мешают внутренние запреты (табу), в связи с чем возникает эмоциональный дискомфорт и происходит сублимация этой потребности в самоотверженность и альтруизм, реализуемые в социальной активности. Ведущий мотив – избегание неуспеха, стремление найти социальную нишу и защиту в виде более сильной доброжелательной личности. Стиль межличностного поведения: за кажущейся конформностью и зависимостью просматривается бесконфликтная тяга к независимости, стремление уйти от конфронтации с жестким противостоянием сильных личностей в мир идеальных отношений. Застенчивость и ранимость делают человека такого типа внешне более покладистым и уступчивым. Стиль мышления сочетает в себе вербально-аналитические и художественные наклонности. \n";
                                Text_5.Text += "(h+) Проявляется тяга к врачебной деятельности, к серьезному увлечению музыкой. Может быть выражен интерес к литературе, к вопросам культуры и гуманизма. \n";
                                Text_6.Text += "(h+) Тяготеют к миссионерской деятельности с тенденцией жертвовать эгоистическими потребностями ради общества в целом. \n";
                                Text_7.Text += "(h+) Болезненные проявления могут манифестироваться в виде затрудненной сексуальной адаптации и других сексуальных инверсий. Такие люди предпочитают богемный стиль жизни. Отклоняющееся поведение базируется на сексуальной почве. \n";
                                break;
                            case "s+":
                                Text_1.Text += "(s+) Сильный тип высшей нервной деятельности. \n";
                                Text_2.Text += "(s+) Атлетическая конституция, стеничный (гипертимный) тип реагирования. \n";
                                Text_3.Text += "(s+) Решительность, жесткость, предприимчивость, лидерство, эгоистичность, трезвый взгляд на жизнь, уверенность в себе, властность, независимость, отсутствие озабоченности переживаниями других людей, нежелание ограничивать себя в чем-либо, преклонение перед достижениями технической мысли, страсть к скоростям, спартанские черты, воинственный характер, агрессивность, сексуальная активность без выраженной склонности к глубокой привязанности. \n";
                                Text_4.Text += "(s+) Высокий уровень мотивации достижения, активность, агрессивность, низкий уровень интрапсихической активности. Эмоции внешне проявляются достаточно бурно – негодование, гордость, возмущение, злость, восхищение, но не оставляют глубокого следа в душе. Стиль межличностного поведения независимый, лидирующий. Тип восприятия целостный, интуитивный, без достаточной опоры на опыт, ориентированный на собственное субъективное чутье. В стрессе – импульсивные поведенческие реакции. Защитный механизм – вытеснение или отреагирование вовне. \n";
                                Text_5.Text += "(s+) Водитель транспорта – шофер, летчик, машинист; лесоруб, охотник, прозектор, патологоанатом, фермер, слесарь, техник-механик, стоматолог, грузчик, военачальник, солдат, прокурор, охранник. \n";
                                Text_6.Text += "(s+) В сфере урбанизации и индустрии, приверженность к технократии. \n";
                                Text_7.Text += "(s+) Садизм, антисоциальное поведение с жестокими проявлениями. \n";
                                break;
                            case "s-":
                                Text_1.Text += "(s-) Слабый тип высшей нервной деятельности. \n";
                                Text_2.Text += "(s-) Лептосомная (астеническая) конституция, гипостенический, гипотимный тип реагирования. \n";
                                Text_3.Text += "(s-) Нерешительность, мягкость, зависимость, склонность к идеализации объекта привязанности, конформность, сочувствие к людям, тенденция к самоограничению ради близких, склонность к глубокой привязанности при слабо выраженной сексуальной озабоченности, миротворческие тенденции. Приоритет культурных ценностей. \n";
                                Text_4.Text += "(s-) Высокий уровень мотивации избегания неуспеха. Стиль межличностного поведения зависимый, пассивный. Тип восприятия вербально-аналитический. В стрессе – ограничительное поведение, повышение контроля сознания. Защитный механизм – отказ от самореализации. \n";
                                Text_5.Text += "(s-) Медицинский работник, врач, медсестра, парикмахер, маникюрша, воспитатель, библиотекарь, канцелярский или архивный работник, делопроизводитель, научный работник, филолог, искусствовед. \n";
                                Text_6.Text += "(s-) В сфере культуры и гуманистической деятельности. \n";
                                Text_7.Text += "(s-) Мазохизм, фетишизм, самоуничижение, суицидальные тенденции. \n";
                                break;
                            case "e+":
                                Text_1.Text += "(e+) Подвижный тип высшей нервной деятельности. \n";
                                Text_2.Text += "(e+) Пикнический, эмоционально-неустойчивый, смешанный тип реагирования, тревожный. \n";
                                Text_3.Text += "(e+) Конформность установок, декларация альтруизма, отзывчивость, склонность к сотрудничеству, доброжелательность, самоотверженность, религиозность, терпеливость, стремление помогать другим. \n";
                                Text_4.Text += "(e+) Изменчивость мотивационной направленности в зависимости от ситуации, страх неудачи превалирует над мотивацией достижения, ориентация на общепринятые нормы поведения и мораль общества, эмоциональная неустойчивость, повышенная тревожность, сотрудничающий и альтруистический стиль взаимодействия с окружающими, художественный и вербальный тип восприятия. Реакция на стресс – страх. Защитный механизм – соматизация. \n";
                                Text_5.Text += "(e+) Специалист по охране здоровья, священнослужитель, миссионер, учитель, воспитатель, адвокат. \n";
                                Text_6.Text += "(e+) Общественно полезная активность в сфере этики морали. \n";
                                Text_7.Text += "(e+) Склонность к вегетативной неустойчивости, мигреням; эпилептоидная слащавость. \n";
                                break;
                            case "e-":
                                Text_1.Text += "(e-) Ригидный тип высшей нервной деятельности. \n";
                                Text_2.Text += "(e-) Атлетический, агрессивный, смешанный тип реагирования, эксплозивный. \n";
                                Text_3.Text += "(e-) Тенденция к накоплению негативных эмоций с последующей разрядкой в виде приступов ярости, злопамятность, мстительность, завистливость, ревность, представление об окружающем мире как враждебно настроенном, чем оправдывается собственная жестокость. \n";
                                Text_4.Text += "(e-) Устойчивость мотивации достижения, упорство в преследовании своих целей, внешнеобвиняющий тип реагирования, конфликтность в межличностных отношениях, стиль мышления конкретно-логический, тип реакции на стресс – агрессивный, взрывной; защитный механизм – враждебные поведенческие реакции или рациональная переработка. \n";
                                Text_5.Text += "(e-) Моряк, шофер, летчик, машинист, пожарник, артиллерист, кузнец, кочегар, пиротехник, спортсмен (боксер, штангист, вольная борьба, карате, самбо), администратор, начальник домоуправления, ЖЭКа или РЭО, заведующий гаражом. \n";
                                Text_6.Text += "(e-) Противопоставление своих установок этико-моральным устоям. \n";
                                Text_7.Text += "(e-) Эпилептоидный педантизм и эксплозивность. \n";
                                break;
                            case "hy+":
                                Text_1.Text += "(hy+) Смешанный неустойчивый тип высшей нервной деятельности. \n";
                                Text_2.Text += "(hy+) Инфантильный. Эмоционально незрелый, неустойчивый, эмотивный тип реагирования. \n";
                                Text_3.Text += "(hy+) Отличается высокой эмоциональной вовлеченностью, неустойчивостью и изменчивостью эмоций, чертами демонстративности, противоречивостью установок (быть причастным к интересам своей группы и одновременно отстаивать свои эгоцентрические интересы, декларировать альтруизм и реализовать эгоистические потребности). \n";
                                Text_4.Text += "(hy+) Демонстративная личность с противоречивой направленностью мотивов; мотивация достижения сталкивается со столь же выраженной мотивацией избегания неуспеха. Склонность к соматизации конфликта. Тип восприятия художественный, чувственный, наглядно-образное мышление. Стиль межличностного поведения гибкий с тенденцией к перевоплощению в разные социальные роли. \n";
                                Text_5.Text += "(hy+) Актер, журналист, манекенщица, художник, общественный деятель, дипломат, продавец, учитель, воспитатель, администратор. \n";
                                Text_6.Text += "(hy+) Декларация альтруизма, участие в общественных движениях, служение народу. \n";
                                Text_7.Text += "(hy+) Истерические конверсионные симптомы, авантюризм и псевдология как варианты отклоняющегося поведения. \n";
                                break;
                            case "hy-":
                                Text_1.Text += "(hy-) Смешанный неустойчивый тип высшей нервной деятельности. \n";
                                Text_2.Text += "(hy-) Инфантильный. Эмоционально незрелый, неустойчивый, эмотивный тип реагирования. \n";
                                Text_3.Text += "(hy-) Отличается высокой тревожностью, капризностью, склонностью к драматизации имеющихся проблем. \n";
                                Text_4.Text += "(hy-) Демонстративная личность с противоречивой направленностью мотивов; мотивация достижения сталкивается со столь же выраженной мотивацией избегания неуспеха. Склонность к соматизации конфликта. Тип восприятия художественный, чувственный, наглядно-образное мышление. Стиль межличностного поведения гибкий с тенденцией к перевоплощению в разные социальные роли. Личность отличается высоким самоконтролем и подавлением вышеперечисленных свойств. Отсюда «матовые» черты личности, «ищущей признания», со склонностью к лжи и фарисейству, а также боязливость и мнительность. \n";
                                Text_5.Text += "(hy-) Служитель религиозного культа, миссионер, портной, работник сферы обслуживания. \n";
                                Text_6.Text += "(hy-) Декларация альтруизма, участие в общественных движениях, служение народу. \n";
                                Text_7.Text += "(hy-) Психосоматические расстройства, ханжество. \n";
                                break;
                            case "k+":
                                Text_1.Text += "(k+) Смешанный, ригидный, левополушарный тип высшей нервной деятельности. \n";
                                Text_2.Text += "(k+) Лептосомный (астенический), шизоидный ригидный тип реагирования. \n";
                                Text_3.Text += "(k+) Рассудочность, эмоциональная холодность, эгоистическая сосредоточенность на внутреннем мире собственных переживаний, оторванность от практических забот, склонность к широким обобщениям, оригинальность и независимость суждений, своеобразие поступков, формальность и избирательность в общении, педантичность, недоверчивость, скрытность, замкнутость. \n";
                                Text_4.Text += "(k+) Созерцательная позиция, субъективная мотивация, раздвоенное «Я», интеллект довлеет над эмоциями, стиль межличностного поведения – интровертный, стиль мышления – формально-логический. В стрессе блокировка или непредсказуемые действия, защитная реакция – бегство в мир фантазии. \n";
                                Text_5.Text += "(k+) Математик, бухгалтер, солдат, печатник, фермер, инженер, механик, лаборант, экономист, счетовод, прикладное творчество, поделка по дереву, скульптор, плотник, физик-теоретик, литературный критик. \n";
                                Text_6.Text += "(k+) Деятельность носит оторванный от повседневных нужд характер и связана с экономикой, математикой, физикой. \n";
                                Text_7.Text += "(k+) Болезненно заостренные черты трансформируются в шизоидные проявления, кататонические симптомы, аутичность, а отклоняющееся поведение – в бродяжничество, социальную дезадаптацию. \n";
                                break;
                            case "k-":
                                Text_1.Text += "(k-) Слабый, инертный, левополушарный тип высшей нервной деятельности. \n";
                                Text_2.Text += "(k-) Лептосомный (астенический), гипостенический тормозимый тип реагирования. \n";
                                Text_3.Text += "(k-) Неуверенность в себе, повышенная мнительность и тревожность, сдержанность в проявлении чувств, застенчивость, стремление к избеганию конфликтов, ориентация на нормы поведения своего круга общения, повышенное чувство вины. \n";
                                Text_4.Text += "(k-) Пассивно-страдательная позиция, выраженное «супер-Эго», тревожно-мнительные черты, пессимистичность, преобладает мотивация избегания неуспеха, стиль межличностного поведения – пассивно-зависимый, стиль мышления – вербально-аналитический. В стрессе – блокировка и нерешительность, защитный механизм – бегство в мир мечтаний. \n";
                                Text_5.Text += "(k-) Педагог, филолог, философ, ученый, литератор, библиотекарь, делопроизводитель, чиновник. \n";
                                Text_6.Text += "(k-) Деятельность носит оторванный от повседневных нужд характер и связана с мистикой, метафизикой, искусством, эстетикой, логикой. \n";
                                Text_7.Text += "(k-) Возможна трансформация в тревожно-мнительные черты, навязчивости, депрессивно-ипохондрические нарушения, отклоняющееся поведение характеризуется полной пассивностью, замкнутостью. \n";
                                break;
                            case "p+":
                                Text_1.Text += "(p+) Сильный тип высшей нервной деятельности. \n";
                                Text_2.Text += "(p+) Сочетание атлетических и флегматических конституциональных особенностей. Темперамент стенический, гипертимный. \n";
                                Text_3.Text += "(p+) Спонтанность, общительность, непосредственность поведения, максимализм в эмоциональных проявлениях, амбициозность, стремление к лидированию, высокая самооценка, склонность к риску, чувство соперничества, предприимчивость, импульсивность. \n";
                                Text_4.Text += "(p+) Высокая мотивация достижения успеха, экстравертированность, активность, ведущая потребность – власть, стиль межличностного поведения – доминирующий, стиль познавательной деятельности – целостный, эвристический, опережающий опыт. В стрессе – сверхактивность. Защитный механизм – отреагирование вовне и вытеснение из сознания негативной информации. \n";
                                Text_5.Text += "(p+) Администратор, руководитель, предприниматель, геолог, психотерапевт, психолог, путешественник, писатель, журналист, циркач, каскадер, шофер-гонщик. \n";
                                Text_6.Text += "(p+) Политическая и административная активность. \n";
                                Text_7.Text += "(p+) Экспансивно-шизоидная акцентуация, мания величия; отклоняющееся поведение – алкоголизм, наркомания, противоправные поступки: аферизм, хулиганские действия. \n";
                                break;
                            case "p-":
                                Text_1.Text += "(p-) Смешанный-инертный тип высшей нервной деятельности. \n";
                                Text_2.Text += "(p-) Сочетание атлетических и флегматических конституциональных особенностей. Темперамент смешанный ригидный. \n";
                                Text_3.Text += "(p-) Избирательность в контактах, скрытность, подозрительность, ранимость в отношении критики, скептическая оценка чужого мнения, настороженность, тенденция приписывать окружающим собственную враждебность, стремление к правдоискательству. \n";
                                Text_4.Text += "(p-) Мотивация избегания неуспеха так же высока, как мотивация достижения, что создает внутреннюю напряженность. Повышенная конфликтность, внешнеобвиняющий тип реагирования, опора на накопленный опыт, стиль мышления – инертный, конкретный, синтетический. Склонность к построению негибкой системы нарушенных межличностных отношений, проекция собственной враждебности вовне. \n";
                                Text_5.Text += "(p-) Химик, инженер, изобретатель, музыкант, художник, скульптор, милиционер, портной, печник, столяр, плотник, хлебороб, сапожник, мануальный терапевт, специалист по акупунктуре. \n";
                                Text_6.Text += "(p-) Исследовательская и правдоискательская активность. \n";
                                Text_7.Text += "(p-) Паранойя, шизофрения; сутяжно-кверулянтские тенденции. \n";
                                break;
                            case "d+":
                                Text_1.Text += "(d+) Неустойчивый смешанный тип высшей нервной деятельности, подвижность нервных процессов. \n";
                                Text_2.Text += "(d+) Циклоидный, циклотимический тип реагирования. \n";
                                Text_3.Text += "(d+) Легко меняющееся настроение, выраженная зависимость от воздействия окружающей среды; склонность к слезам и смешливости; экзальтированность. Выбор характерен для экзальтированных, общительных, ищущих новых контактов, непостоянных в любви и дружбе людей, расточительных, неумеренных во всем, радикально настроенных, лукавых. \n";
                                Text_4.Text += "(d+) Экстравертированность, оптимистичность, реалистичность, коммуникабельность, живость реакций, высокая мотивация достижения, поиски признания. Стиль познавательной деятельности – эвристический, целостный. Лидерские тенденции. В стрессе – активность. Защитный механизм – отрицание проблем. Дезадаптация по экзальтированному типу. \n";
                                Text_5.Text += "(d+) Предприниматель, коммивояжер, специалист по рекламе, артист, журналист, художник-шаржист, сатирик. \n";
                                Text_6.Text += "(d+) В сфере бизнеса, общественно-административной деятельности. \n";
                                Text_7.Text += "(d+) Экспансивный, ищущий признания, эмоционально-неустойчивый тип акцентуации, антисоциальное поведение (воровство, аферизм). \n";
                                break;
                            case "d-":
                                Text_1.Text += "(d-) Неустойчивый смешанный тип высшей нервной деятельности, подвижность нервных процессов. \n";
                                Text_2.Text += "(d-) Циклоидный, циклотимический тип реагирования. \n";
                                Text_3.Text += "(d-) Легко меняющееся настроение, выраженная зависимость от воздействия окружающей среды; склонность к слезам и смешливости; экзальтированность. Глубина привязанности, постоянство, верность, консерватизм, склонность к самоограничению, честность и искренность. \n";
                                Text_4.Text += "(d-) Интровертированность, пессимистичность, необщительность, преобладание мотивации избегания неуспеха. В стрессе – блокировка, зависимое поведение. Защитная реакция – отказ от реализации своих потребностей, интропунитивные реакции; дезадаптация по депрессивному типу. \n";
                                Text_5.Text += "(d-) Антиквар, хранитель раритетов, коллекционер, литературный критик, банкир, врач-терапевт, экономист, делопроизводитель, работник библиотеки, музея. \n";
                                Text_6.Text += "(d-) В сфере духовных ценностей, в области масштабных финансовых операций. \n";
                                Text_7.Text += "(d-) Меланхолическая акцентуация, депрессивное состояние. \n";
                                break;
                            case "m+":
                                Text_1.Text += "(m+) Сильный неустойчивый тип высшей нервной деятельности, правополушарный вариант. \n";
                                Text_2.Text += "(m+) Пикнический или инфантильный. Стеничный (гипертимный) экстравертный тип реагирования, активный, оптимистичный, экзальтированный. \n";
                                Text_3.Text += "(m+) Поиск признания, стремление к эмоциональной вовлеченности, впечатлительность, боязливость, стремление к сотрудничеству, стремление к сопричастности групповым интересам. \n";
                                Text_4.Text += "(m+) Неустойчивая мотивация, эмоциональная лабильность, экстравертированность, гибкость и общительность в контактах с окружающими, художественное и наглядно-образное восприятие, реакция на стресс – эмоционально яркая со склонностью к страхам, защитный механизм – психосоматический или по типу вытеснения. \n";
                                Text_5.Text += "(m+) Преподаватель языка, зубной врач, импресарио, концертмейстер, кинорежиссер, общественник, музыкант, участник самодеятельности, клубная работа. \n";
                                Text_6.Text += "(m+) Искусство, общественная активность. \n";
                                Text_7.Text += "(m+) Истероидные и психосоматические расстройства, фиксированные страхи, гипомания. \n";
                                break;
                            case "m-":
                                Text_1.Text += "(m-) Сильный неустойчивый тип высшей нервной деятельности, правополушарный вариант. \n";
                                Text_2.Text += "(m-) Пикнический или инфантильный. Стеничный (гипертимный) экстравертный тип реагирования, активный, оптимистичный, экспансивный. \n";
                                Text_3.Text += "(m-) Самостоятельность, независимость, потребность в самореализации, выраженный индивидуализм, настойчивость в достижении цели, стремление потакать своим слабостям, избыточная увлеченность развлечениями, поверхностность в контактах с окружающими, импульсивность в высказываниях и поступках. \n";
                                Text_4.Text += "(m-) Мотивы поведения обусловлены эгоцентричностью сиюминутных потребностей; самооценка завышенная; эмоциональная жесткость; интуитивное восприятие, опережающие опыт суждения; защитный механизм – отрицание проблем. \n";
                                Text_5.Text += "(m-) Коммивояжер, агент, директор гостиницы, ресторана, главный врач больницы, зубной хирург, биржевик, предприниматель, геолог, скалолаз, водитель-дальнобойщик. \n";
                                Text_6.Text += "(m-) Административная сфера, независимость от ограничивающих свободу действия жестких рамок, криминальная направленность. \n";
                                Text_7.Text += "(m-) Импульсивное поведение, экспансивно-шизоидная акцентуация, алкоголизм, наркомания, аферизм, мошенничество. \n";
                                break;

                            default:
                                break;
                        }
                    }
                }
                }
            }
        }     
    }




