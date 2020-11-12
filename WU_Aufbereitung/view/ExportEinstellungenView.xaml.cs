using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WU_Aufbereitung.models;

namespace WU_Aufbereitung.view
{
    /// <summary>
    /// Interaktionslogik für ExportEinstellungenView.xaml
    /// </summary>
    public partial class ExportEinstellungenView : Page
    {
        Verarbeiter verarbeiter = new Verarbeiter();
        string[] pfade = new string[0];

        internal Verarbeiter Verarbeiter { get => verarbeiter; set => verarbeiter = value; }
        public string[] Pfade { get => pfade; set => pfade = value; }

        public ExportEinstellungenView()
        {
            InitializeComponent();
        }

        private void btnExportierenClick(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.InitialDirectory = @"C:\";      
            //saveFileDialog1.Title = "Save text Files";
            //saveFileDialog1.CheckFileExists = true;
            //saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            //saveFileDialog1.FilterIndex = 2;
            //saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "KW" + this.txtKW.Text + "_" + this.txtKlasse.Text + "_" + "Fehlzeiten";
            if (saveFileDialog1.ShowDialog() == true)
            {

                
                //string p = @"C:\Users\tilmanbeyer\source\repos\WU_Aufbereitung\WU_Aufbereitung\static\testExcel.xlsx";
                string p = @"C:\Users\hubi\Source\Repos\WU_Aufbereitung\WU_Aufbereitung\static\testExcel.xlsx";


                verarbeiter.erstelleExport(p, saveFileDialog1.FileName, this.txtJahr.Text, this.txtLehrkraft.Text);
            }
            
            //TODO Übersicht mit Lehrer, KW und Jahr

        }

        private void btnAbrechenClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnEmailClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog1.FileName = "KW" + this.txtKW.Text + "_" + this.txtKlasse.Text + "_" + "Fehlzeiten";
            if (saveFileDialog1.ShowDialog() == true)
            {
                //string p = @"C:\Users\tilmanbeyer\source\repos\WU_Aufbereitung\WU_Aufbereitung\static\testExcel.xlsx";
                string p = @"C:\Users\hubi\Source\Repos\WU_Aufbereitung\WU_Aufbereitung\static\testExcel.xlsx";
                verarbeiter.erstelleExport(p, saveFileDialog1.FileName, this.txtJahr.Text, this.txtLehrkraft.Text);
                EmailSendenView emailSendenView = new EmailSendenView();
                List<string> paths = pfade.ToList<string>();
                paths.Add(saveFileDialog1.FileName);

                emailSendenView.Lehrer = this.txtLehrkraft.Text;
                emailSendenView.Kw = this.txtKW.Text;
                emailSendenView.Klasse = this.txtKlasse.Text;
                emailSendenView.Pfade = paths.ToArray<string>();
                emailSendenView.Verarbeiter = verarbeiter;
                this.NavigationService.Navigate(emailSendenView);
            }
            
            //this.NavigationService
        }
    }
}
