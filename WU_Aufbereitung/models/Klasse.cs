using System;
using System.Collections.Generic;
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

        public static List<Schueler> getSampleSchuelerListe() {
            List<Schueler> liste = new List<Schueler>();
            liste.Add(new Schueler("Hubach", "Jean-Pierre", new Fehlzeit[] { new Fehlzeit("02.11", 8, "entschuldigt") }));
            liste.Add(new Schueler("Beyer", "Tilman", new Fehlzeit[] { new Fehlzeit("03.11", 4, "entschuldigt") }));
            liste.Add(new Schueler("Schuck", "Christian", new Fehlzeit[] { new Fehlzeit("04.11", 8, "offen") }));
            liste.Add(new Schueler("Sperling", "Oliver", new Fehlzeit[] { new Fehlzeit("04.11", 3, "beurlaubt") }));
            liste.Add(new Schueler("Mucke", "Philipp", new Fehlzeit[] { new Fehlzeit("04.11", 2, "entschuldigt") }));

            return liste;
        }
        #endregion
    }
}
