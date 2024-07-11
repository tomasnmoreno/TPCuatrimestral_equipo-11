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
    public partial class ModificarEstado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            int idTurno = Convert.ToInt32(Session["IdTurno"]);
            int IdEstado = Convert.ToInt32(ddlEstados.SelectedItem.Value.ToString());
            string observacion = txtObservaciones.Text;
            datos.setQuery("UPDATE TURNOS SET Estado = @IdEstado, Observacion = @observacion WHERE IDTurno = @IDTurno");
            datos.setearParametro("@IDTurno", idTurno);
            datos.setearParametro("IdEstado", IdEstado);
            datos.setearParametro("Observacion", observacion);
            datos.ejecutarAccion();
            Response.Redirect("MisTurnos.aspx");
        }
    }
}