using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula10
{
    public interface IBateria
    {
        //Propriedades
        int Carga
        {
            get;
            set;
        }

        //Métodos
        void Carregar();
        void Descarregar();

        //Eventos
        event MetodosComInt CargaAlterada;
    }
}
