using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action06 : IAction
    {
        public void execute(Token token)
        {
            /*
            ação #6:
            pilha.empilha (float64)
            código.adiciona(ldc.r8 token.getLexeme) 
            */
            Semantico.GetInstance().pilha_de_tipos.Push(new TpFloat(false));
            Semantico.GetInstance().codigoGerado.AppendLine("ldc.r8 " + token.Lexeme);
        }
    }
}
