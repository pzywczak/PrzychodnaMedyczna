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
using ViewWPF.DAL;
using ViewWPF.baza;

namespace ViewWPF.Views
{
    /// <summary>
    /// Interaction logic for ListaPacjentow.xaml
    /// </summary>
    public partial class ListaPacjentow : Window
    {
        public List<Pacjenci> MeusPacientes { get; set; }

        public ListaPacjentow()
        {
            InitializeComponent();
            MeusPacientes = PacienteDAO.ListagemFiltradaDePacientes(Program.Batatinha);
            DataContext = this;
            dataGrid.Items.Refresh();
        }
    }
}
