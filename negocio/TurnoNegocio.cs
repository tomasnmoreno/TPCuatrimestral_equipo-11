using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TurnoNegocio
    {
        AccesoDatos datos = new AccesoDatos();


        public List<Turno> listar() { 
            List<Turno> listaTurnos = new List<Turno>();

            try
            {
                datos.setQuery("select IDTurno, IDMedico, IDPaciente, Fecha, Hora from Turnos");
                datos.leer();

                while (datos.Reader.Read())
                {
                    Turno aux = new Turno();
                    aux.IdTurno = (int)datos.Reader["IDTurno"];
                    aux.IdMedico = (string)datos.Reader["IDMedico"];
                    aux.Fecha = (DateTime)datos.Reader["Fecha"];
                    aux.Hora = (TimeSpan)datos.Reader["Hora"];

                    listaTurnos.Add(aux);
                }

                return listaTurnos;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        
        }


        public void GenerarTurnos(Turno turno)
        {
            try
            {
            datos.setearProcedure("SP_InsertarTurno");
            datos.setearParametro("IDMedico", turno.IdMedico);
            datos.setearParametro("Fecha", turno.Fecha);
            datos.setearParametro("Hora", turno.Hora);

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
