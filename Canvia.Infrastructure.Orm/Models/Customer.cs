using System;
using System.Collections.Generic;
using System.Text;

namespace Canvia.Infrastructure.Orm.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cps = new HashSet<Cp>();
        }
        public Int32 PKID { set; get; }
        public string Codigo { set; get; }
        public string DocIdentidad { set; get; }
        public string Email { set; get; }
        public string Apellidos { set; get; }
        public string Nombres { set; get; }
        public bool Activo { set; get; }
        public virtual ICollection<Cp> Cps { get; set; }
    }
}
