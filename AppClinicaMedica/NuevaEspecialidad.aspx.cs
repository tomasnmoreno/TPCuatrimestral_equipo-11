﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace AppClinicaMedica
{
    public partial class NuevaEspecialidad : System.Web.UI.Page
    {
        private Especialidad especialidad = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                List<Especialidad> listaEspecialidades;
                listaEspecialidades = negocio.listar();

                foreach (Especialidad especialidad in listaEspecialidades)
                {
                    if (int.Parse(id) == especialidad.IdEspecialidad)
                    {
                        txtEspecialidad.Text = especialidad.Nombre;
                        txtDescripcionEspecialidad.Text = especialidad.Descripcion;
                        txtImagenNuevaEspecialidad.Text = especialidad.Imagen;
                    }
                }
            }
        }

        protected void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            try
            {
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                Especialidad especialidad = new Especialidad();
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                especialidad.Nombre = txtEspecialidad.Text;
                especialidad.Descripcion = txtDescripcionEspecialidad.Text;
                especialidad.Imagen = txtImagenNuevaEspecialidad.Text;

                if (id != "")
                {
                    especialidad.IdEspecialidad = int.Parse(id);
                    negocio.modificarEspecialidad(especialidad);
                }
                else
                    negocio.agregarEspecialidad(especialidad);

                Response.Redirect("Especialidades.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}