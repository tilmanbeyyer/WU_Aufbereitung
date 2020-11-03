using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WU_Aufbereitung.models
{
    class Verarbeiter
    {
        private Schueler[] schuelerListe;

        public Verarbeiter()
        {
            
        }

        public void erstelleExport(String pfadExport)
        {

        }

        public void erstelleAuswertung()
        {
            //Summe der Fehlstunden
            int[][] summeFehlstunden = new int[schuelerListe.Length][4];

            //Variablen für unterschiedliche Fehlzeiten?
            int entschuldigt = 0;
            int unentschuldigt = 0;
            int verspätet = 0;
            int zeilenZaehler = 0;

            for (int i = 0; i <= summeFehlstunden.Length; i++)
            {
                entschuldigt = 0;
                verspätet = 0;
                unentschuldigt = 0;

                for (int j = 0; j <= schuelerListe[i].Fehlzeit.Length; j++)
                {
                    if(schuelerListe[i].Fehlzeit[j].Status.Equals("offen"))
                        unentschuldigt += schuelerListe[i].Fehlzeit[j].Stunden;
                    else if(schuelerListe[i].Fehlzeit[j].Status.Equals("verspätet"))
                        verspätet += schuelerListe[i].Fehlzeit[j].Stunden;
                    else
                        entschuldigt += schuelerListe[i].Fehlzeit[j].Stunden;
                }
                summeFehlstunden[i][zeilenZaehler] = help;
            }



        }

        public Klasse importReport(String pfadImport)
        {
            //CSV-Pfad
            var reader = new StreamReader(File.OpenRead(pfadImport));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            int[] zeiten = new int[5];
            int hilfe = 0;
            String[] tage = new String[5];
            String[] zeile;
            List<Schueler> schueler = new List<Schueler>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                listA.Add(values[0]);
                listB.Add(values[1]);

                if (hilfe == 0)
                {
                  tage = listA.ToArray();
                }
                if (hilfe > 1 && !listA.Contains("Legende"))
                {
                    
                    //Zeile mit Inhalt 
                    zeile = listA.ToArray();

                    //Fehlzeiten 
                    Fehlzeit[] fehlzeiteSchueler = new Fehlzeit[5];
                    for (int i = 0; i <= fehlzeiteSchueler.Length; i++)
                    {
                        fehlzeiteSchueler[i] = new Fehlzeit(tage[i], Int32.Parse(zeile[i + 3]), zeile[i + 4]);
                    }
                    //Schüler init
                    Schueler a = new Schueler(zeile[0], zeile[1], fehlzeiteSchueler);
                    schueler.Add(a);
                    hilfe++;

                }
                else
                {
                    break;
                }
            }
            SchuelerListe = schueler.ToArray();
            return new Klasse(schueler, "leer");
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

