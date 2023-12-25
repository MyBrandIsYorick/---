using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using TranslatorDLL;
using System.Diagnostics;
using FileService;

namespace Лаба_Новогодняя.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window1 window;
        Game2 window2;
        private readonly string PATH = $"{Environment.CurrentDirectory}\\Translate_Lib.json";
        private readonly string StatPath1 = "C:\\Users\\denep\\OneDrive\\Desktop\\Важное\\Домашка_ПТУ\\C#\\Лаба-Новогодняя\\Game1.txt";
        private readonly string StatPath2 = "C:\\Users\\denep\\OneDrive\\Desktop\\Важное\\Домашка_ПТУ\\C#\\Лаба-Новогодняя\\Game2.txt";
        private BindingList<Translator_Class> _translatorlist;
        private File_Service _service;
        public MainWindow()
        {
            InitializeComponent();
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
            var style = new Style(typeof(DataGridColumnHeader));
            style.Setters.Add(new Setter(HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
            datagrid1.Columns[1].HeaderStyle = style;
            datagrid1.Columns[0].HeaderStyle = style;
            datagrid1.ItemsSource = _translatorlist;
            _translatorlist.ListChanged +=_translatorlist_ListChanged;
        }

        private void _translatorlist_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType==ListChangedType.ItemAdded||e.ListChangedType==ListChangedType.ItemDeleted||e.ListChangedType==ListChangedType.ItemChanged)
            {
                try
                {
                    _service.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void Game1_Click(object sender, RoutedEventArgs e)
        {
            if (window==null)
            {
                window=new Window1();
                window.Show();
            }
            else
            {
                window.Activate();
            }
        }

        private void Game2_Click(object sender, RoutedEventArgs e)
        {
            if (window2==null)
            {
                window2=new Game2();
                window2.Show();
            }
            else
            {
                window2.Activate();
            }
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(StatPath1) { UseShellExecute = true });
            Process.Start(new ProcessStartInfo(StatPath2) { UseShellExecute = true });
        }
    }
}