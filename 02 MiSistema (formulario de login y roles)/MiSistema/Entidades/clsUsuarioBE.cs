using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSistema.Entidades
{
    public class clsUsuarioBE
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Salt { get; set; }
    }
}
