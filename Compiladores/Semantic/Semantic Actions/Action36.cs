using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action36 : IAction
    {
        public void execute(Token token)
        {
            /*
            * Faz a comparacao OR
            */
            TpTipo tipo1 = Semantico.GetInstance().pilha_de_tipos.Pop();
            TpTipo tipo2 = Semantico.GetInstance().pilha_de_tipos.Pop();

            if (tipo1.ehIdentificador())
                Semantico.GetInstance().pilha_de_identificadores.Pop();
            if (tipo2.ehIdentificador())
                Semantico.GetInstance().pilha_de_identificadores.Pop();

            if (!(tipo1 is TpBoolean) || !(tipo2 is TpBoolean))
            {
                throw new SemanticError("Erro na linha " + token.Position + " - Tipos incompatível ao realizar a comparação (OR)");
            }
            Semantico.GetInstance().codigoGerado.AppendLine("or");

            Semantico.GetInstance().pilha_de_tipos.Push(new TpBoolean(false));
        }
    }
}
