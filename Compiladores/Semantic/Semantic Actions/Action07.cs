using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action07 : IAction
    {
        public void execute(Token token)
        {
            //  tipo:= pilha.desempilha
            //  se (tipo=int) ou (tipo=float)
            //então pilha.empilha (tipo) 
            //senão erro semântico, parar

            var tipo = Semantico.GetInstance().pilha_de_tipos.Pop();

            if (tipo is TpFloat || tipo is TpInteger)
            {
                Semantico.GetInstance().pilha_de_tipos.Push(tipo);
            }
            else
            {
                throw new SemanticError("Erro na linha " + token.Position + " - Tipos incompatível. Esperado Integer, Float, encontrado " + tipo.ToString());
            }
        }
    }
}
