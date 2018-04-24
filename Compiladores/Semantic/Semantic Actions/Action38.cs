using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action38 : IAction
    {
        public void execute(Token token)
        {
            Semantico.GetInstance().pilha_de_tipos.Push(new TpString(false));
            Semantico.GetInstance().codigoGerado.AppendLine("ldstr " + token.Lexeme);
        }
    }
}
