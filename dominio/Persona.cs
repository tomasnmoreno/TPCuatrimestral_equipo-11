using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Persona
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Domicilio { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }

        public bool Estado { get; set; }
    }
}
