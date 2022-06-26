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

using System.Windows.Forms;
using System.Data.SqlClient;


namespace ViewWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ListaWizyt.xaml
    /// </summary>
    public partial class ListaWizyt : Window
    {
        Wizyta dbclass = new Wizyta();
        
 
        public List<Wizyty> MoiWizyty { get; set; }
        public ListaWizyt()
        {
            InitializeComponent();
            MoiWizyty = Wizyta.listaWizyt();
            DataContext = this;
            dataGrid.Items.Refresh();
        }

        private void usunWizyte_Click(object sender, RoutedEventArgs e)
        {
            foreach (Wizyty wizytaview in dataGrid.SelectedItems)
            {
                Wizyty wizyta = new Wizyty();
                wizyta.Id = wizytaview.Id;
                dbclass.UsunWiersz(wizyta);
                
            }
            Close();
            ListaWizyt nowa = new ListaWizyt();
            nowa.Show();
        }



    }
}
