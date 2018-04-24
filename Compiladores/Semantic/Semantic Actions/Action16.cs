using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action16 : IAction
    {
        public void execute(Token token)
        {
            /*              
              tipo:= pilha.desempilha
              se(tipo=bool)
              então pilha.empilha (bool)
              senão erro semântico: tipo incompatível no operador not, halt
              código.adiciona (ldc.i4.1)
              código.adiciona (xor) 
              */
            TpTipo tipo = Semantico.GetInstance().pilha_de_tipos.Pop();

            if (tipo.ehIdentificador())
                Semantico.GetInstance().pilha_de_identificadores.Pop();

            if (tipo is TpBoolean)
            {
                Semantico.GetInstance().pilha_de_tipos.Push(new TpBoolean(false));
            }
            else
            {
                throw new SemanticError("Erro na linha " + token.Position + " - Tipos incompatível no operador not");
            }
            Semantico.GetInstance().codigoGerado.AppendLine("ldc.i4.1").AppendLine("xor");
        }
    }
}
