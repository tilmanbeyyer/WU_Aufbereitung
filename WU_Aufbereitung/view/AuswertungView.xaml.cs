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
        public Auswertung()
        {
            InitializeComponent();
            klasse = new Klasse(Klasse.GetSampleSchuelerListe(), "FS183", Klasse.GetSampleDatum());        
            this.schuelerListeGrid.ItemsSource = klasse.GetListViewSchueler();
            this.schuelerListeGrid.AllowDrop = true;
        }

        private void dropElementOnGrid(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            Console.WriteLine(e.Data);
        }
    }
}
