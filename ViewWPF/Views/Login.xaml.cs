using System;
using System.Windows;
using System.Windows.Input;
using ViewWPF.DAL;
using ViewWPF.baza;

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

        Uzytkownicy u = new Uzytkownicy();

        private void PrzyciskZaloguj_Click(object sender, RoutedEventArgs e)
        {
            u = new Uzytkownicy();
            u = UsuarioDAO.BuscarUsuarioPorLogin2(tLogin.Text);
            Program.Batatinha = u.Id;

            if (u != null && hasloSprawdz(u.Haslo))
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

        private bool hasloSprawdz(String senha)
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

