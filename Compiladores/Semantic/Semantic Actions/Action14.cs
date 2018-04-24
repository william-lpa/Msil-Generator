using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action14 : IAction
    {
        public void execute(Token token)
        {
            /*
            pilha.empilha(bool)
            código.adiciona (ldc.i4.1)
            */
            Semantico.GetInstance().pilha_de_tipos.Push(new TpBoolean(false));
            Semantico.GetInstance().codigoGerado.AppendLine("ldc.i4.1");
        }
    }
}
