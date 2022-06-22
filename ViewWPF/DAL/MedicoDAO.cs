using System;
using System.Collections.Generic;
using System.Linq;
using ViewWPF.baza;

namespace ViewWPF.DAL
{
    class MedicoDAO
    {
        private static PrzychodniaLekarskaEntities ctx = Singleton.Instance.Context;

        public static bool SalvarMedico(Lekarze medico)
        {
            if (BuscarMedicoPorCPF(medico) == null)
            {
                try // CAMINHO FELIZ
                {
                    ctx.Lekarzes.Add(medico);
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

        public static bool AlterarMedico(Lekarze medico)
        {
            try
            {
                ctx.Entry(medico).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static Lekarze ProcurarMedicoPorId(int id)
        {
            return ctx.Lekarzes.Find(id);
        }

        public static Lekarze BuscarMedicoPorCPF(Lekarze medico)
        {
            return ctx.Lekarzes.FirstOrDefault(x => x.Adres.Equals(medico.Adres));
        }

        public static Lekarze BuscarMedicoPorNome(Lekarze medico)
        {
            return ctx.Lekarzes.FirstOrDefault(x => x.ImieINazwisko.Equals(medico.ImieINazwisko));
        }

        public static List<Lekarze> ListagemDeMedicos()
        {
            return ctx.Lekarzes.ToList();
        }

        public static List<Lekarze> ListagemFiltradaDeMedicos(int id)
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

        public static int Contagem()
        {
            List<Lekarze> ListaFiltrada = new List<Lekarze>();
            ListaFiltrada = ListagemFiltradaDeMedicos(Program.Batatinha);
            int cont = ListaFiltrada.Count;
            return cont;
        }

    }
}
