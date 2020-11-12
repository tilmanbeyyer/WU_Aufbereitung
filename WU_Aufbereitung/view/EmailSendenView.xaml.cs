using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaktionslogik für EmailSendenView.xaml
    /// </summary>
    public partial class EmailSendenView : Page
    {
        Verarbeiter verarbeiter = new Verarbeiter();
        string[] pfade = new string[0];
        string lehrer = "";
        string klasse = "";
        private string kw = "";

        public EmailSendenView()
        {
            InitializeComponent();
        }

        public string[] Pfade { get => pfade; set => pfade = value; }
        public Verarbeiter Verarbeiter { get => verarbeiter; set => verarbeiter = value; }
        public string Lehrer { get => lehrer; set => lehrer = value; }
        public string Klasse { get => klasse; set => klasse = value; }
        public string Kw { get => kw; set => kw = value; }

        private void btnZurueckClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnSendenClick(object sender, RoutedEventArgs e)
        {

            //if (!Regex.IsMatch(@"^[a-z0-9|ä|ü|ö|\-|\.|_]+@[a-z0-9|ä|ü|ö|\-|\.|_]+\.[a-z]{2,4}$", this.txtEmail.Text))
            //{
            //    MessageBox.Show("Bitte geben Sie eine gültige E-Mail ein!");
            //}

            if (!Verarbeiter.versendeMail(this.txtLogin.Text.ToString(), this.txtEmail.Text.ToString(), this.Pfade.ToList<String>(), this.txtPassword.Password.ToString(), this.lehrer,this.kw,this.klasse))
            {
                MessageBox.Show( "Leider ist beim Versenden der E-Mail ein Fehler aufgetreten. Bitte prüfen Sie Ihre Eingabedaten und versuchen Sie es erneut.");
                
            }
            else
            {
                MessageBox.Show("E-Mail wurde versandt!");
                
            }
            
        }
    }
}
