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
                datos.setQuery("SELECT ID, NOMBRE, DESCRIPCION, IMAGEN FROM ESPECIALIDADES WHERE ESTADO = 1 ORDER BY NOMBRE ASC");
                datos.leer();

                while(datos.Reader.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.IdEspecialidad = (int)datos.Reader["ID"];
                    aux.Nombre = (string)datos.Reader["NOMBRE"];
                    aux.Descripcion = (string)datos.Reader["Descripcion"];
                    aux.Imagen = (string)datos.Reader["Imagen"];

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

        public void agregarEspecialidad(Especialidad especialidad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if(especialidad.Nombre != "")
                {
                    datos.setQuery("INSERT INTO ESPECIALIDADES (NOMBRE, DESCRIPCION, IMAGEN) VALUES ('" + especialidad.Nombre + "', '" + especialidad.Descripcion + "', '" + especialidad.Imagen + "')");
                    datos.ejecutarAccion();
                }
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

        public void bajaEspecialidad(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setQuery("UPDATE ESPECIALIDADES SET ESTADO = 0 WHERE ID = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
