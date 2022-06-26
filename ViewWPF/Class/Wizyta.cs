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
        private static PrzychodniaLekarskaEntities3 ctx = Singel.Instance.Context;

        public List<Wizyty> CreateTable()
        {
            var list = ctx.Wizyties.ToList();
            return list;
        }

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

        public static List<Wizyty> listaWizyt()
        {
            return ctx.Wizyties.ToList();
        }


        public void UsunWiersz(Wizyty wizyta)
        {
            var Query = (from ctx in ctx.Wizyties where ctx.Id == wizyta.Id select ctx).ToList();
            foreach (var row in Query)
            {
                ctx.Wizyties.Remove(row);
                ctx.SaveChanges();
            }
        }


    }
}
