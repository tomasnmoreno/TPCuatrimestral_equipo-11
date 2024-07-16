using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Resources;
using System.Data;

namespace AppClinicaMedica
{
    public partial class Turnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadNegocio negEspecialidad = new EspecialidadNegocio();
            MedicoNegocio medNegocio = new MedicoNegocio();
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            PacienteNegocio pacienteNegocio = new PacienteNegocio();

            try
            {
                if (!IsPostBack)
                {
                    bool cargarTodosPacientes = true;
                    limpiarCampos();
                    if (Session["usuario"] != null && esPaciente())
                    {
                        cargarTodosPacientes = false;
                        dominio.Usuario usuario = (dominio.Usuario)Session["usuario"];

                        // Verificar si el usuario no es admin ni recepcionista
                        if (usuario.TipoUsuario != dominio.TipoUsuario.RECEP &&
                            usuario.TipoUsuario != dominio.TipoUsuario.ADMIN)
                        {
                            txtFecha.ReadOnly = true;
                            txtHorario.ReadOnly = true;

                            List<Paciente> lista1Paciente = pacienteNegocio.listar(usuario.ID);
                            ddlPacientes.DataSource = lista1Paciente;
                            Paciente paciente = lista1Paciente.First();
                            Session.Add("paciente", paciente);
                            ddlPacientes.DataTextField = "Nombre";
                            ddlPacientes.DataValueField = "IDPaciente";
                            ddlPacientes.DataBind();
                            ddlPacientes.Enabled = false;
                        }
                    }

                    txtbEleccion.Text = $"-Dr/Dra | hs. ";

                    List<Medico> listaMedicos = medNegocio.listar();
                    //Session["listaMedicos"] = listaMedicos;
                    Session.Add("listaMedicos", listaMedicos);

                    if (cargarTodosPacientes)
                    {
                        List<Paciente> listaPacientes = pacienteNegocio.listar();
                        ddlPacientes.DataSource = listaPacientes;
                        ddlPacientes.DataTextField = "Nombre";
                        ddlPacientes.DataValueField = "IDPaciente";
                        ddlPacientes.DataBind();
                        Session.Add("listaPacientes", listaPacientes.ToList());
                    }

                    List<Especialidad> listaEspecialidades = negEspecialidad.listar();
                    ddlEspecialidades.DataSource = listaEspecialidades;
                    Session.Add("listaEspecialidades", listaEspecialidades);
                    ddlEspecialidades.DataTextField = "Nombre";
                    ddlEspecialidades.DataValueField = "IdEspecialidad";
                    ddlEspecialidades.DataBind();


                    cargarDgvTurnos(0, 0);

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void limpiarCampos()
        {
            ddlEspecialidades.Items.Clear();
            ddlMedicosFiltrados.Items.Clear();
            ddlPacientes.Items.Clear();
            txtFecha.Text = string.Empty;
            txtHorario.Text = string.Empty;

        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Medico> listaMedicosFiltrados = new List<Medico>();
            try
            {
                if (ddlEspecialidades.SelectedIndex == 0)
                {
                    cargarDgvTurnos(0, 0);
                    MedicoNegocio medicoNegocio = new MedicoNegocio();
                    ddlMedicosFiltrados.Items.Clear();
                    //ddlMedicosFiltrados.DataSource = medicoNegocio.listar();
                    //ddlMedicosFiltrados.DataBind();
                }
                else
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

                    // Limpiar DropDownList antes de agregar nuevos datos
                    //if (Session["estoyEligiendo"] != null)
                    //{
                    //ddlMedicosFiltrados.SelectedValue = Session["estoyEligiendo"].ToString();

                    //}
                    ddlMedicosFiltrados.Items.Clear();
                    ddlMedicosFiltrados.DataSource = listaMedicosFiltrados;
                    Session.Add("listaMedicosFiltrados", listaMedicosFiltrados.ToList());
                    ddlMedicosFiltrados.DataTextField = "apellido";
                    ddlMedicosFiltrados.DataValueField = "IdMedico";

                    ddlMedicosFiltrados.DataBind();


                    //VENGO DESDE EL EVENTO D EELEGIR QUE ME TIENE QUE ACTUALIZAR EL DDLMEDICOS
                    //if(ddlMedicosFiltrados.SelectedIndex != 0)
                    //{
                    //    ddlMedicosFiltrados.SelectedValue = ;
                    //}

                    int IDEspecialidad = int.Parse(ddlEspecialidades.SelectedItem.Value);
                    cargarDgvTurnos(0, IDEspecialidad);
                }
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

                    item.Text = $"{Medico.Nombre}  {Medico.Apellido}";
                }
            }
        }

