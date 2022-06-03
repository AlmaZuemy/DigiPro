using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public decimal Costo { get; set; }
        public List<object> Materias { get; set; }
    }
}