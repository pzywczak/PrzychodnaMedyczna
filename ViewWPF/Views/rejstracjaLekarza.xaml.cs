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
            if (!string.IsNullOrEmpty(tImieINazwisko.Text) && !string.IsNullOrEmpty(tAdres.Text))
            {
                m = new Lekarze()
                {
                    ImieINazwisko = tImieINazwisko.Text,
                    Adres = tAdres.Text,
                    Specjalizacja = txtEspecialidade.Text,
                    USERID = Program.User
                };
                if (Lekarz.zapiszLekarza(m))
                {
                    MessageBox.Show("Lekarz zarejestrowany!", "OK",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    wyczyscPola();
                }
                else
                {
                    MessageBox.Show("Nie mozna zarejstrowac lekarza!", "BLAD",
                       MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Podaj dane", "BLAD",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void przyciskSzukaj_Click(object sender, RoutedEventArgs e)
        {
            przyciskDodaj.IsEnabled = false;
            przyciskSzukaj.IsEnabled = true;

            if (!string.IsNullOrEmpty(tAdres.Text))
            {
                m = new Lekarze
                {
                    Adres = tAdres.Text
                };
                m = Lekarz.wyszukajLekarzaPoAdresie(m);
                if (m != null)
                {
                    tImieINazwisko.Text = m.ImieINazwisko;
                    tAdres.Text = m.Adres;
                    txtEspecialidade.Text = m.Specjalizacja;
                }
                else
                {
                    MessageBox.Show("Nie mozna znalezc lekarza", "BLAD",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(tImieINazwisko.Text))
                {
                    m = new Lekarze
                    {
                        ImieINazwisko = tImieINazwisko.Text
                    };
                    m = Lekarz.wyszukajLekarzaPoImieniuINaziwsku(m);
                    if (m != null)
                    {
                        tImieINazwisko.Text = m.ImieINazwisko;
                        tAdres.Text = m.Adres;
                        txtEspecialidade.Text = m.Specjalizacja;
                    }
                }
                else
                {
                    MessageBox.Show("Podaj dane!", "BLAD",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void przyciskZmien_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tImieINazwisko.Text) && !string.IsNullOrEmpty(tAdres.Text))
            {
                m.ImieINazwisko = tImieINazwisko.Text;
                m.Adres = tAdres.Text;
                m.Specjalizacja = txtEspecialidade.Text;

                if (Lekarz.zmienPacjenta(m))
                {
                    MessageBox.Show("Pomyslnie zmieniono lekarza!", "OK",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    wyczyscPola();
                }
                else
                {
                    MessageBox.Show("Nie mozna zmienic lekarza", "BLAD",
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
            txtEspecialidade.Clear();
            tImieINazwisko.Focus();
        }
    }
}
