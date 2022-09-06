using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Entradas
    {
        [Key]
        public int IdEntrada { get; set; }
        public string NombreEntrada { get; set; }
        public decimal PrecioEntrada { get; set; }
        public string ImagenEntrada { get; set; }
        public bool ActivoEntrada { get; set; }
    }
}
