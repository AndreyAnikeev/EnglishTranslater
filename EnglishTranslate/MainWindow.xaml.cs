using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BL;
using Microsoft.Win32;

namespace EnglishTranslate
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<RecordEntity> _records;
        private List<string> _englishWords;
        private List<string> _russianWords;

        private readonly IDataRecordAdapter _dataRecordAdapter;

        public MainWindow(IDataRecordAdapter dataRecordAdapter)
        {
            _dataRecordAdapter = dataRecordAdapter;
            InitializeComponent();
            InitializeComboBoxState();

        }

        private void Open_File_Button_Click( object sender, RoutedEventArgs e )
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "*.csv";
            bool? isShown = openFileDialog.ShowDialog();

            if (isShown != true) return;
            var path = openFileDialog.FileName;
            if (path != null)
            {
                _records = _dataRecordAdapter.GetShuffleRecordList( path );
                _englishWords = _records.Select(item => item.EnglishWord).ToList();
                _russianWords = _records.Select(item => item.RussianWord).ToList();
            }
            else
            {
                MessageBox.Show("Can't get specified path!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Check_Click( object sender, RoutedEventArgs e )
        {

        }

        private void InitializeComboBoxState()
        {
            ComboBoxState.ItemsSource = new List<string>
            {
                "Choose state",
                Constants.EnglishState,
                Constants.RussianState
            };    
        }

        private void ComboBoxTranslation_KeyUp( object sender, KeyEventArgs e )
        {
            var test = ComboBoxTranslation.Text;
        }
    }
}
