using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                datos.setQuery("select t.IDTurno, m.Nombre + ', ' + m.Apellido as Medico, e.Nombre as Especialidad, p.Nombre + ', ' + p.Apellido as Paciente, t.Fecha, t.Hora from Turnos t\r\ninner join MEDICOS m on m.IDUsuario = t.IDMedico\r\nleft join PACIENTES p on p.IDUsuario = t.IDPaciente\r\ninner join EspecialidadesXMedicos exm on exm.IDMedico = t.IDMedico\r\ninner join Especialidades e on e.Id = exm.IDEspecialidad");
                datos.leer();

                while (datos.Reader.Read())
                {
                    Turno aux = new Turno();
                    aux.IdTurno = (Int64)datos.Reader["IDTurno"];
                    //aux.medico.Nombre = (string)datos.Reader["Medico"];
                    //aux.especialidad.Nombre = (string)datos.Reader["Especialidad"];
                    //aux.paciente.Nombre = (string)datos.Reader["Paciente"];
                    aux.medico = new Medico();
                    aux.medico.Nombre = (string)datos.Reader["Medico"];

                    aux.especialidad = new Especialidad();
                    aux.especialidad.Nombre = (string)datos.Reader["Especialidad"];

                    aux.paciente = new Paciente();
                    if(!(datos.Reader["Paciente"] is DBNull))
                    {
                    aux.paciente.Nombre = (string)datos.Reader["Paciente"];
                    }
                    else
                    {
                        aux.paciente.Nombre = "Sin Asignar";
                    }

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

        public List<Turno> listar(int IDMedico)
        {
            List<Turno> listaTurnos = new List<Turno>();
            
            try
            {
                datos.setQuery("select t.IDTurno, m.Nombre + ', ' + m.Apellido as Medico, e.Nombre as Especialidad, p.Nombre + ', ' + p.Apellido as Paciente, t.Fecha, t.Hora from Turnos t\r\ninner join MEDICOS m on m.IDUsuario = t.IDMedico\r\nleft join PACIENTES p on p.IDUsuario = t.IDPaciente\r\ninner join EspecialidadesXMedicos exm on exm.IDMedico = t.IDMedico\r\ninner join Especialidades e on e.Id = exm.IDEspecialidad where t.IDMedico = @IDMedico");
                datos.setearParametro("@IDMedico", IDMedico);
                datos.leer();

                while (datos.Reader.Read())
                {
                    Turno aux = new Turno();
                    aux.IdTurno = (Int64)datos.Reader["IDTurno"];
                    //aux.medico.Nombre = (string)datos.Reader["Medico"];
                    //aux.especialidad.Nombre = (string)datos.Reader["Especialidad"];
                    //aux.paciente.Nombre = (string)datos.Reader["Paciente"];
                    aux.medico = new Medico();
                    aux.medico.Nombre = (string)datos.Reader["Medico"];

                    aux.especialidad = new Especialidad();
                    aux.especialidad.Nombre = (string)datos.Reader["Especialidad"];

                    aux.paciente = new Paciente();
                    if (!(datos.Reader["Paciente"] is DBNull))
                    {
                        aux.paciente.Nombre = (string)datos.Reader["Paciente"];
                    }
                    else
                    {
                        aux.paciente.Nombre = "Sin Asignar";
                    }

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
