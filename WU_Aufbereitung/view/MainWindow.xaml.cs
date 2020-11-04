using Microsoft.Win32;
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

using WU_Aufbereitung.view;

namespace WU_Aufbereitung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDateiAuswaehlenClick(object sender, RoutedEventArgs e)
        {
            string filename = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".csv"; // Default file extension
            openFileDialog.Filter = "CSV documents (.csv)|*.csv"; // Filter files by extension
            if (openFileDialog.ShowDialog() == true)
            {
                filename = openFileDialog.FileName;
            }
            Console.WriteLine(filename);

            Auswertung av = new Auswertung();
            this.Content = av.Content;
        }

        private void btnEinstellungClick(object sender, RoutedEventArgs e)
        {
            //TODO Load File verarbeiter and Check whether file loaded successfully
            EinstellungenView eV = new EinstellungenView();
            eV.Show();
            

        }
    }
}
