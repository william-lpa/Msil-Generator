﻿using Compiladores.Semântico.Acoes_Semanticas;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action21 : IAction
    {
        /*
          * Ação para adicionar o identificador na tabela de identificadores 
          */
        public void execute(Token token)
        {
            String id = token.Lexeme;
            Semantico.GetInstance().identificadores.Add(id);
            Semantico.GetInstance().pilha_de_identificadores.Push(id);
            // verificar se a tabela de simbolos está nula, para depois adicionar os elementos
            if (Semantico.GetInstance().tabelaSimbolos != null)
            {
                if (!Semantico.GetInstance().tabelaSimbolos.ContainsKey(id))
                {
                    Semantico.GetInstance().tabelaSimbolos.Add(id, new Sintatico.Semantico.ItensTabela());
                }
                else 
                {
              //    throw new SemanticError("Erro na linha " + token.Position + " - identificador (" + id + ") já declarado");
                }
            }

            

        }
    }
}
