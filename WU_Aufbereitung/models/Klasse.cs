using System;
using System.Collections.Generic;
using System.Text;

namespace WU_Aufbereitung.models
{
    class Klasse
    {
        private List<Schueler> schuelerListe = new List<Schueler>();
        private string bezeichner;

        public Klasse(List<Schueler> schuelerListe, string bezeichner)
        {
            this.schuelerListe = schuelerListe;
            this.bezeichner = bezeichner;
        }

        #region Getter/Setter
        public string Bezeichner { get => bezeichner; set => bezeichner = value; }
        internal List<Schueler> SchuelerListe { get => schuelerListe; set => schuelerListe = value; }

        public static List<Schueler> getSampleSchuelerListe() {
            schuelerListe.Clear();
            schuelerListe.Add(new Schueler("Hubach", "Jean-Pierre", new Fehlzeit[] { new Fehlzeit("02.11", 8, "entschuldigt") }));
            schuelerListe.Add(new Schueler("Beyer", "Tilman", new Fehlzeit[] { new Fehlzeit("03.11", 4, "entschuldigt") }));
            schuelerListe.Add(new Schueler("Schuck", "Christian", new Fehlzeit[] { new Fehlzeit("04.11", 8, "offen") }));
            schuelerListe.Add(new Schueler("Sperling", "Oliver", new Fehlzeit[] { new Fehlzeit("04.11", 3, "beurlaubt") }));
            schuelerListe.Add(new Schueler("Mucke", "Philipp", new Fehlzeit[] { new Fehlzeit("04.11", 2, "entschuldigt") }));

            return schuelerListe;
        }
        #endregion
    }
}
