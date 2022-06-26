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
    /// Logika interakcji dla klasy WszyscyPacjenci.xaml
    /// </summary>
    public partial class WszyscyPacjenci : Window
    {
        public List<Pacjenci> MoiPacjenci { get; set; }
        public WszyscyPacjenci()
        {
            InitializeComponent();
            MoiPacjenci = Pacient.listaPacjentow() ;
            DataContext = this;
            dataGrid.Items.Refresh();
        }
    }
}
