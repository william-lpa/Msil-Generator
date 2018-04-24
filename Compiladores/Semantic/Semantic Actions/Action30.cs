using Compiladores.Semântico.Acoes_Semanticas;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action30 : IAction
    {
        public void execute(Token token)
        {

            var rotulo = Semantico.GetInstance().geraRotulo();
            if(token.Lexeme=="ifTrue")
                Semantico.GetInstance().codigoGerado.AppendLine("brfalse " + rotulo);
            else
                Semantico.GetInstance().codigoGerado.AppendLine("brtrue " + rotulo);
            Semantico.GetInstance().rotuloElse.Push(rotulo);
            Semantico.GetInstance().codigoGerado.Replace(Semantico.GetInstance().rotuloWhileGerado,"");
        }
    }
}
