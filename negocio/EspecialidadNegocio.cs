using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class EspecialidadNegocio
    {
        public List<Especialidad> listar()
        {
            List<Especialidad> listaEspecialidades = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("SELECT DESCRIPCION FROM ESPECIALIDADES ORDER BY DESCRIPCION ASC");
                datos.leer();

                while(datos.Reader.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.Nombre = (string)datos.Reader["DESCRIPCION"];

                    listaEspecialidades.Add(aux);
                }
                return listaEspecialidades;
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
