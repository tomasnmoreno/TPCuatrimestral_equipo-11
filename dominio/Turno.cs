using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Turno
    {
        public Int64 IdTurno { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int Estado { get; set; }
        //public Estado EstadoTurno { get; set; }
        public bool Asignado { get; set; }

        // PARA dgvturnos //
        public Medico medico { get; set; }
        public Paciente paciente { get; set; }
        public Especialidad especialidad  { get; set; }
    }
}
