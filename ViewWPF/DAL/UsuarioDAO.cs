using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewWPF.baza;

namespace ViewWPF.DAL
{
    class UsuarioDAO
    {
        private static PrzychodniaLekarskaEntities ctx = Singleton.Instance.Context;

        public static bool SalvarUsuario(Uzytkownicy usuario)
        {
            if (BuscarUsuarioPorLogin(usuario) == null)
            {
                try
                {
                    ctx.Uzytkownicies.Add(usuario);
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

        public static bool AlterarUsuario(Uzytkownicy usuario)
        {
            try
            {
                ctx.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static Uzytkownicy BuscarUsuarioPorLogin(Uzytkownicy usuario)
        {
            return ctx.Uzytkownicies.FirstOrDefault(x => x.Login.Equals(usuario.Login));
        }

        public static Uzytkownicy BuscarUsuarioPorLogin2(String login)
        {
            return ctx.Uzytkownicies.FirstOrDefault(x => x.Login.Equals(login));
        }

    }
}
