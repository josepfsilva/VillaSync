using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaSync
{
    internal class Contrato
    {
        public int ID { get; set; }
        public int Valor { get; set; }
        public int Id_cliente { get; set; }
        public int Id_propridade { get; set; }
        public int Id_visita { get; set; }
    }
}
