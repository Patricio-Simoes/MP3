using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_7.Models
{
    public class Veículo
    {
        public int lotacao { get; private set; }
        public string matricula { get; private set; }
    
        public Veículo()
        {
            this.lotacao = 0;
            this.matricula = "XX-XX-XX";
        }
        public Veículo(int lotacao, string matricula)
        {
            this.lotacao = lotacao;
            this.matricula = matricula;
        }
    }
}
