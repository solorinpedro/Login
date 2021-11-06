using Login.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.BLL
{
    public class LoginBLL
    {
        public static bool Validar(string NombreUsuario, string clave)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var validar = from usuario in contexto.Usuarios
                              where usuario.NombreUsuario == NombreUsuario
                              && usuario.Clave == clave
                              select usuario;
                if (validar.Count() > 0)
                    paso = true;
                else
                    paso = false;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
    }
}
