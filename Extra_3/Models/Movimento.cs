using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_3.Models
{
    public class Movimento
    {
        private double quantia { get; set; }
        private string descrição { get; set; }
        private string data { get; set; }

        public Movimento(double quantia, string descrição, string data)
        {
            this.quantia = quantia;
            this.descrição = descrição;
            this.data = data;
        }
        public double getQuantia() { return this.quantia; }
        public string getData() { return this.data; }
        public string getDescrição() { return this.descrição; }
    }
}
