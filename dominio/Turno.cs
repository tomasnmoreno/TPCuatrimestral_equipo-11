using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Turno
    {
        public int IdTurno { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public DateTime FechaHoraTurno { get; set; }
        public string Observaciones { get; set; }
        public Estado EstadoTurno { get; set; }
    }
}
