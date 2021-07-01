using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jean_P2_AP2.Models
{
    public class Cobros
    {
        [Key]
        public int CobroID { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Seleccione un cliente")]
        public int ClienteID { get; set; }
        public string Observaciones { get; set; }

        [ForeignKey("CobroID")]
        public List<CobrosDetalle> Detalle { get; set; } = new List<CobrosDetalle>();
    }

    public class CobrosDetalle
    {
        [Key]
        public int CobroDetalleID { get; set; }
        public int CobroID { get; set; }
        public int VentaID { get; set; }
        public float Cobrado { get; set; }
    }
}
