using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WU_Aufbereitung.models
{
    class Klasse
    {
        private List<Schueler> schuelerListe = new List<Schueler>();
        private string bezeichner;
        private string[] woche;

        public Klasse(List<Schueler> schuelerListe, string bezeichner, string[] woche)
        {
            this.schuelerListe = schuelerListe;
            this.bezeichner = bezeichner;
            this.woche = woche;
        }

        #region Getter/Setter
        public string Bezeichner { get => bezeichner; set => bezeichner = value; }
        public string[] Woche { get => woche; set => woche = value; }
        internal List<Schueler> SchuelerListe { get => schuelerListe; set => schuelerListe = value; }

        public ObservableCollection<ViewSchueler> GetListViewSchueler()
        {
            ObservableCollection<ViewSchueler> collection = new ObservableCollection<ViewSchueler>();
            List<ViewSchueler> list = new List<ViewSchueler>();
            foreach (Schueler s in schuelerListe)
            {
                list.Add(new ViewSchueler(s));
                collection.Add(new ViewSchueler(s));
            }
            return collection;
        } 

        public static List<Schueler> GetSampleSchuelerListe() {
            List<Schueler> liste = new List<Schueler>();
            liste.Add(new Schueler("Hubach", "Jean-Pierre", new Fehlzeit[] { new Fehlzeit("02.11", 8, "entschuldigt"), new Fehlzeit("02.11", 8, "entschuldigt"), new Fehlzeit("02.11", 8, "entschuldigt"), new Fehlzeit("02.11", 8, "entschuldigt"), new Fehlzeit("02.11", 8, "entschuldigt"), new Fehlzeit("02.11", 8, "entschuldigt") }, 0, 0, 0));
            liste.Add(new Schueler("Beyer", "Tilman", new Fehlzeit[] { new Fehlzeit("03.11", 4, "entschuldigt"), null, null, null, null },0,0,0));
            liste.Add(new Schueler("Schuck", "Christian", new Fehlzeit[] { new Fehlzeit("04.11", 8, "offen"), null, null, null, null }, 0, 0, 0));
            liste.Add(new Schueler("Sperling", "Oliver", new Fehlzeit[] { new Fehlzeit("04.11", 3, "beurlaubt"), null, null, null, null }, 0, 0, 0));
            liste.Add(new Schueler("Mucke", "Philipp", new Fehlzeit[] { new Fehlzeit("04.11", 2, "entschuldigt"), null, null, null, null }, 0, 0, 0));

            return liste;
        }

        public static string[] GetSampleDatum() { 
            return new string[]{"01.11", "02.11", "03.11", "04.11", "05.11" };
        }
        #endregion
    }
}
