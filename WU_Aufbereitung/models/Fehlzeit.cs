using System;
using System.Collections.Generic;
using System.Text;

namespace WU_Aufbereitung.models
{
    class Fehlzeit
    {
        private DateTime date;
        private int stunden;
        private string status;

        public Fehlzeit(DateTime date, int stunden, string status)
        {
            this.date = date;
            this.stunden = stunden;
            this.status = status;

        }

        public DateTime Date { get => date; set => date = value; }
        public int Stunden { get => stunden; set => stunden = value; }
        public string Status { get => status; set => status = value; }
    }
}
