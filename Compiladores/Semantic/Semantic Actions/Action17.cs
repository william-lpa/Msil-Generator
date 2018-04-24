using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action17 : IAction
    {
        public void execute(Token token)
        {
          /*
             ação #17:
             tipo:= pilha.desempilha
             código.adiciona (call void [mscorlib]System.Console::Write(tipo))
             */
            TpTipo tipo = Semantico.GetInstance().pilha_de_tipos.Pop();
            Semantico.GetInstance().codigoGerado.AppendLine("call void [mscorlib]System.Console::Write(" + tipo + ")");
        }


       
    }
}
