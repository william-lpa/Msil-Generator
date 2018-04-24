using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores.Tipo
{
    public class TpTipo
    {
        private bool identificador = false;

        public TpTipo(bool identificador)
        {
            this.identificador = identificador;
        }

        public bool ehIdentificador()
        {
            return this.identificador;
        }

        public void setEhIdentificador(bool ehIdentificador)
        {
            this.identificador = ehIdentificador;
        }
    }
}
