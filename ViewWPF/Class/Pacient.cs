using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ViewWPF.baza;

namespace ViewWPF.Class
{
    class Pacient
    {

        private static PrzychodniaLekarskaEntities2 ctx = Singel.Instance.Context;

        public static bool zapiszPacjenta(Pacjenci pacjent)
        {
            if (wyszukajPacjentaPoAdresie(pacjent) == null)
            {
                try
                {
                    ctx.Pacjencis.Add(pacjent);
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

        public static bool zmienPacjenta(Pacjenci pacjent)
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

        public static Pacjenci wyszukajPacjentaPoAdresie(Pacjenci paciente)
        {
            return ctx.Pacjencis.FirstOrDefault(x => x.Adres.Equals(paciente.Adres));
        }

        public static List<Pacjenci> listaPacjentow()
        {
            return ctx.Pacjencis.ToList();
        }

        public static List<Pacjenci> filtrListaPacjentow(int id)
        {
            return ctx.Pacjencis.Where(p => p.USERID== id).ToList();
        }

        public static int Wynik()
        {
            List<Pacjenci> ListaFiltrada = new List<Pacjenci>();
            ListaFiltrada = filtrListaPacjentow(Program.Batatinha);
            int cont = ListaFiltrada.Count;
            return cont;
        }
    }
}
