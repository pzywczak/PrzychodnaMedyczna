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
using ViewWPF.baza;
using ViewWPF.Class;

namespace ViewWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy WszyscyLekarze.xaml
    /// </summary>
    public partial class WszyscyLekarze : Window
    {
        public List<Lekarze> MoiLekarze { get; set; }
        public WszyscyLekarze()
        {
            InitializeComponent();
            MoiLekarze = Lekarz.listaLekarzy();
            DataContext = this;
            dataGrid.Items.Refresh();
        }
    }
}
