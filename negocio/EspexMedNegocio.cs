using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    internal class EspexMedNegocio
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
    }
}
