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
using System.Text.RegularExpressions;

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
            Regex validatePhoneNumberRegex = new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");

            if (!string.IsNullOrEmpty(tImieINazwisko.Text) && !string.IsNullOrEmpty(tAdres.Text) && validatePhoneNumberRegex.IsMatch(tTelefon.Text) )
            {
                p = new Pacjenci
                {
                    ImieINazwisko = tImieINazwisko.Text,
                    Adres = tAdres.Text,
                    Telefon = tTelefon.Text,
                    USERID = Program.User
                };
                if (Pacient.zapiszPacjenta(p))
                {
                    MessageBox.Show("Pacjent zarejestrowany!", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                    wyczyscPola();
                }
                else
                {
                    MessageBox.Show("Nie mozna zarejstrowac pacjenta!", "BLAD", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Podaj poprawne dane!", "BLAD",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void przyciskSzukaj_Click(object sender, RoutedEventArgs e)
        {
            przyciskDodaj.IsEnabled = false;
            przyciskZmien.IsEnabled = true;

            if (!string.IsNullOrEmpty(tAdres.Text))
            {
                p = new Pacjenci
                {
                    Adres = tAdres.Text
                };
                p = Pacient.wyszukajPacjentaPoAdresie(p);
                if (p != null)
                {
                    tImieINazwisko.Text = p.ImieINazwisko;
                    tAdres.Text = p.Adres;
                    tTelefon.Text = p.Telefon;
                }
                else
                {
                    MessageBox.Show("Nie mozna znalezc pacjenta! ", "BLAD", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Podaj dane!", "BLAD", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void przyciskZmien_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tImieINazwisko.Text) && !string.IsNullOrEmpty(tAdres.Text))
            {
                p.ImieINazwisko = tImieINazwisko.Text;
                p.Adres = tAdres.Text;
                if (Pacient.zmienPacjenta(p))
                {
                    MessageBox.Show("Pomyslnie zmieniono pacjenta!", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                    wyczyscPola();
                }
                else
                {
                    MessageBox.Show("Nie mozna zmienic pacjenta", "BLAD",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Podaj dane!", "BLAD", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void wyczyscPola()
        {
            tImieINazwisko.Clear();
            tAdres.Clear();
            tTelefon.Clear();
            tImieINazwisko.Focus();
        }


    }
}
