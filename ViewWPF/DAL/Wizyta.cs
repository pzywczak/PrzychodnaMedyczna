using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewWPF.baza;

namespace ViewWPF.DAL
{
    class Wizyta
    {
        private static PrzychodniaLekarskaEntities ctx = Singel.Instance.Context;

        public static bool zapiszWizyte(Wizyty wizyta)
        {

                try
                {
                    ctx.Wizyties.Add(wizyta);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            
        }
        public static bool zmienWizyte(Wizyty wizyta)
        {
            try
            {
                ctx.Entry(wizyta).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static Wizyty wyszukajWizytePoDacie(Wizyty wizyta)
        {
            return ctx.Wizyties.FirstOrDefault(x => x.Data.Equals(wizyta.Data));
        }

        public static List<Wizyty> listaWizyt()
        {
            return ctx.Wizyties.ToList();
        }
    }
}
