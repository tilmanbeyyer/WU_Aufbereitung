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
        int offen = 0;
        int verspaetet = 0;
        int entschuldigt = 0;

        public ViewSchueler(Schueler s)
        {
            this.vorname = s.Vorname;
            this.nachname = s.Nachname;

            if (s.Fehlzeit.Length >= 1)
            {
                if (s.Fehlzeit[0] != null)
                {
                    this.hMo = s.Fehlzeit[0].Stunden;
                    this.sMo = s.Fehlzeit[0].Status;
                } 
            }
            if (s.Fehlzeit.Length >= 2)
            {

                if (s.Fehlzeit[1] != null)
                {
                    this.hDi = s.Fehlzeit[1].Stunden;
                    this.sDi = s.Fehlzeit[1].Status;
                }
            }

            if (s.Fehlzeit.Length >= 3)
            {
                if (s.Fehlzeit[2] != null)
                {
                    this.hMi = s.Fehlzeit[2].Stunden;
                    this.sMi = s.Fehlzeit[2].Status;
                }
            }

            if (s.Fehlzeit.Length >= 4)
            {
                if (s.Fehlzeit[3] != null)
                {
                    this.hDo = s.Fehlzeit[3].Stunden;
                    this.sDo = s.Fehlzeit[3].Status;
                }
            }

            if (s.Fehlzeit.Length >= 5)
            {
                if (s.Fehlzeit[4] != null)
                {
                    this.hFr = s.Fehlzeit[4].Stunden;
                    this.sFr = s.Fehlzeit[4].Status;
                }
            }

            this.offen = s.Offen;
            this.entschuldigt = s.Entschuldigt;
            this.verspaetet = s.Verspaetet;
        }

        public string Vorname { get => vorname; set => vorname = value; }
        public string Nachname { get => nachname; set => nachname = value; }
        public int HMo { get => hMo; set => hMo = value; }
        public string SMo { get => sMo; set => sMo = value; }
        public int HDi { get => hDi; set => hDi = value; }
        public string SDi { get => sDi; set => sDi = value; }
        public int HMi { get => hMi; set => hMi = value; }
        public string SMi { get => sMi; set => sMi = value; }
        public int HDo { get => hDo; set => hDo = value; }
        public string SDo { get => sDo; set => sDo = value; }
        public int HFr { get => hFr; set => hFr = value; }
        public string SFr { get => sFr; set => sFr = value; }
        public int Offen { get => offen; set => offen = value; }
        public int Verspaetet { get => verspaetet; set => verspaetet = value; }
        public int Entschuldigt { get => entschuldigt; set => entschuldigt = value; }
    }
}
