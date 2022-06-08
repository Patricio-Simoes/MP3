using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula10
{
    public class ModelBateria : IBateria
    {
        public int Carga { get; set; }

        public event MetodosComInt CargaAlterada;

        public void Carregar()
        {
            if (Carga < 100)
            {
                Carga += 10;

                if (CargaAlterada != null)
                    CargaAlterada(Carga);
            }
            else
                throw new OperacaoInvalidaException("Foi atingido o limite máximo de carga!");
        }

        public void Descarregar()
        {
            if (Carga > 0)
            {
                Carga -= 10;

                if (CargaAlterada != null)
                    CargaAlterada(Carga);
            }
            else
                throw new OperacaoInvalidaException("Foi atingido o limite mínimo de carga!");
        }
    }
}
