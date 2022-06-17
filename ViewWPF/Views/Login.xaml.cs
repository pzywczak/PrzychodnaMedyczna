using System;
using System.Windows;
using System.Windows.Input;
using ViewWPF.DAL;
using ViewWPF.Models;

namespace ViewWPF.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        Usuario u = new Usuario();

        private void PrzyciskZaloguj_Click(object sender, RoutedEventArgs e)
        {
            u = new Usuario();
            u = UsuarioDAO.BuscarUsuarioPorLogin2(tLogin.Text);
            Program.Batatinha = u.Id;

            if (u != null && TestarSenha(u.Senha))
            {
                GlowneMenu pi = new GlowneMenu();
                pi.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login / Senha Incorretos!", "SGCS WPF",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool TestarSenha(String senha)
        {
            if (senha.Equals(tHaslo.Password.ToString()))
            {
                return true;
            }
            return false;
        }

        private void PrzyciskDodaj_Click(object sender, RoutedEventArgs e)
        {
            rejstracjaUzytkownika cu = new rejstracjaUzytkownika();
            cu.Show();
        }
    }

    }

