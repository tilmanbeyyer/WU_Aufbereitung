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
        List<Schueler> schuelerListe = Klasse.getSampleSchuelerListe();
        public Auswertung()
        {
            InitializeComponent();
            Klasse klasse = new Klasse(Klasse.getSampleSchuelerListe(), "FS183");
            this.schuelerListeGrid.ItemsSource = schuelerListe;
            this.montagLabel.Content = "Montag";
        }

        public string[] GetWeeks() {
            Schueler s = schuelerListe[0];
            
            return null;
        }

    }
}
