using System.ComponentModel;
using System.Windows;
using TranslatorDLL;
using FileService;
using System.IO;

namespace Лаба_Новогодняя.Views
{
    /// <summary>
    /// Логика взаимодействия для Game2.xaml
    /// </summary>
    public partial class Game2 : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\Translate_Lib.json";
        private readonly string StatPath = "C:\\Users\\denep\\OneDrive\\Desktop\\Важное\\Домашка_ПТУ\\C#\\Лаба-Новогодняя\\Game2.txt";
        private BindingList<Translator_Class> _translatorlist;
        private File_Service _service;
        private int mistakes;
        private string translatecheck;
        public Game2()
        {
            InitializeComponent();
        }
        public void UpdateText()
        {
            Word1.Text = _translatorlist[0].Word;
        }
        private void FileWriter()
        {
            string[] file_data = File.ReadAllLines(StatPath);
            using (StreamWriter writer = new StreamWriter(StatPath))
            {
                for (int i = 0; i<file_data.Length; i++)
                {
                    writer.WriteLine(file_data[i]);
                }
                writer.WriteLine("Попытка "+file_data.Length.ToString()+", Количество ошибок - "+mistakes.ToString());
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

            UpdateText();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            translatecheck=_translatorlist[0].Translation;
            _translatorlist.RemoveAt(0);
            
            if (Translate1.Text!=translatecheck)
            {
                mistakes+=1;
                Mistakes.Text=mistakes.ToString();
            }
            if (_translatorlist.Count==0)
            {
                MessageBox.Show("Слова кончились! Количество ошибок - " + mistakes.ToString());
                FileWriter();
                Close();
            }
            else
            {
                UpdateText();
            }
            
        }
    }
}
