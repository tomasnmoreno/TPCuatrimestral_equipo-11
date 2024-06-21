using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class EspexMedNegocio
    {
        public List<EspecialidadesxMedico> listar()
        {

            AccesoDatos datos = new AccesoDatos();
            List<EspecialidadesxMedico> lista = new List<EspecialidadesxMedico>();

            try
            {
                datos.setQuery("SELECT IDEspecialidad, IDMedico FROM EspecialidadesxMedicos");
                datos.leer();

                while (datos.Reader.Read())
                {
                    EspecialidadesxMedico aux = new EspecialidadesxMedico();
                    aux.IDEspecialidad = (int)datos.Reader["IDEspecialidad"];
                    aux.IDMedico = (int)datos.Reader["IDMedico"];

                    lista.Add(aux);

                }

                return lista;

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

        public void agregarEspecialidad_x_Medico(EspecialidadesxMedico nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedure("SP_Nueva_EspecialidadesXMedicos");
                datos.setearParametro("IDMedico", nueva.IDMedico);
                datos.setearParametro("IDEspecialidad", nueva.IDEspecialidad);
                datos.ejecutarAccion();
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


        public void eliminarEspecialidad_x_Medico(EspecialidadesxMedico ExM)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("DELETE FROM EspecialidadesXMedicos WHERE IDEspecialidad = @IDEspecialidad AND IDMedico = @IDMedico;");
                datos.setearParametro("@IdEspecialidad", ExM.IDEspecialidad);
                datos.setearParametro("@IdMedico", ExM.IDMedico);
                datos.ejecutarAccion();
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
