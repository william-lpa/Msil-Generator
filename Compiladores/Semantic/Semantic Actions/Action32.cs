using Compiladores.Semântico.Acoes_Semanticas;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action32 : IAction
    {
        public void execute(Token token)
        {
            string rotulo = Semantico.GetInstance().geraRotulo();
            Semantico.GetInstance().codigoGerado.AppendLine("br " + rotulo);
            Semantico.GetInstance().codigoGerado.AppendLine(Semantico.GetInstance().rotuloElse.Pop() + ":");
            Semantico.GetInstance().rotuloElse.Push(rotulo);
        }
    }
}
