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
    public partial class OlvideMiContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();
            EmailService emailService = new EmailService();

            string mail = txtbMail.Text.ToString();

            string username = txtbUserName.Text.ToString();


            string contraseña = usuarioNegocio.ListarU(mail, username);

            if (contraseña != "")
            {
            emailService.ArmarCorreo(mail, contraseña);
            emailService.EnviarMail();
            Response.Redirect("LogIn.aspx");
            }
            else
            {
                Session.Add("error", "el nombre de usuario o mail no coinciden con un usuario registrado.");
                Response.Redirect("Error.aspx");
            }
            
        }
    }
}