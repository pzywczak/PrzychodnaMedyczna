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
    /// Interaction logic for ListaLekarzy.xaml
    /// </summary>
    public partial class ListaLekarzy : Window
    {
        public List<Lekarze> MoiLekarze { get; set; }

        public ListaLekarzy()
        {
            InitializeComponent();
            MoiLekarze = Lekarz.filtrListaLekarzy(Program.Batatinha);
            DataContext = this;
            dataGrid.Items.Refresh();
        }
    }
}
