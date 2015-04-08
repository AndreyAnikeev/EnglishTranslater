using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.Win32;

namespace EnglishTranslate
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBoxState();
            LeftListBox.Items.Add("test1"); 
            LeftListBox.Items.Add("test1"); 
            LeftListBox.Items.Add("test1"); 

        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "*.csv";
            bool? isShown = openFileDialog.ShowDialog();

            if (isShown == true)
            {
                var path = openFileDialog.FileNames;
            }
        }

        private void Button_Click_1( object sender, RoutedEventArgs e )
        {
            var test = LeftListBox.SelectedItem;
//            LeftListBox.Ite
            LeftListBox.Items.RemoveAt(1);

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
    }
}
