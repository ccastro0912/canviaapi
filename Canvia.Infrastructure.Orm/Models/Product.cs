using System;
using System.Collections.Generic;
using System.Text;

namespace Canvia.Infrastructure.Orm.Models
{
    public class Product
    {
        public Product()
        {
            ItemCps = new HashSet<ItemCp>();
        }
        public int PKID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }
        public virtual ICollection<ItemCp> ItemCps { get; set; }
    }
}
