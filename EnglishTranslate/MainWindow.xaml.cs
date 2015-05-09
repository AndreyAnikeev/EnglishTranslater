using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BL;
using Common;
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
        private string _state;

        private readonly IDataRecordAdapter _dataRecordAdapter;
        private readonly IShuffler _shuffler;
        
        public MainWindow( IDataRecordAdapter dataRecordAdapter, IShuffler shuffler )
        {
            _dataRecordAdapter = dataRecordAdapter;
            _shuffler = shuffler;
            InitializeComponent();
            InitializeComboBoxState();
            ComboBoxState.IsEnabled = false;
            ComboBoxTranslation.IsEnabled = false;
            ButtonCheck.IsEnabled = false;
            TextBoxWord.IsEnabled = false;
        }

        private void Open_File_Button_Click( object sender, RoutedEventArgs e )
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "*.csv";
            bool? isShown = openFileDialog.ShowDialog();

            if ( isShown != true )
                return;
            var path = openFileDialog.FileName;
            if ( path != null )
            {
                ComboBoxState.IsEnabled = true;

                _records = _dataRecordAdapter.GetShuffleRecordList( path );
                var shuffleRecords = _shuffler.ShuffleItems( _records );
                _englishWords = shuffleRecords.Select( item => item.EnglishWord ).ToList();
                _russianWords = shuffleRecords.Select( item => item.RussianWord ).ToList();
                TextBoxWord.Text = _englishWords.FirstOrDefault();
            }
            else
            {
                MessageBox.Show( "Can't get specified path!", "Error", MessageBoxButton.OK, MessageBoxImage.Error );
            }
        }

        private void ComboBoxState_SelectionChanged( object sender, System.Windows.Controls.SelectionChangedEventArgs e )
        {
            if ( _englishWords == null || _russianWords == null )
                return;
            _state = (string)ComboBoxState.SelectedValue;
            if ( _state == TranslationState.FromEnglishToRussian.ToString() )
            {
                TextBoxWord.Text = _englishWords.FirstOrDefault();
            }
            else if ( _state == TranslationState.FromRussianToEnglish.ToString() )
            {
                TextBoxWord.Text = _russianWords.FirstOrDefault();
            }
            else if (_state != null)
            {
                ComboBoxTranslation.IsEnabled = true;
                ButtonCheck.IsEnabled = true;
                TextBoxWord.IsEnabled = true;
            }
        }

        private void ComboBoxTranslation_KeyUp( object sender, KeyEventArgs e )
        {
            if ( _state == TranslationState.FromEnglishToRussian.ToString() )
            {
                var template = ComboBoxTranslation.Text;
                var wordSamples = _russianWords.Where( item => item.Contains( template ) ).ToList();
                ComboBoxTranslation.ItemsSource = wordSamples;
            }
            else if ( _state == TranslationState.FromRussianToEnglish.ToString() )
            {
                var template = ComboBoxTranslation.Text;
                var wordSamples = _englishWords.Where( item => item.Contains( template ) ).ToList();
                ComboBoxTranslation.ItemsSource = wordSamples;
            }
            ComboBoxTranslation.IsDropDownOpen = true;
        }

        private void Button_Check_Click( object sender, RoutedEventArgs e )
        {

        }

        private void InitializeComboBoxState()
        {
            ComboBoxState.ItemsSource = new List<string>
            {
                "Choose state",
                TranslationState.FromEnglishToRussian.ToString(),
                TranslationState.FromRussianToEnglish.ToString()
            };
        }

    }
}
