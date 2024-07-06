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

				datos.leer();
				while(datos.Reader.Read())
				{
					//ACA SE COMPLETAN LOS DATOS FALTANTES DEL USUARIO, YA QUE SE PASA POR REFERENCIA EN Loguear();
					usuario.ID = (int)datos.Reader["ID"]; 
					byte tipo = (Byte)(datos.Reader["Tipo"]);

					switch (tipo)
					{
						case 1: usuario.TipoUsuario = TipoUsuario.ADMIN;
							break;
                        case 2:
                            usuario.TipoUsuario = TipoUsuario.RECEP;
                            break;
                        case 3:
                            usuario.TipoUsuario = TipoUsuario.MEDICO;
                            break;
                        case 4:
                            usuario.TipoUsuario = TipoUsuario.PACIENTE;
                            break;
                        default:
							break;
					}
					//usuario.TipoUsuario = (int)(datos.Reader["Tipo"]) == 1 ? TipoUsuario.ADMIN : TipoUsuario.RECEP;
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
