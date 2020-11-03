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
        #endregion
    }
}
