using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantWebAPI.Entities
{
    public class Platillo
    {
        public long EmpresaPkId { get; set; }
        [Key]
        public long PlatilloPkId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        //public byte[] Foto { get; set; }
        public string FotoUrl { get; set; }
        public bool Activo { get; set; }
    }
}
