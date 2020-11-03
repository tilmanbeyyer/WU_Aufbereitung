using System;
using System.Collections.Generic;
using System.Text;

namespace WU_Aufbereitung.models
{ 
    class Schueler
    {
        private string nachname;
        private string vorname;
        private Fehlzeit[] fehlzeit;

        public Schueler(string nachname, string vorname, Fehlzeit[] fehlzeit)
        {
            this.nachname = nachname;
            this.vorname = vorname;
            this.fehlzeit = new Fehlzeit[5];
        }

        #region Getter/Setter
        public string Nachname { get => nachname; set => nachname = value; }
        public string Vorname { get => vorname; set => vorname = value; }
        internal Fehlzeit[] Fehlzeit { get => fehlzeit; set => fehlzeit = value; }
        #endregion
    }
}
