using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaktionslogik für EmailSendenView.xaml
    /// </summary>
    public partial class EmailSendenView : Page
    {
        Verarbeiter verarbeiter = new Verarbeiter();
        string[] pfade = new string[0];
        public EmailSendenView()
        {
            InitializeComponent();
        }

        public string[] Pfade { get => pfade; set => pfade = value; }
        public Verarbeiter Verarbeiter { get => verarbeiter; set => verarbeiter = value; }

        private void btnZurueckClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnSendenClick(object sender, RoutedEventArgs e)
        {
            this.lblFehler.Visibility = Visibility.Hidden;
            
            
            if (!Verarbeiter.versendeMail(this.txtLogin.Text, this.txtEmail.Text, this.Pfade.ToList<String>(), this.txtPassword.Password.ToString(), ""))
            {
                this.lblFehler.Content = "Leider ist beim Versenden der E-Mail ein Fehler aufgetreten. Bitte prüfen Sie Ihre Eingabedaten und verscuhen Sie es erneut.";
                this.lblFehler.Visibility = Visibility.Visible;
            }
            else
            {
                this.lblFehler.Content = "E-Mail erfolgreich versandt!";
                this.lblFehler.Visibility = Visibility.Hidden;
            }
            
        }
    }
}
