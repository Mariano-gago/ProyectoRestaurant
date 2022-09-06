using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Empleados
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado {get; set;}


        [ForeignKey("Roles")]
        public int Rol_Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }

        public int? Codigo { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