        protected void ddlMedicosFiltrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var quetengo = sender.ToString();
                //VENGO DESDE EL EVENTO D EELEGIR QUE ME TIENE QUE ACTUALIZAR EL DDLMEDICOS Y TENGO QUE EVITAR LA LLAMADA A EVENTOS CIRCULAR, LA CUAL TENGO QUE CORTAR AQUI MISMO !!!
                if (sender.ToString() == "System.Web.UI.WebControls.GridView")
                {
                    int IDMedico = int.Parse(ddlMedicosFiltrados.SelectedItem.Value);
                    cargarDgvTurnos(IDMedico, 0);
                    //Session.Add("actionElegir", "click");
                    Session.Add("estoyEligiendo", ddlMedicosFiltrados.SelectedItem.Value.ToString());
                }
                else if (ddlMedicosFiltrados.SelectedItem.Value != "")
                {
                    int IDMedico = int.Parse(ddlMedicosFiltrados.SelectedItem.Value);
                    cargarDgvTurnos(IDMedico, 0);
                }
                else if (ddlMedicosFiltrados.Text.ToString() != "Seleccione una opción")
                {
                    dgvTurnos_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void cargarDgvTurnos(int IDMedico, int IDEspecialidad)
        {
            try
            {
                if (IDMedico != 0)
                {
                    Session.Add("IDMedico", IDMedico);
                    TurnoNegocio turnoNegocio = new TurnoNegocio();
                    List<Turno> listaTurnos = turnoNegocio.listar(IDMedico);
                    dgvTurnos.DataSource = listaTurnos;
                    dgvTurnos.DataBind();
                }
                else
                {
                    TurnoNegocio turnoNegocio = new TurnoNegocio();
                    List<Turno> listaTurnos = turnoNegocio.listar();
                    dgvTurnos.DataSource = listaTurnos;
                    dgvTurnos.DataBind();
                }

                if (IDEspecialidad != 0)
                {
                    TurnoNegocio turnoNegocio = new TurnoNegocio();
                    List<Turno> listaTurnos = turnoNegocio.listarPorEspecialidad(IDEspecialidad);
                    dgvTurnos.DataSource = listaTurnos;
                    dgvTurnos.DataBind();
                }

                if (IDMedico == 0 && IDEspecialidad == 0)
                {
                    TurnoNegocio turnoNegocio = new TurnoNegocio();
                    List<Turno> listaTurnos = turnoNegocio.listar();
                    dgvTurnos.DataSource = listaTurnos;
                    dgvTurnos.DataBind();
                }
                if (esPaciente())
                {
                    foreach (DataControlField column in dgvTurnos.Columns)
                    {
                        // Verificar si la columna es un CommandField y tiene el texto "Desasignar"
                        if (column is CommandField && ((CommandField)column).ShowSelectButton == true && ((CommandField)column).SelectText == "Desasignar")
                        {
                            // Ocultar la columna
                            column.Visible = false;
                            break; // Romper el bucle una vez que se haya encontrado y ocultado la columna
                        }
                    }
                    foreach (GridViewRow row in dgvTurnos.Rows)
                    {
                        Button btnAsignar = row.Cells[6].Controls[0] as Button;
                        var asignado = row.Cells[3].Text as string;
                        if (asignado == "Sin Asignar")
                        {
                            btnAsignar.Visible = true;
                        }
                        else
                        {
                            btnAsignar.Visible = false;
                        }
                    }
                    //OCULTAR BOTON CANCELAR SI NO ESTA ASIGNADO PARA ESTE PACIENTE
                    foreach (GridViewRow row in dgvTurnos.Rows)
                    {
                        Button btnCancelar = row.Cells[8].Controls[0] as Button;
                        var asignado = row.Cells[3].Text as string;
                        if (asignado == "Sin Asignar")
                        {
                            btnCancelar.Visible = false;
                        }
                        else
                        {
                            btnCancelar.Visible = true;
                        }
                    }
                    foreach (GridViewRow row in dgvTurnos.Rows)
                    {
                        if (row.Cells[3].Text != "Sin Asignar" && row.Cells[3].Text != ((((dominio.Paciente)Session["paciente"]).Nombre) + ", " + (((dominio.Paciente)Session["paciente"]).Apellido)))
                        {
                            row.Visible = false;
                        }
                    }
                }
                else
                {
                    // PARA OCULTAR LOS BOTONES SEGUN CORRESPONDA
                    foreach (GridViewRow row in dgvTurnos.Rows)
                    {
                        Button btnAsignar = row.Cells[6].Controls[0] as Button;
                        var asignado = row.Cells[3].Text as string;
                        if (asignado == "Sin Asignar")
                        {
                            btnAsignar.Visible = true;
                        }
                        else
                        {
                            btnAsignar.Visible = false;
                        }
                    }

                    foreach (GridViewRow row in dgvTurnos.Rows)
                    {
                        Button btnDesasignar = row.Cells[7].Controls[0] as Button;
                        var asignado = row.Cells[3].Text as string;
                        if (asignado == "Sin Asignar")
                        {
                            btnDesasignar.Visible = false;
                        }
                        else
                        {
                            btnDesasignar.Visible = true;
                        }
                    }
                    //OCULTAR COLUMNA CANCELAR SI NO ES PACIENTE
                    foreach (DataControlField column in dgvTurnos.Columns)
                    {
                        // Verificar si la columna es un CommandField y tiene el texto "Cancelar"
                        if (column is CommandField && ((CommandField)column).ShowSelectButton == true && ((CommandField)column).SelectText == "Cancelar")
                        {
                            // Ocultar la columna
                            column.Visible = false;
                            break; // Romper el bucle una vez que se haya encontrado y ocultado la columna
                        }
                    }
                    // FIN // PARA OCULTAR LOS BOTONES SEGUN CORRESPONDA
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "Error al generar lista de turnos.");
                lblError.Text = Session["error"].ToString();
            }
        }

        protected void ddlMedicosFiltrados_PreRender(object sender, EventArgs e)
        {
            // Agregar un ListItem en blanco si no hay elementos seleccionados
            if (!IsPostBack || ddlMedicosFiltrados.Items.Count == 0)
            {
                ddlMedicosFiltrados.Items.Insert(0, new ListItem("Seleccione una opción", ""));
            }
            //if (Session["actionElegir"] != null && Session["actionElegir"].ToString() == "click")
            //{
            //    //No hago nada, despues veo como actualizar el dgvTurnos
            //}
            else if (Session["listaMedicos"].ToString() != "" && ddlMedicosFiltrados.Items[0].Text != "Seleccione una opción" && ddlMedicosFiltrados.Items.Count >= 1)
            {
                ddlMedicosFiltrados.Items.Insert(0, new ListItem("Seleccione una opción", ""));
            }
            //if (ddlMedicosFiltrados.Items.Count > 2)
            //{
            //    ddlMedicosFiltrados.Items.Insert(0, new ListItem("Seleccione una opción", ""));
            //}
        }

        protected void ddlPacientes_DataBound(object sender, EventArgs e)
        {
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            List<Paciente> listaPacientes = pacienteNegocio.listar();
            foreach (ListItem item in ddlPacientes.Items)
            {
                int IDPaciente = Convert.ToInt32(item.Value);
                var Paciente = listaPacientes.FirstOrDefault(p => Convert.ToInt32(p.IDPaciente) == IDPaciente);
                if (Paciente != null)
                {
                    item.Text = $"{Paciente.Nombre} {Paciente.Apellido}";
                }
            }
        }

        protected void dgvTurnos_SelectedIndexChanged(object sender, EventArgs e) //POR ACA PASAN Y SE RENDERIZAN VARIAS COSAS, OJO CON LO QUE SE TOCA
        {
            GridViewRow row = dgvTurnos.SelectedRow;

            AccesoDatos datos = new AccesoDatos();
            bool bandera = false;
            try
            {
                string diaSemana = "";
                //var quesendertengo = sender.ToString();
                if (row != null && row.Cells[3].Text != "Sin Asignar")
                {
                    bandera = true;
                    int IDTurno = int.Parse(row.Cells[0].Text.ToString());

                    datos.setQuery("UPDATE TURNOS SET IDPaciente = NULL, Asignado = 0 WHERE IDTurno = @IDTurno");
                    datos.setearParametro("@IDTurno", IDTurno);
                    datos.ejecutarAccion();
                }
                if (sender.ToString() == "System.Web.UI.WebControls.GridView" && row.Cells[3].Text == "Sin Asignar")
                {
                    Label lblFecha = (Label)row.FindControl("lblFecha");
                    string fechaCompleta = lblFecha.Text;
                    string[] partesFecha = fechaCompleta.Split(new char[] { ',' }, 2, StringSplitOptions.RemoveEmptyEntries);

                    if (partesFecha.Length == 2)
                    {
                        diaSemana = partesFecha[0].Trim();
                        string fecha = partesFecha[1].Trim();

                        // Intentar parsear solo la fecha
                        DateTime _fecha;
                        if (DateTime.TryParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _fecha))
                        {
                            // Aquí _fecha contiene la fecha parseada correctamente
                            txtFecha.Text = _fecha.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            // Manejar el caso en que la cadena no pueda ser parseada como fecha
                            txtFecha.Text = "Fecha inválida";
                        }
                    }
                    else
                    {
                        // Manejar el caso donde la cadena no está en el formato esperado
                        txtFecha.Text = "Formato de fecha inválido";
                    }


                    //DateTime _fecha = DateTime.Parse(fecha);
                    //txtFecha.Text = _fecha.ToString("yyyy-MM-dd");

                    string hora = row.Cells[5].Text.ToString();
                    TimeSpan _hora = TimeSpan.Parse(hora.ToString());
                    txtHorario.Text = hora;

                    List<Medico> listaMedicos = (List<Medico>)Session["listaMedicos"];
                    var medico = listaMedicos.Find(med => (med.Nombre + ", " + med.Apellido) == row.Cells[1].Text.ToString());
                    ddlEspecialidades.SelectedValue = medico.IDEspecialidad.ToString();
                    ddlEspecialidades_SelectedIndexChanged(sender, e);

                    ddlMedicosFiltrados.SelectedValue = medico.IdMedico.ToString();
                    ddlMedicosFiltrados_SelectedIndexChanged(sender, e);

                    int IDTurno = Convert.ToInt32(row.Cells[0].Text.ToString());
                    Session.Add("IDTurno", IDTurno);

                    txtbEleccion.Text = $"{ddlPacientes.SelectedItem.Text} - " +
                            $"Dr/Dra. {row.Cells[1].Text.ToString()} - " + /*ddlMedicosFiltrados.SelectedItem.Text*/
                            $"| {diaSemana.ToString()}, " + $"{txtFecha.Text.ToString()}, " +
                            $"{hora.ToString().Substring(0, 5)}hs";
                }

                else
                {
                    string paciente = ddlPacientes.SelectedItem.Text;
                    if (paciente == "Seleccione una opción")
                    {
                        paciente = null;
                    }

                    string medico = ddlMedicosFiltrados.SelectedItem.Text;
                    if (medico == "Seleccione una opción")
                    {
                        medico = null;
                    }
                    //diaSemana = DateTime.Parse(txtFecha.Text.ToString()).DayOfWeek.ToString();
                    DateTime fecha = DateTime.Parse(txtFecha.Text);
                    diaSemana = fecha.ToString("dddd", new CultureInfo("es-ES"));
                    txtbEleccion.Text = $"{paciente} - " +
                        $"Drs. {medico} " +
                        $"| {diaSemana.ToString()}, " + $"{txtFecha.Text.ToString()}, " +
                        $"{txtHorario.Text.ToString()}hs.";
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
                if (bandera == true)
                {
                    Response.Redirect("Turnos.aspx");
                }
            }


        }

        protected void ddlPacientes_PreRender(object sender, EventArgs e)
        {
            //if (!IsPostBack || (Session["usuario"] != null && (((dominio.Usuario)(Session["usuario"])).TipoUsuario == TipoUsuario.ADMIN || ((dominio.Usuario)(Session["usuario"])).TipoUsuario == TipoUsuario.RECEP)))
            if (!IsPostBack && (Session["usuario"] != null && (esAdmin() || esRecepcionista())))
            {
                ddlPacientes.Items.Insert(0, new ListItem("Seleccione una opción", ""));
            }
            //if (!IsPostBack && (Session["usuario"] != null && ((dominio.Usuario)(Session["usuario"])).TipoUsuario == TipoUsuario.PACIENTE))
            //if (!IsPostBack && (Session["usuario"] != null && (esPaciente())))
            //{
            //    ddlPacientes.Items.RemoveAt(0);
            //}

        }
        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            if (txtFecha.Text != "")
                dgvTurnos_SelectedIndexChanged(sender, e);
        }

