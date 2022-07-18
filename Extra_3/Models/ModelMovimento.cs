using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_3.Models
{
    // Criar Delegate
    // Em resumo, um delegate <=> Pointer para uma função, permite alterar outras janelas em tempo real

    public delegate void insereMovimento(Movimento movimento);
    public class ModelMovimento
    {
        // Guarda os dados numa lista do tipo Movimento
        public List<Movimento> Movimentos { get; private set; }
        // Guarda o saldo disponível
        public double saldo = 0;

        // Cria um evento associado ao delegate

        public event insereMovimento movimentoInserido;
        public ModelMovimento()
        {
            // Inicializa a lista quando a app é ligada (quando começa o debugging)
            Movimentos = new List<Movimento>();
        }
        public bool inserir(Movimento M, string tipo)
        {
            if (tipo == "Levantamento")
            {
                if (M.getQuantia() > saldo)
                {
                    return false;
                }
                // Atualiza o saldo
                saldo -= M.getQuantia();
            }
            // (Não há restrições para um depósito)
            else if (tipo == "Depósito")
            {
                // Atualiza o saldo
                saldo += M.getQuantia();
            }

            // Insere na lista de movimentos um movimento. (Vai ser chamada ao carregar no botão de registo)
            Movimentos.Add(M);

            // Lançar eventos

            if (movimentoInserido != null)
                movimentoInserido(M);

            return true;
        }
    }
}