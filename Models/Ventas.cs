using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jean_P2_AP2.Models
{
    public class Ventas
    {
        [Key]
        public int VentaID { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteID { get; set; }
        public double Monto { get; set; }
        public double Balance { get; set; }
    }
}
