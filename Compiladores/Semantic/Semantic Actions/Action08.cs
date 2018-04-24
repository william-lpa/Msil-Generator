using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action08 : IAction
    {
        public void execute(Token token)
        {

            //tipo:= pilha.desempilha
            //se (tipo=int) ou (tipo=float)
            //então pilha.empilha (tipo) 
            //senão erro semântico, parar
            //código.adiciona (ldc.i8 -1)
            //código.adiciona (mul)

            var tipo = Semantico.GetInstance().pilha_de_tipos.Pop();

            if (tipo is TpFloat || tipo is TpInteger)
            {
                Semantico.GetInstance().pilha_de_tipos.Push(tipo);
            }
            else
            {
                throw new SemanticError("Erro na linha " + token.Position + " - Tipos incompatível. Esperado Integer, Float, encontrado " + tipo.ToString());
            }

            Semantico.GetInstance().codigoGerado.AppendLine("ldc.i8 -1").AppendLine("mul");
        }
    }
}
