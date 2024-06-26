using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Medico:Persona
    {
        public string IdMedico { get; set; }
        public int Matricula { get; set; }
        public string Usuario { get; set; }
        public string Contraseña {  get; set; }       

    }
}
