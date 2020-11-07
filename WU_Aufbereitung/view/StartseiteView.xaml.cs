using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WU_Aufbereitung.models;

namespace WU_Aufbereitung.view
{
    /// <summary>
    /// Interaktionslogik für StartseiteView.xaml
    /// </summary>
    public partial class StartseiteView : Window
    {
        Verarbeiter verarbeiter = new Verarbeiter();
        //MainWindow mw = new MainWindow();
        public StartseiteView()
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

            Klasse klasse = verarbeiter.importReport(filename);


            Auswertung av = new Auswertung(filename);
            av.DataContext = klasse;
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
