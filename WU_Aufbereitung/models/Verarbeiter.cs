using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop;
using Excel=Microsoft.Office.Interop.Excel;


namespace WU_Aufbereitung.models
{
    class Verarbeiter
    {
        private Schueler[] schuelerListe;
        private int[,] fehlzeitenSummenListe;

        public Verarbeiter()
        {
            
        }

        public void erstelleExport(String pfadExport, String nameLehrer)
        {
            string importPfad = "";
            Excel.Application excel = new Excel.ApplicationClass();
            excel.Visible = true;

            Excel.Workbook workbook = excel.Workbooks.Open(importPfad);

            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets["Auswertung"];
            try
            {
                for (int i = 9; i <= schuelerListe.Length; i++)
                {
                    //Index, Name, Vorname
                    worksheet.Cells[i, 0] = i - 9;
                    worksheet.Cells[i, 1] = schuelerListe[i].Nachname;
                    worksheet.Cells[i, 2] = schuelerListe[i].Vorname;

                    //Fehlzeiten
                    for (int j = 0; j <= schuelerListe[i].Fehlzeit.Length; j++)
                    {
                        worksheet.Cells[i, j + 3] = schuelerListe[i].Fehlzeit[j].Stunden;
                        worksheet.Cells[i, j + 4] = schuelerListe[i].Fehlzeit[j].Status;
                    }
                    //Summe
                    worksheet.Cells[i, 2] = schuelerListe[i].Vorname;
                    for (int j = 14; j <= 16; j++)
                    {
                        worksheet.Cells[i, j] = fehlzeitenSummenListe[i, j - 14];
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Es gab ein Problem bei der Beschreibung von Excel");
            }

            // Arbeitsmappe speichern 
            workbook.Save();

            // Excel beenden
            excel.Quit();
        }

        public void erstelleAuswertung()
        {
            //Summe der Fehlstunden
            int[,] summeFehlstunden = new int[schuelerListe.Length,4];

            for (int i = 0; i <= schuelerListe.Length; i++)
            {
                for (int j = 0; j <= schuelerListe[i].Fehlzeit.Length; j++)
                {
                    if(schuelerListe[i].Fehlzeit[j].Status.Equals("offen"))
                        //unendschuldigt
                        summeFehlstunden[i,1] += schuelerListe[i].Fehlzeit[j].Stunden;
                    else if(schuelerListe[i].Fehlzeit[j].Status.Equals("verspätet"))
                        //Verspätet
                        summeFehlstunden[i,2] += schuelerListe[i].Fehlzeit[j].Stunden;
                    else
                        //Entschuldigt
                        summeFehlstunden[i,3] += schuelerListe[i].Fehlzeit[j].Stunden;
                }             
            }
            this.fehlzeitenSummenListe = summeFehlstunden;
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
        public int[,] FehlzeitenSummenListe { get => fehlzeitenSummenListe; set => fehlzeitenSummenListe = value; }
        #endregion
    }
}

