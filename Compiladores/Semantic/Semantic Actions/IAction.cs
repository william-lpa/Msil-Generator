using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores.Semântico.Acoes_Semanticas
{
    interface IAction
    {
        void execute(Token token);
    }
}
