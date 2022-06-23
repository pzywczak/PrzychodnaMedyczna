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
                if (hasloSprawdz())
                {
                    u = new Uzytkownicy()
                    {
                        Login = tLogin.Text,
                        Haslo = tHaslo.Text,
                    };
                    if (Uzytkownik.zapiszUzytkownika(u))
                    {
                        MessageBox.Show("Uzytkownik zarejestrowany!", "BLAD", MessageBoxButton.OK, MessageBoxImage.Information);
                        wyczyscPola();
                    }
                    else
                    {
                        MessageBox.Show("Uzytkownik nie zostal zarejestrowany!", "BLAD",MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Haslo nie pasuje!", "BLAD", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Podaj dane!", "BLAD", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void przyciskEdytuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void przyciskUsun_Click(object sender, RoutedEventArgs e)
        {

        }

        public bool hasloSprawdz()
        {
            if (tHaslo.Text == lpowtorzHaslo.Text)
            {
                return true;
            }
            return false;
        }

        public void wyczyscPola()
        {
            tLogin.Clear();
            tHaslo.Clear();
            lpowtorzHaslo.Clear();
            tLogin.Focus();
        }
    }
}
