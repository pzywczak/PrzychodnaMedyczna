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
    /// Interaction logic for CadastrodeUsuario.xaml
    /// </summary>
    public partial class rejstracjaUzytkownika: Window
    {
        public rejstracjaUzytkownika()
        {
            InitializeComponent();
        }

        Uzytkownicy u = new Uzytkownicy();

        private void przyciskDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tLogin.Text) && !string.IsNullOrEmpty(tHaslo.Text))
            {
                if (TestarSenha())
                {
                    u = new Uzytkownicy()
                    {
                        Login = tLogin.Text,
                        Haslo = tHaslo.Text,
                    };
                    if (UsuarioDAO.SalvarUsuario(u))
                    {
                        MessageBox.Show("Usuário cadastrado com sucesso!", "SGCS WPF",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível adicionar o Usuário!", "SGCS WPF",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("As Senhas não Coincidem!", "SGCS WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "SGCS WPF",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void przyciskEdytuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void przyciskUsun_Click(object sender, RoutedEventArgs e)
        {

        }

        public bool TestarSenha()
        {
            if (tHaslo.Text == lpowtorzHaslo.Text)
            {
                return true;
            }
            return false;
        }

        public void LimparCampos()
        {
            tLogin.Clear();
            tHaslo.Clear();
            lpowtorzHaslo.Clear();
            tLogin.Focus();
        }
    }
}
