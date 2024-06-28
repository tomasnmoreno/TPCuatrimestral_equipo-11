using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Recepcionista:Persona
    {
        public int IDRecepcionista {  get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
    }
}
