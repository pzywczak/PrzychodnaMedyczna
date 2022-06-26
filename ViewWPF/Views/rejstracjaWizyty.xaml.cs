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
using ViewWPF.baza;
using ViewWPF.Class;
namespace ViewWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy rejstracjaWizyty.xaml
    /// </summary>
    public partial class rejstracjaWizyty : Window
    {
        public rejstracjaWizyty()
        {
            InitializeComponent();
        }
        Wizyty u = new Wizyty();
        public void przyciskDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tData.Text) && !string.IsNullOrEmpty(tGodzina.Text) && godzinaFormat(tGodzina.Text))
            {
                u = new Wizyty()
                {
                    Data = tData.Text,
                    Godzina = tGodzina.Text,
                    TypWizyty = tTypWizyty.Text,
                };
                if (Wizyta.zapiszWizyte(u))
                {
                    MessageBox.Show("Wizyta zarejstrowana!", "OK",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    wyczyscPola();
                }
                else
                {
                    MessageBox.Show("Nie mozna zarejstrowac wizyty!", "BLAD",
                       MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Podaj poprawne dane!", "BLAD",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void przyciskEdytuj_Click(object sender, RoutedEventArgs e)
        {
            
        }
        public void przyciskUsun_Click(object sender, RoutedEventArgs e)
        {
            
        }
        public void wyczyscPola()
        {
            tGodzina.Clear();
            tTypWizyty.Clear();
        }

        public bool godzinaFormat(string input)
        {
            return TimeSpan.TryParse(input, out var dummyOutput);
        }
    }
}
