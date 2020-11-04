using System;
using System.Collections.Generic;
using System.Text;

namespace WU_Aufbereitung.models
{
    class ViewSchueler
    {
        string vorname = "";
        string nachname ="";
        int hMo = 0;
        string sMo = "";
        int hDi = 0;
        string sDi = "";
        int hMi = 0;
        string sMi = "";
        int hDo = 0;
        string sDo = "";
        int hFr = 0;
        string sFr = "";

        public ViewSchueler(Schueler s, int hMo, string sMo, int hDi, string sDi, int hMi, string sMi, int hDo, string sDo, int hFr, string sFr)
        {
            this.vorname = s.Vorname;
            this.nachname = s.Nachname;
            this.hMo = hMo;
            this.sMo = sMo;
            this.hDi = hDi;
            this.sDi = sDi;
            this.hMi = hMi;
            this.sMi = sMi;
            this.hDo = hDo;
            this.sDo = sDo;
            this.hFr = hFr;
            this.sFr = sFr;
        }

        ViewSchueler(Schueler s) {
            this.vorname = s.Vorname;
            this.nachname = s.Nachname;
        }

    }
}