        protected void txtHorario_TextChanged(object sender, EventArgs e)
        {
            if (txtHorario.Text != "")
                dgvTurnos_SelectedIndexChanged(sender, e);
        }

        protected void ddlPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPacientes.Text.ToString() != "Seleccione una opción")
            {
                dgvTurnos_SelectedIndexChanged(sender, e);
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            //tengo que tomar los valores de todos los campos y parsearlos si es necesario () AH NO PARA
            // --> SOLO TOMO EL ID DEL PACIENTE Y DEL TURNO (celda grid de nro turno) y UPDATE SQL en tabla Turnos Where IDTurno = @IDTurno {setear parametro}
            AccesoDatos datos = new AccesoDatos();
            //bool bandera = false;
            try
            {
                if (ddlPacientes.SelectedItem.Value != "" && Session["IDTurno"] != null)
                {
                    //bandera = true;
                    int IDPaciente = Convert.ToInt32(ddlPacientes.SelectedItem.Value);
                    int IDTurno = int.Parse(Session["IDTurno"].ToString());

                    datos.setQuery("UPDATE TURNOS SET IDPaciente = @IDPaciente, Asignado = 1 WHERE IDTurno = @IDTurno");
                    datos.setearParametro("@IDPaciente", IDPaciente);
                    datos.setearParametro("@IDTurno", IDTurno);
                    datos.ejecutarAccion();
                    Response.Redirect("Turnos.aspx");
                }
                //if (esRecepcionista() || esAdmin())
                {
                    int IDPaciente = Convert.ToInt32(ddlPacientes.SelectedItem.Value);
                    int IDMedico = Convert.ToInt32(ddlMedicosFiltrados.SelectedItem.Value);
                    DateTime Fecha = DateTime.Parse(txtFecha.Text.ToString());
                    TimeSpan Hora = TimeSpan.Parse(txtHorario.Text.ToString());

                    datos.setQuery("insert into Turnos (IDPaciente, IDMedico, Fecha, Hora, Estado, Asignado) values (@IDPaciente, @IDMedico, @Fecha, @Hora, 1, 1)");
                    datos.setearParametro("@IDPaciente", IDPaciente);
                    datos.setearParametro("@IDMedico", IDMedico);
                    datos.setearParametro("@Fecha", Fecha);
                    datos.setearParametro("@Hora", Hora);
                    datos.ejecutarAccion();
                    Response.Redirect("Turnos.aspx", false);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
                //if (!bandera)
                //    Response.Redirect("Turnos.aspx");
            }
        }

        private bool VerSiEstaAsignado(int IDTurno)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("select Asignado from Turnos where IDTurno = @IDTurno");
                datos.setearParametro("@IDTurno", IDTurno);
                datos.leer();
                while (datos.Reader.Read())
                {
                    var quetengo = datos.Reader["Asignado"].ToString();
                    if (quetengo == "True")
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void ddlEspecialidades_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack || ddlEspecialidades.Items.Count == 0)
            {
                ddlEspecialidades.Items.Insert(0, new ListItem("Seleccione una opción", ""));
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

        //protected void dgvTurnos_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    // Obtenemos los datos actuales del GridView
        //    TurnoNegocio turnoNegocio = new TurnoNegocio();
        //    DataTable dt = ConvertirListaATable(turnoNegocio.listar()); // Implementa este método para obtener tus datos

        //    if (dt != null)
        //    {
        //        // Aplicamos la ordenación
        //        dt.DefaultView.Sort = e.SortExpression + " " + ObtenerDireccionOrden(e.SortExpression);
        //        dgvTurnos.DataSource = dt;
        //        dgvTurnos.DataBind();
        //    }
        //}

        //private DataTable ConvertirListaATable(List<Turno> turnos)
        //{
        //    DataTable dt = new DataTable();

        //    // Definimos las columnas del DataTable
        //    dt.Columns.Add("IDTurno", typeof(int)); // Ajusta los tipos de datos según corresponda
        //    dt.Columns.Add("Medico.Nombre", typeof(string)); // Ejemplo: Medico.Nombre
        //    dt.Columns.Add("Especialidad.Nombre", typeof(string)); // Ejemplo: Especialidad.Nombre
        //    dt.Columns.Add("Paciente.Nombre", typeof(string)); // Ejemplo: Paciente.Nombre
        //    dt.Columns.Add("Fecha", typeof(DateTime)); // Ajusta el tipo de dato de la fecha
        //    dt.Columns.Add("HoraInicio", typeof(string)); // Ajusta el tipo de dato de la hora

        //    // Llenamos el DataTable con los datos de la lista de Turno
        //    foreach (var turno in turnos)
        //    {
        //        DataRow row = dt.NewRow();
        //        row["IDTurno"] = turno.IdTurno;
        //        row["Medico.Nombre"] = turno.medico.Nombre;
        //        row["Especialidad.Nombre"] = turno.especialidad.Nombre;
        //        row["Paciente.Nombre"] = turno.paciente.Nombre;
        //        row["Fecha"] = turno.Fecha; // Ajusta según el formato de fecha que necesites
        //        row["HoraInicio"] = turno.HoraInicio;
        //        dt.Rows.Add(row);
        //    }

        //    return dt;
        //}

        //private string ObtenerDireccionOrden(string columna)
        //{
        //    // Establecer la dirección de la ordenación ascendente o descendente
        //    string direccion = "DESC"; // ASC o DESC según tu lógica de ordenación
        //    return direccion;
        //}

    }
}