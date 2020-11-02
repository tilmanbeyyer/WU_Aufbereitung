using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WU_Aufbereitung.models
{
    class Verarbeiter
    {
        private Schueler[] schuelerListe;

        public Verarbeiter(Schueler[] schuelerListe)
        {
            this.schuelerListe = schuelerListe;
        }

        public void erstelleExport(String pfadExport)
        {

        }

        public void erstelleAuswertung()
        {

        }

        public void importReport(String pfadImport)
        {
            //CSV-Pfad
            var reader = new StreamReader(File.OpenRead(pfadImport));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            int[] zeiten = new int[5];

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                listA.Add(values[0]);
                listB.Add(values[1]);

                //
                foreach (var coloumn1 in listA)
                {
                    Console.WriteLine(coloumn1);
                }

                foreach (var coloumn2 in listA)
                {
                    Console.WriteLine(coloumn2);
                }
            }
        }

        public void pruefeReport()
        {

        }

        public void versendeMail(String adresse)
        {

        }

        #region Getter/Setter
        public Schueler[] SchuelerListe { get => schuelerListe; set => schuelerListe = value; }
        #endregion
    }
}

