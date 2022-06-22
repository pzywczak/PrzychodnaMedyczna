using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ViewWPF.baza;

namespace ViewWPF.DAL
{
    class PacienteDAO
    {

        private static PrzychodniaLekarskaEntities ctx = Singleton.Instance.Context;

        public static bool SalvarPaciente(Pacjenci paciente)
        {
            if (BuscarPacientePorCPF(paciente) == null)
            {
                try
                {
                    ctx.Pacjencis.Add(paciente);
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

        public static bool AlterarPaciente(Pacjenci paciente)
        {
            try
            {
                ctx.Entry(paciente).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static Pacjenci BuscarPacientePorCPF(Pacjenci paciente)
        {
            return ctx.Pacjencis.FirstOrDefault(x => x.Adres.Equals(paciente.Adres));
        }

        public static List<Pacjenci> ListagemDePacientes()
        {
            return ctx.Pacjencis.ToList();
        }

        public static List<Pacjenci> ListagemFiltradaDePacientes(int id)
        {
            //List<Paciente> ListaFiltrada = new List<Paciente>();

            //foreach (Paciente pacienteTestado in ctx.Pacientes.ToList())
            //{
            //    if (pacienteTestado.UsuarioId.Equals(id))
            //    {
            //        ListaFiltrada.Add(pacienteTestado);
            //    }
            //}
            //return ListaFiltrada;

            return ctx.Pacjencis.Where(p => p.USERID== id).ToList();
        }

        public static int Contagem()
        {
            List<Pacjenci> ListaFiltrada = new List<Pacjenci>();
            ListaFiltrada = ListagemFiltradaDePacientes(Program.Batatinha);
            int cont = ListaFiltrada.Count;
            return cont;
        }
    }
}
