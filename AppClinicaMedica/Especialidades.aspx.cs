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
                Session.Add("listaEspecialidades", EspNegocio.listar());
                listaEspecialidades = EspNegocio.listar();

                //repetidor.DataSource = listaEspecialidades;
                repetidor.DataSource = Session["listaEspecialidades"];
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

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Especialidad> lista = (List<Especialidad>)Session["listaEspecialidades"];
            List<Especialidad> listaFiltrada = lista.FindAll(esp => esp.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            repetidor.DataSource = listaFiltrada;
            repetidor.DataBind();
        }
    }
}