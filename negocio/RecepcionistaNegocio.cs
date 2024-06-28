using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class RecepcionistaNegocio
    {
        public List<Recepcionista> listar()
        {
            List<Recepcionista> listaRecepcionistas = new List<Recepcionista>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("select r.IDUsuario, u.Pass, u.NombreUsuario, r.Nombre, r.Apellido, r.Nacimiento, r.Dni, u.EMail, r.Celular, r.Domicilio, r.CodPostal from RECEPCIONISTAS r inner join Usuarios u on u.ID = r.IDUsuario where u.Estado=1");
                datos.leer();

                while (datos.Reader.Read())
                {
                    Recepcionista aux = new Recepcionista();
                    aux.IDRecepcionista = (int)datos.Reader["IDUsuario"];
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

                    listaRecepcionistas.Add(aux);
                }
                return listaRecepcionistas;
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

        public void agregarRecepcionista(Recepcionista recepcionista)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (recepcionista.Nombre != "")
                {
                    datos.setearProcedure("SP_Nuevo_Recepcionista");
                    datos.setearParametro("Nombre", recepcionista.Nombre);
                    datos.setearParametro("Apellido", recepcionista.Apellido);
                    datos.setearParametro("Nacimiento", recepcionista.FechaDeNacimiento);
                    datos.setearParametro("Dni", recepcionista.Dni);
                    datos.setearParametro("Email", recepcionista.Email);
                    datos.setearParametro("Celular", recepcionista.Celular);
                    datos.setearParametro("Domicilio", recepcionista.Domicilio);
                    datos.setearParametro("CodPostal", recepcionista.CodPostal);
                    datos.setearParametro("NombreUsuario", recepcionista.NombreUsuario);
                    datos.setearParametro("Pass", recepcionista.Pass);
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

        public void modificarRecepcionista(Recepcionista recepcionista)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("update Usuarios set NombreUsuario = @NombreUsuario, Pass = @Pass, Email = @Email where ID = @ID update Recepcionistas set Nombre = @Nombre, Apellido = @Apellido, Nacimiento = @Nacimiento, EMail = @Email, Celular = @Celular, Domicilio = @Domicilio, CodPostal = @CodPostal where IDUsuario = @ID");
                datos.setearParametro("@Nombre", recepcionista.Nombre);
                datos.setearParametro("@Apellido", recepcionista.Apellido);
                datos.setearParametro("@Nacimiento", recepcionista.FechaDeNacimiento.ToString("yyyy-MM-dd"));
                datos.setearParametro("@Email", recepcionista.Email);
                datos.setearParametro("@Celular", recepcionista.Celular);
                datos.setearParametro("@Domicilio", recepcionista.Domicilio);
                datos.setearParametro("@CodPostal", recepcionista.CodPostal);
                datos.setearParametro("@ID", recepcionista.IDRecepcionista);
                datos.setearParametro("@NombreUsuario", recepcionista.NombreUsuario);
                datos.setearParametro("@Pass", recepcionista.Pass);
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

        public void bajaRecepcionistaFisica(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearProcedure("SP_Baja_Recepcionista");
                datos.setearParametro("IDUsuario", id);
                datos.ejecutarAccion();
                //datos.setQuery("DELETE FROM Usuarios WHERE ID = @id");
                //datos.setearParametro("@id", id);
                //datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}

