using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
				AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setQuery("select ID, Tipo from Usuarios where NombreUsuario = @user and Pass = @pass");
				datos.setearParametro("@user", usuario.NombreUsuario);
				datos.setearParametro("@pass", usuario.Pass);

				datos.ejecutarAccion();
				while(datos.Reader.Read())
				{
					usuario.ID = (int)datos.Reader["ID"];
					usuario.TipoUsuario = (int)(datos.Reader["Tipo"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.RECEP;
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
