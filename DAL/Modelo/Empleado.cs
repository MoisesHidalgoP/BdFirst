using System;
using System.Collections.Generic;

namespace DAL.Modelo
{
    public partial class Empleado
    {
        public Empleado()
        {
            NivelAccesos = new HashSet<NivelAcceso>();
        }

        public int Id { get; set; }
        public string NombreEmpleado { get; set; } = null!;

        public virtual ICollection<NivelAcceso> NivelAccesos { get; set; }
    }
}
