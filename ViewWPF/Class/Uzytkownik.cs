using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewWPF.baza;

namespace ViewWPF.Class
{
    class Uzytkownik
    {
        private static PrzychodniaLekarskaEntities2 ctx = Singel.Instance.Context;

        public static bool zapiszUzytkownika(Uzytkownicy uzytkownik)
        {
            if (szukajUzytkownikaPoLoginu(uzytkownik) == null)
            {
                try
                {
                    ctx.Uzytkownicies.Add(uzytkownik);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool zmienUzytkownika(Uzytkownicy uzytkownik)
        {
            try
            {
                ctx.Entry(uzytkownik).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static Uzytkownicy szukajUzytkownikaPoLoginu(Uzytkownicy uzytkownik)
        {
            return ctx.Uzytkownicies.FirstOrDefault(x => x.Login.Equals(uzytkownik.Login));
        }

        public static Uzytkownicy szukajUzytkownikaPoLoginu2(String login)
        {
            return ctx.Uzytkownicies.FirstOrDefault(x => x.Login.Equals(login));
        }

    }
}
