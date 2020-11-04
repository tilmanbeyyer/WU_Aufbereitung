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
        List<ViewSchueler> viewSchuelerListe;
        Klasse klasse;
        public Auswertung()
        {
            

            klasse = new Klasse(Klasse.GetSampleSchuelerListe(), "FS183", Klasse.GetSampleDatum());
            InitializeComponent();
            this.schuelerListeGrid.ItemsSource = klasse.GetListViewSchueler();
            this.montagLabel.Content = "Mo " + klasse.Woche[0];
            this.diensttagLabel.Content = "Di " + klasse.Woche[0];
            this.mittwochLabel.Content = "Mi " + klasse.Woche[0];
            this.donnerstagLabel.Content = "Do " + klasse.Woche[0];
            this.freitagLabel.Content = "Fr " + klasse.Woche[0];
            


            
        }

    }
}
