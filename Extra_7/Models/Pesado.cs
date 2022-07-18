using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_7.Models
{
    public class Pesado : Veículo
    {
        public int numero_eixos { get; set; }

        public Pesado()
        {
            numero_eixos = 0;
        }
        public Pesado(int numero_eixos)
        {
            this.numero_eixos = numero_eixos;
        }
    }
}
