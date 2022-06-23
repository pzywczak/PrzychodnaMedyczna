using System;
using System.Collections.Generic;
using System.Linq;
using ViewWPF.baza;

namespace ViewWPF.Class
{
    class Lekarz
    {
        private static PrzychodniaLekarskaEntities ctx = Singel.Instance.Context;

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
            List<Lekarze> ListaFiltrada = new List<Lekarze>();

            foreach (Lekarze medicoTestado in ctx.Lekarzes.ToList())
            {
                if (medicoTestado.USERID.Equals(id))
                {
                    ListaFiltrada.Add(medicoTestado);
                }
            }
            return ListaFiltrada;
        }

        public static int Wynik()
        {
            List<Lekarze> ListaFiltrada = new List<Lekarze>();
            ListaFiltrada = filtrListaLekarzy(Program.Batatinha);
            int cont = ListaFiltrada.Count;
            return cont;
        }

    }
}
