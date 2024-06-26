﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppClinicaMedica
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                usuario = new Usuario(txtbUserName.Text, txtbPassword.Text, false);
                if (usuarioNegocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    Session.Add("error", "Use op Pass incorrectas");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                //throw;
            }
        }
    }
}