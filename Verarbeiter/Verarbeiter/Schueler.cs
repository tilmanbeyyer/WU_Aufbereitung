using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Verarbeiter
{
    class Schueler
    {
        private string nachname;
        private string vorname;
        private string klasse;
        private Fehlzeit[] fehlzeit;

        public Schueler(string nachname, string vorname, string klasse, Fehlzeit[] fehlzeit)
        {
            this.nachname = nachname;
            this.vorname = vorname;
            this.klasse = klasse;
            this.fehlzeit = new Fehlzeit[5];
        }

        #region Getter/Setter
        public string Nachname { get => nachname; set => nachname = value; }
        public string Vorname { get => vorname; set => vorname = value; }
        public string Klasse { get => klasse; set => klasse = value; }
        internal Fehlzeit[] Fehlzeit { get => fehlzeit; set => fehlzeit = value; }
        #endregion
    }
}
