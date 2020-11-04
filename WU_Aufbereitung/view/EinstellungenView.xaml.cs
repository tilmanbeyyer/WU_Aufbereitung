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
using System.Windows.Shapes;

namespace WU_Aufbereitung.view
{
    /// <summary>
    /// Interaktionslogik für EinstellungenView.xaml
    /// </summary>
    public partial class EinstellungenView : Window
    {
        public EinstellungenView()
        {
            InitializeComponent();
        }

        private void btnAbrechenClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSpeichernClick(object sender, RoutedEventArgs e)
        {
            //TODO Speichern to Prefferences
            this.Close();
        }
    }
}
