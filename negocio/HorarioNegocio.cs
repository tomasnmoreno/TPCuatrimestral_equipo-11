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
                datos.setQuery("SELECT IDHorario, HoraInicio, HoraFin, IdDia FROM HorariosTrabajo");
                datos.leer();

                while (datos.Reader.Read())
                {
                    HorarioTrabajo aux = new HorarioTrabajo();
                    aux.IDHorario = (int)datos.Reader["IDHorario"];
                    aux.HoraInicio = (TimeSpan)datos.Reader["HoraInicio"];
                    aux.HoraFin = (TimeSpan)datos.Reader["HoraFin"];
                    aux.IdDia = (int)datos.Reader["IdDia"];


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

        public void agregarHorario(DateTime horaInicio, DateTime horaFin, int IdDia)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("INSERT INTO HorariosTrabajo (HoraInicio, HoraFin, IdDia) VALUES (@HoraInicio, @HoraFin, @IdDia)");
                datos.setearParametro("@HoraInicio", horaInicio.TimeOfDay);
                datos.setearParametro("@HoraFin", horaFin.TimeOfDay);
                datos.setearParametro("@IdDia",IdDia);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
