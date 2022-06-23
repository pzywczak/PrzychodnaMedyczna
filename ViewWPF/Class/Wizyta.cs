using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewWPF.baza;

namespace ViewWPF.Class
{
    class Wizyta
    {
        private static PrzychodniaLekarskaEntities1 ctx = Singel.Instance.Context;

        public static bool zapiszWizyte(Wizyty pacjent)
        {

           try
           {
               ctx.Wizyties.Add(pacjent);
               ctx.SaveChanges();
                 return true;
           }
           catch (Exception)
           {
                return false;
           }
            
        }

        public static bool zmienWizyte(Wizyty pacjent)
        {
            try
            {
                ctx.Entry(pacjent).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static Wizyty wyszukajPacjentaPoAdresie(Wizyty paciente)
        {
            return ctx.Wizyties.FirstOrDefault(x => x.Godzina.Equals(paciente.Godzina));
        }

        public static List<Wizyty> listaPacjentow()
        {
            return ctx.Wizyties.ToList();
        }


    }
}
