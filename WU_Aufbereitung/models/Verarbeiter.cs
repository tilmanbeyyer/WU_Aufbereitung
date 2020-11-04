using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using IronXL;
using Range = IronXL.Range;


namespace WU_Aufbereitung.models
{
    class Verarbeiter
    {
        private Schueler[] schuelerListe;
        private int[,] fehlzeitenSummenListe;
        private string[] daten;

        public Verarbeiter()
        {
        }

        // public void erstelleExport(String importPfad,String pfadExport, String nameLehrer)
        public void erstelleExport(string importPfad, string exportPfad, string jahr, string lehrer)
        {
            WorkBook workbook = WorkBook.Load(importPfad);
            WorkSheet sheet = workbook.DefaultWorkSheet;

            sheet["G1"].Value = daten[0] + "." + jahr;
            sheet["C48"].Value = lehrer;
            //Datum der Fehltage
            sheet["D7"].Value = daten[0];
            sheet["F7"].Value = daten[1];
            sheet["H7"].Value = daten[2];
            sheet["J7"].Value = daten[3];
            sheet["L7"].Value = daten[4];

            for (int i = 9; i - 9 < schuelerListe.Length; i++)
            {

                sheet["A" + i].Value = i - 9;
                sheet["B" + i].Value = schuelerListe[i - 9].Nachname;
                sheet["C" + i].Value = schuelerListe[i - 9].Vorname;


                //Fehlzeiten
                for (int j = 0; j < schuelerListe[i - 9].Fehlzeit.Length; j++)
                {
                    if (schuelerListe[i - 9].Fehlzeit[j] != null)
                    {
                        switch (j)
                        {
                            case 0:
                                sheet["D" + i].Value = schuelerListe[i - 9].Fehlzeit[j].Stunden;
                                sheet["E" + i].Value = schuelerListe[i - 9].Fehlzeit[j].Status;
                                break;
                            case 1:
                                sheet["F" + i].Value = schuelerListe[i - 9].Fehlzeit[j].Stunden;
                                sheet["G" + i].Value = schuelerListe[i - 9].Fehlzeit[j].Status;
                                break;
                            case 2:
                                sheet["H" + i].Value = schuelerListe[i - 9].Fehlzeit[j].Stunden;
                                sheet["I" + i].Value = schuelerListe[i - 9].Fehlzeit[j].Status;
                                break;
                            case 3:
                                sheet["J" + i].Value = schuelerListe[i - 9].Fehlzeit[j].Stunden;
                                sheet["K" + i].Value = schuelerListe[i - 9].Fehlzeit[j].Status;
                                break;
                            case 4:
                                sheet["L" + i].Value = schuelerListe[i - 9].Fehlzeit[j].Stunden;
                                sheet["M" + i].Value = schuelerListe[i - 9].Fehlzeit[j].Status;
                                break;
                        }
                    }
                }
                //Summe
                //erstelleAuswertung();
                sheet["N" + i].Value = schuelerListe[i - 9].Verspaetet; //Verspätung
                sheet["O" + i].Value = schuelerListe[i - 9].Entschuldigt; //Entschuldigt
                sheet["P" + i].Value = schuelerListe[i - 9].Offen; //offen

            }

            // Arbeitsmappe speichern 
            workbook.SaveAs(exportPfad);
        }
        public Klasse importReport(String pfadImport)
        {
            //CSV-Pfad
            var reader = new StreamReader(File.OpenRead(pfadImport));
            List<string> listA = new List<string>();

            int[] zeiten = new int[5];
            int zeileCSV = 0;
            String[] tage = new String[5];
            String[] zeile;
            List<Schueler> schueler = new List<Schueler>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] != "")
                    {
                        listA.Add(values[i]);
                    }
                }

                if (zeileCSV == 0)
                {
                    tage = listA.ToArray();
                    daten = listA.ToArray();
                    listA.Clear();
                }
                else if (zeileCSV == 1)
                {
                    zeileCSV++;
                    listA.Clear();
                    continue;
                }
                else if (zeileCSV >= 2 && !(listA.Count == 0))
                {

                    //Zeile mit Inhalt 
                    zeile = listA.ToArray();

                    int tag = 0;
                    //Fehlzeiten 
                    Fehlzeit[] fehlzeiteSchueler = new Fehlzeit[] { null, null, null, null, null };
                    for (int i = 0; i < 10; i += 2)
                    {
                        if (Regex.IsMatch(values[i + 2], @"^\d+$"))
                        {
                            fehlzeiteSchueler[tag] = new Fehlzeit(tage[tag], Int32.Parse(values[i + 2]), values[i + 3]);
                        }
                        tag++;
                    }
                    //Summe der Fehlzeiten
                    int verspaetet = 0;
                    int offen = 0;
                    int entschuldigt = 0;
                    for (int i = 0; i < fehlzeiteSchueler.Length; i++)
                    {
                        if (fehlzeiteSchueler[i] != null)
                        {
                            if (fehlzeiteSchueler[i].Status.Equals("offen"))
                                //unendschuldigt
                                offen += fehlzeiteSchueler[i].Stunden;
                            else if (fehlzeiteSchueler[i].Status.Equals("verspätet"))
                                //Verspätet
                                verspaetet += fehlzeiteSchueler[i].Stunden;
                            else
                                //Entschuldigt
                                entschuldigt += fehlzeiteSchueler[i].Stunden;
                        }
                    }
                    //Schüler init
                    Schueler a = new Schueler(zeile[0], zeile[1], fehlzeiteSchueler, offen, entschuldigt, verspaetet);
                    schueler.Add(a);
                    zeileCSV++;
                    listA.Clear();
                }
                else
                {
                    break;
                }
                zeileCSV++;
            }
            SchuelerListe = schueler.ToArray();
            return new Klasse(schueler, "", tage);
        }

        public bool pruefeReport(string pfadImport)
        {
            //Reader Erste Zeile auf Length 5 
            var reader = new StreamReader(File.OpenRead(pfadImport));
            List<string> listA = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] != "")
                    {
                        listA.Add(values[i]);
                    }
                }
            }
            String[] pruefeLaenge = listA.ToArray();
            if (pruefeLaenge.Length == 5)
            {
                return true;
            }
            return false;
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

