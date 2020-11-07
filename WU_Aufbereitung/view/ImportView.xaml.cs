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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WU_Aufbereitung.models;

namespace WU_Aufbereitung.view
{
    /// <summary>
    /// Interaktionslogik für ImportView.xaml
    /// </summary>
    public partial class ImportView : Page
    {
        Verarbeiter verarbeiter = new Verarbeiter();
        public ImportView()
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
                Klasse klasse = verarbeiter.importReport(filename);
                VerarbeitungView verarbeitungView = new VerarbeitungView(filename);
                this.NavigationService.Navigate(verarbeitungView);
            }
            Console.WriteLine(filename);

            
        }

        private void btnEinstellungClick(object sender, RoutedEventArgs e)
        {
            EinstellungenView eV = new EinstellungenView();
            eV.Show();
        }
    }
}
