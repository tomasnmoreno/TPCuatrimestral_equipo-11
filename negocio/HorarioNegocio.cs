using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class HorarioNegocio
    {
        public List<HorarioTrabajo> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<HorarioTrabajo> lista = new List<HorarioTrabajo>();

            try
            {
                datos.setQuery("SELECT IDHorario, HoraInicio, HoraFin FROM HorarioTrabajo");
                datos.leer();

                while (datos.Reader.Read())
                {
                    HorarioTrabajo aux = new HorarioTrabajo();
                    aux.IDHorario = (int)datos.Reader["IDHorario"];
                    aux.HoraInicio = (TimeSpan)datos.Reader["HoraInicio"];
                    aux.HoraFin = (TimeSpan)datos.Reader["HoraFin"];

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
