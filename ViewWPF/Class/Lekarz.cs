using System;
using System.Collections.Generic;
using System.Linq;
using ViewWPF.baza;

namespace ViewWPF.Class
{
    /// <summary>
    /// Klasa lekarz, odpowiedzialna za dodawanie,modyfikowanie lekarzy za pomoca listy
    /// </summary>
    class Lekarz
    {
        private static PrzychodniaLekarskaEntities5 ctx = Singel.Instance.Context;

        public static bool zapiszLekarza(Lekarze lekarz)
        {
            if (wyszukajLekarzaPoAdresie(lekarz) == null)
            {
                try 
                {
                    ctx.Lekarzes.Add(lekarz);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool zmienPacjenta(Lekarze lekarz)
        {
            try
            {
                ctx.Entry(lekarz).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static Lekarze szukajLekarzaPoId(int id)
        {
            return ctx.Lekarzes.Find(id);
        }

        public static Lekarze wyszukajLekarzaPoAdresie(Lekarze medico)
        {
            return ctx.Lekarzes.FirstOrDefault(x => x.Adres.Equals(medico.Adres));
        }

        public static Lekarze wyszukajLekarzaPoImieniuINaziwsku(Lekarze medico)
        {
            return ctx.Lekarzes.FirstOrDefault(x => x.ImieINazwisko.Equals(medico.ImieINazwisko));
        }

        public static List<Lekarze> listaLekarzy()
        {
            return ctx.Lekarzes.ToList();
        }

        public static List<Lekarze> filtrListaLekarzy(int id)
        {
            List<Lekarze> ListaFiltrowana = new List<Lekarze>();

            foreach (Lekarze Lekarzid in ctx.Lekarzes.ToList())
            {
                if (Lekarzid.USERID.Equals(id))
                {
                    ListaFiltrowana.Add(Lekarzid);
                }
            }
            return ListaFiltrowana;
        }

        public static int Wynik()
        {
            List<Lekarze> ListaFiltrowana = new List<Lekarze>();
            ListaFiltrowana = filtrListaLekarzy(Program.User);
            int cont = ListaFiltrowana.Count;
            return cont;
        }
        public void UsunWiersz(Lekarze pacient)
        {
            var Query = (from ctx in ctx.Lekarzes where ctx.Id == pacient.Id select ctx).ToList();
            foreach (var row in Query)
            {
                ctx.Lekarzes.Remove(row);
                ctx.SaveChanges();
            }
        }

    }
}
