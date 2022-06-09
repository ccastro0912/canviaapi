using System;
using System.Collections.Generic;
using System.Text;

namespace Canvia.Infrastructure.Orm.Models
{
    public class Cp
    {
        public Cp()
        {
            ItemCps = new HashSet<ItemCp>();
        }

        public int PKID { get; set; }
        public string NumCp { get; set; }
        public int? IdCustomer { get; set; }
        public string Moneda { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Decimal Total { get; set; }
        public Decimal SubTotal { get; set; }        
        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual ICollection<ItemCp> ItemCps { get; set; }
    }
}
