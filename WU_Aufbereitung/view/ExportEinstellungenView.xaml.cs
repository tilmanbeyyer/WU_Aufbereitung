using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

        internal Verarbeiter Verarbeiter { get => verarbeiter; set => verarbeiter = value; }

        public ExportEinstellungenView()
        {
            InitializeComponent();
        }

        private void btnExportierenClick(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.InitialDirectory = @"C:\";      
            saveFileDialog1.Title = "Save text Files";
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "KW" + this.txtKW.Text + "_" + this.txtKlasse.Text  +"Fehlzeiten.xlsx";
            if (saveFileDialog1.ShowDialog() == true)
            {
                verarbeiter.erstelleExport(@"C:\Users\tilmanbeyer\source\repos\WU_Aufbereitung\WU_Aufbereitung\static\testExcel.xlsx", saveFileDialog1.FileName, this.txtJahr.Text, this.txtLehrkraft.Text);
            }
            
            //TODO Übersicht mit Lehrer, KW und Jahr

        }

        private void btnAbrechenClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
