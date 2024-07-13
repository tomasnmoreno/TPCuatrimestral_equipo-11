using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppClinicaMedica
{
    public partial class MiSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                if (esRecepcionista())
                {
                    datos.setQuery("SELECT NOMBRE, APELLIDO ");
                }
            }
            catch (Exception)
            {

                throw;
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