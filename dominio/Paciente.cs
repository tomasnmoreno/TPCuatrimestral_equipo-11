using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Paciente:Persona
    {
        public string IdPaciente { get; set; }
        public List <string> HistorialTurnos { get; }
    }
}
