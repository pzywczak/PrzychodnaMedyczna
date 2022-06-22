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
    /// Interaction logic for rejstracjaLekarza.xaml
    /// </summary>
    public partial class rejstracjaLekarza : Window
    {
        public rejstracjaLekarza()
        {
            InitializeComponent();
        }

        Lekarze m = new Lekarze();

        private void przyciskDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCpf.Text))
            {
                m = new Lekarze()
                {
                    ImieINazwisko = txtNome.Text,
                    Adres = txtCpf.Text,
                    Specjalizacja = txtEspecialidade.Text,
                    USERID = Program.Batatinha
                };
                if (MedicoDAO.SalvarMedico(m))
                {
                    MessageBox.Show("Medico cadastrado com sucesso!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possível adicionar o Medico!", "SGCS WPF",
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
            przyciskSzukaj.IsEnabled = true;

            if (!string.IsNullOrEmpty(txtCpf.Text))
            {
                m = new Lekarze
                {
                    Adres = txtCpf.Text
                };
                m = MedicoDAO.BuscarMedicoPorCPF(m);
                if (m != null)
                {
                    txtNome.Text = m.ImieINazwisko;
                    txtCpf.Text = m.Adres;
                    txtEspecialidade.Text = m.Specjalizacja;
                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar o Medico!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtNome.Text))
                {
                    m = new Lekarze
                    {
                        ImieINazwisko = txtNome.Text
                    };
                    m = MedicoDAO.BuscarMedicoPorNome(m);
                    if (m != null)
                    {
                        txtNome.Text = m.ImieINazwisko;
                        txtCpf.Text = m.Adres;
                        txtEspecialidade.Text = m.Specjalizacja;
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher os campos", "SGCS WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void przyciskZmien_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCpf.Text))
            {
                m.ImieINazwisko = txtNome.Text;
                m.Adres = txtCpf.Text;
                m.Specjalizacja = txtEspecialidade.Text;

                if (MedicoDAO.AlterarMedico(m))
                {
                    MessageBox.Show("Paciente alterado com sucesso!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
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

        public void LimparCampos()
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtEspecialidade.Clear();
            txtNome.Focus();
        }
    }
}
