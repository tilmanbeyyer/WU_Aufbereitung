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
        private int offen;
        private int verspaetet;
        private int entschuldigt;


        public Schueler(string nachname, string vorname, Fehlzeit[] fehlzeit, int offen, int entschuldigt, int verspaetet)
        {
            this.nachname = nachname;
            this.vorname = vorname;
            this.fehlzeit = fehlzeit;
            this.offen = offen;
            this.entschuldigt = entschuldigt;
            this.verspaetet = verspaetet;

        }

        public override string ToString()
        {
            return "Ich bin " + nachname + " , " + vorname;
        }

        #region Getter/Setter
        public string Nachname { get => nachname; set => nachname = value; }
        public string Vorname { get => vorname; set => vorname = value; }
        internal Fehlzeit[] Fehlzeit { get => fehlzeit; set => fehlzeit = value; }
        public int Offen { get => offen; set => offen = value; }
        public int Verspaetet { get => verspaetet; set => verspaetet = value; }
        public int Entschuldigt { get => entschuldigt; set => entschuldigt = value; }
        #endregion
    }
}
