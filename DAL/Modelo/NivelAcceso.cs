using System;
using System.Collections.Generic;

namespace DAL.Modelo
{
    public partial class NivelAcceso
    {
        public NivelAcceso()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string NivelAcceso1 { get; set; } = null!;
        public string DescAcceso { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
