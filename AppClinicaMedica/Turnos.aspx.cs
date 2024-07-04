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
                    Session.Add("listaTurnos", turnoNegocio.listar());
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
                ddlMedicosFiltrados.DataValueField = "IdMedico";

                ddlMedicosFiltrados.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlMedicosFiltrados_DataBound(object sender, EventArgs e)
        {
            MedicoNegocio todosLosMedico = new MedicoNegocio();
            List<Medico> medicosLista = todosLosMedico.listar();
            foreach (ListItem item in ddlMedicosFiltrados.Items)
            {
                int idMedico = Convert.ToInt32(item.Value);

                var Medico = medicosLista.FirstOrDefault(m => Convert.ToInt32(m.IdMedico) == idMedico);
                if (Medico != null)
                {

                    item.Text = $"{Medico.Nombre}  { Medico.Apellido}";
                }
            }
        }

        protected void dgvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMedicosFiltrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            int IDMedico = int.Parse(ddlMedicosFiltrados.SelectedItem.Value);
            List<Turno> listaTurnos = turnoNegocio.listar(IDMedico);
            dgvTurnos.DataSource = listaTurnos;
            dgvTurnos.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}