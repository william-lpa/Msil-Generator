using Compiladores.Semântico.Acoes_Semanticas;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action31 : IAction
    {
        public void execute(Token token)
        {
            Semantico.GetInstance().codigoGerado.AppendLine(Semantico.GetInstance().rotuloElse.Pop() + ":");
        }
    }
}
