using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_7.Models
{
    public class Garagem
    {
        public List<Ligeiro> listaLigeiros { get; private set; }
        public List<Pesado> listaPesados { get; private set; }
        public List<Veículo> listaVeículos { get; private set; }

        public Garagem()
        {
            this.listaLigeiros = new List<Ligeiro>();
            this.listaPesados = new List<Pesado>();
            this.listaVeículos = new List<Veículo>();
        }
        public Garagem( List<Ligeiro> listaLigeiros, List<Pesado> listaPesados, List<Veículo> listaVeículos)
        {
            this.listaLigeiros = listaLigeiros;
            this.listaPesados = listaPesados;
            this.listaVeículos = listaVeículos;
        }
        public void Estaciona(Veículo v)
        {
            if (v.lotacao > 9)
                this.listaPesados.Add((Pesado)v);
            else
                this.listaLigeiros.Add((Ligeiro)v);
        }
    }
}
