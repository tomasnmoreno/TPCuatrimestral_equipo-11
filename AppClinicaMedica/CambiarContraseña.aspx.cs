using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppClinicaMedica
{
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnConfirmarContraseña_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            int IDUsuario = int.Parse(Session["IDUsuario"].ToString());
            string pass = Session["Password"].ToString();
            string nuevaPass = txtPassNueva.Text;
            
            try
            {
                if(txtPassActual.Text != pass)
                {
                    Session.Add("error", "La contraseña actual no coincide con la indicada.");
                    lblErrorPassword.Text = Session["error"].ToString();

                }else if(txtPassNueva.Text == txtPassActual.Text)
                {
                    Session.Add("error", "La contraseña nueva no puede ser la misma que la actual.");
                    lblErrorPassword.Text = Session["error"].ToString();

                }else if(txtPassNueva.Text != txtRepetirPass.Text)
                {
                    Session.Add("error", "Los campos 'Nueva Contraseña' y 'Repetir Nueva Contraseña' deben coincidir");
                    lblErrorPassword.Text = Session["error"].ToString();

                }else if (txtPassActual.Text == pass && txtPassNueva.Text == txtRepetirPass.Text)
                {
                    datos.setQuery("UPDATE USUARIOS SET PASS = @nuevaPass WHERE ID = @IDUsuario");
                    datos.setearParametro("@nuevaPass", nuevaPass);
                    datos.setearParametro("@IDUsuario", IDUsuario);

                    datos.ejecutarAccion();
                    Session.Remove("error");
                    lblPasswordOk.Text = "Contraseña modificada exitosamente.";
                    
                }
                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                //throw ex;
            }
            finally
            {                
                datos.cerrarConexion();
            }
        }
    }
}