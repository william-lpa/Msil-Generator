using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action05 : IAction
    {
        public void execute(Token token)
        {
            /*
                pilha.empilha (int64)
                código.adiciona(ldc.i8 token.getLexeme)
             */
        
            Semantico.GetInstance().pilha_de_tipos.Push(new TpInteger(false));
            Semantico.GetInstance().codigoGerado.AppendLine("ldc.i8 " + token.Lexeme);
            
            
        }
    }
}
