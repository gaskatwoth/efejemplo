using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf.MiBd
{
    public class Empleado
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int sueldo { get; set; }
        public virtual int DepartamentoId { get; set; }
    }
}
