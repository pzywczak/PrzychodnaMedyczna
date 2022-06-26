using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewWPF.Class;
using ViewWPF.baza;

namespace ViewWPF.Views
{
    /// <summary>
    /// Logika dzialania ListaPacjentow.xaml
    /// </summary>
    public partial class ListaPacjentow : Window
    {
        public List<Pacjenci> MoiPacjenci { get; set; }
        Pacient dbclass = new Pacient();

        public ListaPacjentow()
        {
            InitializeComponent();
            MoiPacjenci = Pacient.filtrListaPacjentow(Program.User);
            DataContext = this;
            dataGrid.Items.Refresh();
        }

        private void usunPacjenta_Click(object sender, RoutedEventArgs e)
        {
            foreach (Pacjenci wizytaview in dataGrid.SelectedItems)
            {
                Pacjenci wizyta = new Pacjenci();
                wizyta.Id = wizytaview.Id;
                dbclass.UsunWiersz(wizyta);

            }
            Close();
            ListaPacjentow nowa = new ListaPacjentow();
            nowa.Show();
        }

        private void listaWszystkichPacjentow_Click(object sender, RoutedEventArgs e)
        {
            Close();
            WszyscyPacjenci nowa = new WszyscyPacjenci();
            nowa.Show();
        }
    }
}
