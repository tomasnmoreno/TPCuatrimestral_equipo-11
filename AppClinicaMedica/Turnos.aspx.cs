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
    public partial class Turnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadNegocio negEspecialidad = new EspecialidadNegocio();
            MedicoNegocio medEspecialidad = new MedicoNegocio();
            TurnoNegocio turnoNegocio = new TurnoNegocio();

            try
            {
                if (!IsPostBack)
                {

                    List<Medico> listaMedicos = medEspecialidad.listar();
                    Session["listaMedicos"] = listaMedicos;

                    List<Especialidad> listaEspecialidades = negEspecialidad.listar();
                    ddlEspecialidades.DataSource = listaEspecialidades;
                    ddlEspecialidades.DataTextField = "Nombre";
                    ddlEspecialidades.DataValueField = "IdEspecialidad";
                    ddlEspecialidades.DataBind();

                    List<Turno> listaTurnos = turnoNegocio.listar();
                    dgvTurnos.DataSource = listaTurnos;
                    dgvTurnos.DataBind();
                    Session.Add("listaTurnos", listaTurnos);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
            
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Medico> listaMedicosFiltrados = new List<Medico>();

            try
            {
                int id = int.Parse(ddlEspecialidades.SelectedItem.Value);
                datos.setQuery("select m.apellido, m.IDUsuario from MEDICOS m inner join EspecialidadesXMedicos em on em.IDMedico = m.IDUsuario inner join Especialidades e on e.Id = em.IDEspecialidad where e.Id = @idEspecialidad");
                datos.setearParametro("@IdEspecialidad", id);
                datos.leer();

                while (datos.Reader.Read())
                {
                    Medico aux = new Medico();

                    aux.IdMedico = (string)datos.Reader["IDUsuario"].ToString();
                    aux.Apellido = (string)datos.Reader["apellido"];

                    listaMedicosFiltrados.Add(aux);
                }

                ddlMedicosFiltrados.DataSource = listaMedicosFiltrados;
                ddlMedicosFiltrados.DataTextField = "apellido";

                ddlMedicosFiltrados.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}