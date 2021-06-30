using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jean_P2_AP2.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteID { get; set; }
        public string Nombres { get; set; }

        [ForeignKey("ClienteID")]
        public List<Ventas> Ventas { get; set; } = new List<Ventas>();
    }
}
