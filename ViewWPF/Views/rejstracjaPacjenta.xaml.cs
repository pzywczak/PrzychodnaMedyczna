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
    /// Interaction logic for rejstracjaPacjenta.xaml
    /// </summary>
    public partial class rejstracjaPacjenta : Window
    {
        public rejstracjaPacjenta()
        {
            InitializeComponent();
        }

        Pacjenci p = new Pacjenci();

        private void przyciskDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCpf.Text))
            {
                p = new Pacjenci
                {
                    ImieINazwisko = txtNome.Text,
                    Adres = txtCpf.Text,
                    Telefon = txtTelefone.Text,
                    USERID = Program.Batatinha
                };
                if (PacienteDAO.SalvarPaciente(p))
                {
                    MessageBox.Show("Paciente cadastrado com sucesso!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    wyczyscPola();
                }
                else
                {
                    MessageBox.Show("Não foi possível adicionar o Paciente!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "SGCS WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void przyciskSzukaj_Click(object sender, RoutedEventArgs e)
        {
            przyciskDodaj.IsEnabled = false;
            przyciskZmien.IsEnabled = true;

            if (!string.IsNullOrEmpty(txtCpf.Text))
            {
                p = new Pacjenci
                {
                    Adres = txtCpf.Text
                };
                p = PacienteDAO.BuscarPacientePorCPF(p);
                if (p != null)
                {
                    txtNome.Text = p.ImieINazwisko;
                    txtCpf.Text = p.Adres;
                    txtTelefone.Text = p.Telefon;
                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar o Paciente!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "SGCS WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void przyciskZmien_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCpf.Text))
            {
                p.ImieINazwisko = txtNome.Text;
                p.Adres = txtCpf.Text;
                if (PacienteDAO.AlterarPaciente(p))
                {
                    MessageBox.Show("Paciente alterado com sucesso!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    wyczyscPola();
                }
                else
                {
                    MessageBox.Show("Não foi possível alterar o Paciente!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "SGCS WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void wyczyscPola()
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtNome.Focus();
        }



    }
}
