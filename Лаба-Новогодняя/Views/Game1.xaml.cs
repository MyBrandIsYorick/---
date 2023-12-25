using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using TranslatorDLL;
using FileService;

namespace Лаба_Новогодняя.Views
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\Translate_Lib.json";
        private readonly string StatPath = "C:\\Users\\denep\\OneDrive\\Desktop\\Важное\\Домашка_ПТУ\\C#\\Лаба-Новогодняя\\Game1.txt";
        private BindingList<Translator_Class> _translatorlist;
        private File_Service _service;
        private int countdownSeconds = 30; // Начальное количество секунд для обратного отсчета
        private readonly DispatcherTimer timer = new DispatcherTimer();
        private Random r = new Random();
        private int number,points,choice,word_points,fnumber;
        private bool decision;
        public Window1()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            StartCountdown();
        }
        private async void StartCountdown()
        {
            timer.Start();
        }
        private void FileWriter()
        {
            string[] file_data = File.ReadAllLines(StatPath);
            using (StreamWriter writer = new StreamWriter(StatPath))
            {
                for(int i=0;i<file_data.Length;i++)
                {
                    writer.WriteLine(file_data[i]);
                }
                writer.WriteLine("Попытка "+file_data.Length.ToString()+", Количество очков - "+points.ToString());
            } 
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            countdownSeconds--;
            if (countdownSeconds >= 0)
            {
                UpdateTimeBlock(countdownSeconds);
            }
            else
            {
                timer.Stop();
                Result();
                FileWriter();
                Close();
            }
        }
        public static int getRandom(Random rand, int min, int max, params int[] exclude)
        {
            int result;
            do
            {
                result = rand.Next(min, max);
            }
            while (exclude.Contains(result));

            return result;
        }
        private void Result()
        {
            MessageBox.Show("Ваши очки " + points.ToString());
        }
        private void UpdateTimeBlock(int seconds)
        {
            Timer.Text = seconds.ToString(); 
        }
        private void UpdateTextTranslate()
        {
            number=Convert.ToInt32(r.Next(0, _translatorlist.Count));
            Word1.Text=_translatorlist[number].Word;//Здесь я беру случайное слово из списка по индексу
            choice=r.Next(1,3);//Переменная для определение перевода - правильного или нет
            word_points=_translatorlist[number].Word.Length;
            if (choice==1)//Если переменная 1
            {
                Translate1.Text=_translatorlist[number].Translation;//Настоящий перевод
                decision=true; 
            }
            else
            {
                fnumber=getRandom(r, 0, _translatorlist.Count, number);
                Translate1.Text=_translatorlist[fnumber].Translation;//Ненастоящий
                decision=false;
            }
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _service = new File_Service(PATH);
            try
            {
                _translatorlist = _service.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            UpdateTextTranslate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (decision)
            {
                points+=word_points;
                Points.Text=points.ToString();
                countdownSeconds+=2;
            }
            else
            {
                points-=word_points;
                Points.Text=points.ToString();
            }
            UpdateTextTranslate();
            UpdateTimeBlock(countdownSeconds);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (decision)
            {
                points = points - word_points;
                Points.Text=Convert.ToString(points);
            }
            else
            {
                points = points +word_points;
                Points.Text=points.ToString();
                countdownSeconds+=2;
            }
            UpdateTextTranslate();
            UpdateTimeBlock(countdownSeconds);
        }
    }
}
