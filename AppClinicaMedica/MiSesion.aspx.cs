using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppClinicaMedica
{
    public partial class MiSesion : System.Web.UI.Page
    {
        Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
                AccesoDatos datos = new AccesoDatos();
                
            try
            {
                int IDUsuario = int.Parse(Session["IDUsuario"].ToString());
                datos.setearParametro("@IDUsuario", IDUsuario);

                if (esAdmin())
                {
                    datos.setQuery("SELECT NombreUsuario, Email, FechaAlta FROM USUARIOS WHERE ID = 1");
                    datos.leer();

                    if (datos.Reader.Read())
                    {
                        txtPerfilNombre.Text = datos.Reader["NombreUsuario"].ToString();
                        txtPerfilEmail.Text = datos.Reader["Email"].ToString();
                        txtPerfilAlta.Text = Convert.ToDateTime(datos.Reader["FechaAlta"]).ToString("dd/MM/yyyy");
                    }
                }

                if (esRecepcionista())
                {
                    datos.setQuery("SELECT R.Nombre, R.Apellido, R.Dni, R.Nacimiento, R.Domicilio, U.Email, R.Celular, U.FechaAlta FROM RECEPCIONISTAS R INNER JOIN Usuarios U ON R.IDUsuario = U.ID WHERE U.ID = @IDUsuario");
                    datos.leer();
                   
                    if (datos.Reader.Read())
                    {
                        txtPerfilNombre.Text = datos.Reader["Nombre"].ToString();
                        txtPerfilApellido.Text = datos.Reader["Apellido"].ToString();
                        txtPerfilDni.Text = datos.Reader["Dni"].ToString();
                        txtPerfilNacimiento.Text = Convert.ToDateTime(datos.Reader["Nacimiento"]).ToString("dd/MM/yyyy");
                        txtPerfilDomicilio.Text = datos.Reader["Domicilio"].ToString();
                        txtPerfilEmail.Text = datos.Reader["Email"].ToString();
                        txtPerfilCelular.Text = datos.Reader["Celular"].ToString();
                        txtPerfilAlta.Text = Convert.ToDateTime(datos.Reader["FechaAlta"]).ToString("dd/MM/yyyy");
                    }
                }
                if (esPaciente())
                {
                    datos.setQuery("SELECT P.Nombre, P.Apellido, P.Dni, P.Nacimiento, P.Domicilio, U.Email, P.Celular, U.FechaAlta FROM PACIENTES P INNER JOIN Usuarios U ON P.IDUsuario = U.ID WHERE U.ID = @IDUsuario");
                    datos.leer();

                    if (datos.Reader.Read())
                    {
                        txtPerfilNombre.Text = datos.Reader["Nombre"].ToString();
                        txtPerfilApellido.Text = datos.Reader["Apellido"].ToString();
                        txtPerfilDni.Text = datos.Reader["Dni"].ToString();
                        txtPerfilNacimiento.Text = Convert.ToDateTime(datos.Reader["Nacimiento"]).ToString("dd/MM/yyyy");
                        txtPerfilDomicilio.Text = datos.Reader["Domicilio"].ToString();
                        txtPerfilEmail.Text = datos.Reader["Email"].ToString();
                        txtPerfilCelular.Text = datos.Reader["Celular"].ToString();
                        txtPerfilAlta.Text = Convert.ToDateTime(datos.Reader["FechaAlta"]).ToString("dd/MM/yyyy");
                    }
                }
                if (esMedico())
                {
                    datos.setQuery("SELECT M.Nombre, M.Apellido, M.Dni, M.Nacimiento, M.Domicilio, U.Email, M.Celular, U.FechaAlta FROM MEDICOS M INNER JOIN Usuarios U ON M.IDUsuario = U.ID WHERE U.ID = @IDUsuario");
                    datos.leer();

                    if (datos.Reader.Read())
                    {
                        txtPerfilNombre.Text = datos.Reader["Nombre"].ToString();
                        txtPerfilApellido.Text = datos.Reader["Apellido"].ToString();
                        txtPerfilDni.Text = datos.Reader["Dni"].ToString();
                        txtPerfilNacimiento.Text = Convert.ToDateTime(datos.Reader["Nacimiento"]).ToString("dd/MM/yyyy");
                        txtPerfilDomicilio.Text = datos.Reader["Domicilio"].ToString();
                        txtPerfilEmail.Text = datos.Reader["Email"].ToString();
                        txtPerfilCelular.Text = datos.Reader["Celular"].ToString();
                        txtPerfilAlta.Text = Convert.ToDateTime(datos.Reader["FechaAlta"]).ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool esAdmin()
        {
            if ((Session["usuario"] != null && (((dominio.Usuario)(Session["usuario"])).TipoUsuario == TipoUsuario.ADMIN)))
            {
                return true;
            }
            return false;
        }

        public bool esRecepcionista()
        {
            if ((Session["usuario"] != null && (((dominio.Usuario)(Session["usuario"])).TipoUsuario == TipoUsuario.RECEP)))
            {
                return true;
            }
            return false;
        }

        public bool esMedico()
        {
            if ((Session["usuario"] != null && (((dominio.Usuario)(Session["usuario"])).TipoUsuario == TipoUsuario.MEDICO)))
            {
                return true;
            }
            return false;
        }

        public bool esPaciente()
        {
            if ((Session["usuario"] != null && (((dominio.Usuario)(Session["usuario"])).TipoUsuario == TipoUsuario.PACIENTE)))
            {
                return true;
            }
            return false;
        }
    protected void btnCambioContraseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarContraseña.aspx");
        }
    }
}