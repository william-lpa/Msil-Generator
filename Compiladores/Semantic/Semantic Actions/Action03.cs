﻿using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action03 : IAction
    {
        public void execute(Token token)
        {
            /*
            tipo1:= pilha.desempilha
            tipo2:= pilha.desempilha
            se (tipo1=float64) ou (tipo2=float64)
            então pilha.empilha (float64)
            senão pilha.empilha (int64)
            código.adiciona (mul) 
           */
            TpTipo tipo1 = Semantico.GetInstance().pilha_de_tipos.Pop();
            TpTipo tipo2 = Semantico.GetInstance().pilha_de_tipos.Pop();

            if (tipo1.ehIdentificador())
                Semantico.GetInstance().pilha_de_identificadores.Pop();
            if (tipo2.ehIdentificador())
                Semantico.GetInstance().pilha_de_identificadores.Pop();

            if (tipo1 is TpInteger && tipo2 is TpInteger)
                Semantico.GetInstance().pilha_de_tipos.Push(new TpInteger(false));
            else if (tipo1 is TpFloat && tipo2 is TpFloat)
                Semantico.GetInstance().pilha_de_tipos.Push(new TpFloat(false));
            else if (tipo1 is TpFloat && tipo2 is TpInteger)
                Semantico.GetInstance().pilha_de_tipos.Push(new TpFloat(false));
            else if (tipo1 is TpInteger && tipo2 is TpFloat)
                Semantico.GetInstance().pilha_de_tipos.Push(new TpFloat(false));
            else
                throw new SemanticError("Erro na linha " + token.Position + " - Tipos inválidos no operador de multiplicação (*)");

            Semantico.GetInstance().codigoGerado.AppendLine("mul");
        }
    }
}
