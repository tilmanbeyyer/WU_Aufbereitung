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
    /// Interaktionslogik für VerarbeitungView.xaml
    /// </summary>
    public partial class VerarbeitungView : Page
    {
        Klasse klasse;
        string pfad;
        List<string> pfadeNachweise = new List<string>();
        Verarbeiter verarbeiter = new Verarbeiter();
        public VerarbeitungView(string path)
        {
            InitializeComponent();

            klasse = new Klasse(Klasse.GetSampleSchuelerListe(), "FS183", Klasse.GetSampleDatum());
            klasse = verarbeiter.importReport(path);
            


            this.lblMontag.Content += klasse.Woche[0];
            this.lblDienstag.Content += klasse.Woche[1];
            this.lblMittwoch.Content += klasse.Woche[2];
            this.lblDonnerstag.Content += klasse.Woche[3];
            this.lblFreitag.Content += klasse.Woche[4];
            this.schuelerListeGrid.ItemsSource = klasse.GetListViewSchueler();
            this.schuelerListeGrid.AllowDrop = true;
        }

        internal Verarbeiter Verarbeiter { get => verarbeiter; set => verarbeiter = value; }
        internal Klasse Klasse { get => klasse; set => klasse = value; }

        private void btnAuswertungExportierenClick(object sender, RoutedEventArgs e)
        {
            ExportEinstellungenView exportEinstellungenView = new ExportEinstellungenView();
            exportEinstellungenView.Verarbeiter = verarbeiter;
            this.NavigationService.Navigate(exportEinstellungenView);
        }
        private void dropElementOnGrid(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in fileList)
            {
                pfadeNachweise.Add(file);
            }

            Point test = e.GetPosition(this.schuelerListeGrid);


            Console.WriteLine(e.Data);
        }

        private void btnAbbrechenClick(object sender, RoutedEventArgs e)
        {
            ImportView importView = new ImportView();
            this.NavigationService.GoBack();
        }
    }
}
