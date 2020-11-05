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
    /// Interaktionslogik für Auswertung.xaml
    /// </summary>
    public partial class Auswertung : Window
    {
        Klasse klasse;
        List<string> pfadeNachweise = new List<string>();
        Verarbeiter verarbeiter = new Verarbeiter();
        public Auswertung(string path)
        {
            InitializeComponent();
            klasse = new Klasse(Klasse.GetSampleSchuelerListe(), "FS183", Klasse.GetSampleDatum());
            klasse = verarbeiter.importReport(path);


            
            this.schuelerListeGrid.ItemsSource = klasse.GetListViewSchueler();
            this.schuelerListeGrid.AllowDrop = true;
        }

        internal Klasse Klasse { get => klasse; set => klasse = value; }

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
    }
}
