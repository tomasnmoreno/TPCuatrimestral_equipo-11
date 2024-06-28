using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class PacienteNegocio
    {
        public List<Paciente> listar()
        {
            List<Paciente> listaPacientes = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("select p.IDUsuario, u.Pass, u.NombreUsuario, p.Nombre, p.Apellido, p.Nacimiento, p.Dni, u.EMail, p.Celular, p.Domicilio, p.CodPostal from PACIENTES p inner join Usuarios u on u.ID = p.IDUsuario where u.Estado=1");
                datos.leer();

                while (datos.Reader.Read())
                {
                    Paciente aux = new Paciente();
                    aux.IDPaciente = (int)datos.Reader["IDUsuario"];
                    aux.NombreUsuario = (string)datos.Reader["NombreUsuario"];
                    aux.Pass = (string)datos.Reader["Pass"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Apellido = (string)datos.Reader["Apellido"];
                    aux.FechaDeNacimiento = (DateTime)datos.Reader["Nacimiento"];
                    aux.Dni = (Int64)datos.Reader["Dni"];
                    aux.Email = (string)datos.Reader["EMail"];
                    aux.Celular = (Int64)datos.Reader["Celular"];
                    aux.Domicilio = (string)datos.Reader["Domicilio"];
                    aux.CodPostal = (int)datos.Reader["CodPostal"];

                    listaPacientes.Add(aux);
                }
                return listaPacientes;
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

        public void agregarPaciente(Paciente paciente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (paciente.Nombre != "")
                {
                    datos.setearProcedure("SP_Nuevo_Paciente");
                    datos.setearParametro("Nombre", paciente.Nombre);
                    datos.setearParametro("Apellido", paciente.Apellido);
                    datos.setearParametro("Nacimiento", paciente.FechaDeNacimiento);
                    datos.setearParametro("Dni", paciente.Dni);
                    datos.setearParametro("Email", paciente.Email);
                    datos.setearParametro("Celular", paciente.Celular);
                    datos.setearParametro("Domicilio", paciente.Domicilio);
                    datos.setearParametro("CodPostal", paciente.CodPostal);
                    datos.setearParametro("NombreUsuario", paciente.NombreUsuario);
                    datos.setearParametro("Pass", paciente.Pass);
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

        //public void modificarPacienteSP(Paciente paciente)
        //{
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //    datos.setearProcedure("SP_Modificar_Paciente");
        //    //datos.setearParametro("Dni", paciente.Dni); --no va
        //    datos.setearParametro("Nombre", paciente.Nombre);
        //    datos.setearParametro("Apellido", paciente.Apellido);
        //    //datos.setearParametro("Nacimiento", paciente.FechaDeNacimiento);
        //    datos.setearParametro("Nacimiento", paciente.FechaDeNacimiento.ToString("yyyy-MM-dd"));
        //    datos.setearParametro("Email", paciente.Email);
        //    datos.setearParametro("Celular", paciente.Celular);
        //    datos.setearParametro("Domicilio", paciente.Domicilio);
        //    datos.setearParametro("CodPostal", paciente.CodPostal);
        //    datos.setearParametro("ID", paciente.IDPaciente);
        //    datos.setearParametro("NombreUsuario", paciente.NombreUsuario);
        //    datos.setearParametro("Pass", paciente.Pass);
        //    datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}

        public void modificarPaciente(Paciente paciente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("update Usuarios set NombreUsuario = @NombreUsuario, Pass = @Pass, Email = @Email where ID = @ID update Pacientes set Nombre = @Nombre, Apellido = @Apellido, Nacimiento = @Nacimiento, Celular = @Celular, Domicilio = @Domicilio, CodPostal = @CodPostal where IDUsuario = @ID");
                //datos.setearParametro("Dni", paciente.Dni); --no va
                datos.setearParametro("@Nombre", paciente.Nombre);
                datos.setearParametro("@Apellido", paciente.Apellido);
                //datos.setearParametro("Nacimiento", paciente.FechaDeNacimiento);
                datos.setearParametro("@Nacimiento", paciente.FechaDeNacimiento.ToString("yyyy-MM-dd"));
                datos.setearParametro("@Email", paciente.Email);
                datos.setearParametro("@Celular", paciente.Celular);
                datos.setearParametro("@Domicilio", paciente.Domicilio);
                datos.setearParametro("@CodPostal", paciente.CodPostal);
                datos.setearParametro("@ID", paciente.IDPaciente);
                datos.setearParametro("@NombreUsuario", paciente.NombreUsuario);
                datos.setearParametro("@Pass", paciente.Pass);
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

        public void bajaPaciente(int id)
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



