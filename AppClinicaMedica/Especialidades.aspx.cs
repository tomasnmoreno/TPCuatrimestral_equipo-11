﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace AppClinicaMedica
{
    public partial class Especialidades : System.Web.UI.Page
    {
        public List<Especialidad> listaEspecialidades;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EspecialidadNegocio EspNegocio = new EspecialidadNegocio();
                listaEspecialidades = EspNegocio.listar();

                repetidor.DataSource = listaEspecialidades;
                repetidor.DataBind();
            }
        }

        protected void btnBajaEspecialidad_Click(object sender, EventArgs e)
        {
            EspecialidadNegocio negocio = new EspecialidadNegocio();

            try
            {
                int id = int.Parse(((Button)sender).CommandArgument);   
                negocio.bajaEspecialidad(id);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}