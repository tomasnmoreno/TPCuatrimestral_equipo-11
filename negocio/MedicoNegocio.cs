using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MedicoNegocio
    {
        public List<Medico> listar()
        {
            List<Medico> listaMedico = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
               // datos.setQuery("SELECT Idusuario, Matricula, Nombre, Apellido, U.NombreUsuario, U.Pass, Email, Nacimiento, Dni, Celular, Domicilio, CodPostal, U.Estado FROM MEDICOS inner join Usuarios U on MEDICOS.IDUsuario=U.ID AND U.Estado = 1");
               datos.setQuery("SELECT m.Idusuario, m.Matricula, m.Nombre, m.Apellido, U.NombreUsuario, U.Pass, U.Email, m.Nacimiento, m.Dni, m.Celular, m.Domicilio, m.CodPostal, U.Estado, e.Id as Especialidad FROM MEDICOS m inner join Usuarios U on m.IDUsuario = m.IDUsuario inner join EspecialidadesXMedicos exm on exm.IDMedico = m.IDUsuario inner join Especialidades e on e.Id = exm.IDEspecialidad where m.IDUsuario=U.ID AND U.Estado = 1");
                datos.leer();

                while (datos.Reader.Read())
                {
                    Medico aux = new Medico();
                    aux.IdMedico = datos.Reader["Idusuario"].ToString();
                    aux.Matricula = (int)datos.Reader["Matricula"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Apellido = (string)datos.Reader["Apellido"];
                    aux.Email = (string)datos.Reader["Email"];
                    aux.Usuario = (string)datos.Reader["NombreUsuario"];
                    aux.Contraseña = (string)datos.Reader["Pass"];
                    aux.FechaDeNacimiento = (DateTime)datos.Reader["Nacimiento"];
                    aux.Dni = (Int64)datos.Reader["Dni"];
                    aux.Celular = (Int64)datos.Reader["Celular"];
                    aux.Domicilio = (string)datos.Reader["Domicilio"];
                    aux.CodPostal = (int)datos.Reader["CodPostal"];
                    aux.Estado = (bool)datos.Reader["Estado"];
                    aux.IDEspecialidad = (int)datos.Reader["Especialidad"];

                    listaMedico.Add(aux);
                }
                return listaMedico;
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

        public List<Medico> listarMed()
        {
            List<Medico> listaMedico = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("SELECT Idusuario, Matricula, Nombre, Apellido, U.NombreUsuario, U.Pass, Email, Nacimiento, Dni, Celular, Domicilio, CodPostal, U.Estado FROM MEDICOS inner join Usuarios U on MEDICOS.IDUsuario=U.ID AND U.Estado = 1");
                //datos.setQuery("SELECT m.Idusuario, m.Matricula, m.Nombre, m.Apellido, U.NombreUsuario, U.Pass, U.Email, m.Nacimiento, m.Dni, m.Celular, m.Domicilio, m.CodPostal, U.Estado, e.Id as Especialidad FROM MEDICOS m inner join Usuarios U on m.IDUsuario = m.IDUsuario inner join EspecialidadesXMedicos exm on exm.IDMedico = m.IDUsuario inner join Especialidades e on e.Id = exm.IDEspecialidad where m.IDUsuario=U.ID AND U.Estado = 1");
                datos.leer();

                while (datos.Reader.Read())
                {
                    Medico aux = new Medico();
                    aux.IdMedico = datos.Reader["Idusuario"].ToString();
                    aux.Matricula = (int)datos.Reader["Matricula"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Apellido = (string)datos.Reader["Apellido"];
                    aux.Email = (string)datos.Reader["Email"];
                    aux.Usuario = (string)datos.Reader["NombreUsuario"];
                    aux.Contraseña = (string)datos.Reader["Pass"];
                    aux.FechaDeNacimiento = (DateTime)datos.Reader["Nacimiento"];
                    aux.Dni = (Int64)datos.Reader["Dni"];
                    aux.Celular = (Int64)datos.Reader["Celular"];
                    aux.Domicilio = (string)datos.Reader["Domicilio"];
                    aux.CodPostal = (int)datos.Reader["CodPostal"];
                    aux.Estado = (bool)datos.Reader["Estado"];

                    listaMedico.Add(aux);
                }
                return listaMedico;
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

        public void modificarMedico(Medico medico)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearProcedure("SP_Modificar_Medico");
                datos.setearParametro("Nombre", medico.Nombre);
                datos.setearParametro("Apellido", medico.Apellido);
                datos.setearParametro("Matricula", medico.Matricula);
                datos.setearParametro("Email", medico.Email);
                datos.setearParametro("Celular", medico.Celular);
                datos.setearParametro("Domicilio", medico.Domicilio);
                datos.setearParametro("CodPostal", medico.CodPostal);
                datos.setearParametro("Dni", medico.Dni);
                datos.setearParametro("ID", medico.IdMedico);

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

        public void agregarMedico(Medico medico)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                
                    datos.setearProcedure("SP_Nuevo_Medico");
                    datos.setearParametro("Nombre", medico.Nombre);
                    datos.setearParametro("Apellido", medico.Apellido);
                    datos.setearParametro("Nacimiento", medico.FechaDeNacimiento);
                    datos.setearParametro("Dni", medico.Dni);
                    datos.setearParametro("Email", medico.Email);
                    datos.setearParametro("Celular", medico.Celular);
                    datos.setearParametro("Domicilio", medico.Domicilio);
                    datos.setearParametro("CodPostal", medico.CodPostal);
                    datos.setearParametro("Matricula", medico.Matricula);
                    datos.setearParametro("NombreUsuario", medico.Usuario);
                    datos.setearParametro("Pass", medico.Contraseña);
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

        public void bajaMedico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setQuery("UPDATE Usuarios SET ESTADO = 0 WHERE ID = @id");
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
