using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class RecepcionistaNegocio
    {
        public List<Recepcionista> listar()
        {
            List<Recepcionista> listaRecepcionistas = new List<Recepcionista>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("select ID, NombreUsuario, Pass, Email, Tipo, Estado from Usuarios where Tipo = 2");
                datos.leer();

                while (datos.Reader.Read())
                {
                    Recepcionista aux = new Recepcionista();
                    aux.IdRecepcionista =  (int)datos.Reader["ID"];
                    aux.Dni = 41893710;
                    aux.Nombre = (string)datos.Reader["NombreUsuario"];
                    aux.Email = (string)datos.Reader["Email"];
                    aux.Estado = (bool)datos.Reader["Estado"];

                    listaRecepcionistas.Add(aux);
                }
                return listaRecepcionistas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}

