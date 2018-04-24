using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action04 : IAction
    {
        public void execute(Token token)
        {
            /*
            tipo1:= pilha.desempilha
           tipo2:= pilha.desempilha
           se (tipo1=tipo2)
           então pilha.empilha (tipo1)
           senão erro semântico, halt
           código.adiciona (div)
            */
            TpTipo tipo1 = Semantico.GetInstance().pilha_de_tipos.Pop();
            TpTipo tipo2 = Semantico.GetInstance().pilha_de_tipos.Pop();

            if (tipo1.ehIdentificador())
                Semantico.GetInstance().pilha_de_identificadores.Pop();
            if (tipo2.ehIdentificador())
                Semantico.GetInstance().pilha_de_identificadores.Pop();

            if (tipo1 is TpInteger && tipo2 is TpInteger)
                Semantico.GetInstance().pilha_de_tipos.Push(new TpFloat(false));
           else if (tipo1 is TpFloat && tipo2 is TpFloat)
                Semantico.GetInstance().pilha_de_tipos.Push(new TpFloat(false));
            else if (tipo1 is TpFloat && tipo2 is TpInteger)
                Semantico.GetInstance().pilha_de_tipos.Push(new TpFloat(false));
            else if (tipo1 is TpInteger && tipo2 is TpFloat)
                Semantico.GetInstance().pilha_de_tipos.Push(new TpFloat(false));
            else
                throw new SemanticError("Erro na linha " + token.Position + " - Tipos inválidos no operador de divição (/)");

            Semantico.GetInstance().codigoGerado.AppendLine("div");
        }
    }
}
