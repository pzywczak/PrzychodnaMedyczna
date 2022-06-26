using System;
using System.Windows;
using System.Windows.Input;
using ViewWPF.Class;
using ViewWPF.baza;

namespace ViewWPF.Views
{
    /// <summary>
    /// Logika dzialania Login.xaml
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
            u = Uzytkownik.szukajUzytkownikaPoLoginu2(tLogin.Text);
            Program.User = u.Id;

            if (u != null && hasloSprawdz(u.Haslo))
            {
                GlowneMenu pi = new GlowneMenu();
                pi.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nie prawidlowy Login/Haslo", "BLAD", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool hasloSprawdz(String haslo)
        {
            if (haslo.Equals(tHaslo.Password.ToString()))
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

