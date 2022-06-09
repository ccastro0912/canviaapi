using System;
using System.Collections.Generic;
using System.Text;

namespace Canvia.Infrastructure.Orm.Models
{
    public class ItemCp
    {
        public int PKID { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public int? IdProduct { get; set; }
        public int? IdCp { get; set; }
        public virtual Product IdProductNavigation { get; set; }
        public virtual Cp IdCpNavigation { get; set; }
    }
}
