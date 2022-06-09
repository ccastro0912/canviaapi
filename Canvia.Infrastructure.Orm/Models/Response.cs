using System;
using System.Collections.Generic;
using System.Text;

namespace Canvia.Infrastructure.Orm.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Mensaje { get; set; }
        public bool Success { get; set; }
        public Error Excepcion { get; set; }
    }
    public class Error
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
    }
}
