using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio7_prueba2_
{
    class Propietario
    {
        public string Dpi { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
    class Propiedad
    {
        public string NoCasa { get; set; }
        public string DpiOwner { get; set; }
        public string CuotaMantenimiento { get; set; }
    }
    class Total
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NoHouse { get; set; }
        public string PaySuport { get; set; }
    }
}
