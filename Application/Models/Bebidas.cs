using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Bebidas
    {
        [Key]
        public int IdBebida { get; set; }
        public string NombreBebida { get; set; }
        public decimal PrecioBebida { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public bool ActivoBebida { get; set; }
    }
}
