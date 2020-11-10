using System;
using System.Collections.Generic;
using System.Text;

namespace WU_Aufbereitung.models
{
    public class Fehlzeit
    {
        private string date;
        private int stunden;
        private string status;

        public Fehlzeit(string date, int stunden, string status)
        {
            this.date = date;
            this.stunden = stunden;
            this.status = status;

        }

        public string Date { get => date; set => date = value; }
        public int Stunden { get => stunden; set => stunden = value; }
        public string Status { get => status; set => status = value; }
    }
}
