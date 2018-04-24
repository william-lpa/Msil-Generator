using Compiladores.Semântico.Acoes_Semanticas;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action25 : IAction
    {
        public void execute(Token token)
        {
            string id = Semantico.GetInstance().pilha_de_identificadores.Pop();
            if (Semantico.GetInstance().tabelaSimbolos.ContainsKey(id /*token.Lexeme*/) && Semantico.GetInstance().tabelaSimbolos[id/*token.Lexeme*/].variavelDeclarada)
            {
                if (Semantico.GetInstance().OperadorAtbr == "+=") 
                {
                    Semantico.GetInstance().codigoGerado.AppendLine("add");
                }
                else if (Semantico.GetInstance().OperadorAtbr == "-=") 
                {
                    Semantico.GetInstance().codigoGerado.AppendLine("sub");
                }
                Semantico.GetInstance().codigoGerado.AppendLine("stloc " + id);
            }
            else
            {
                throw new SemanticError("Erro na linha " + token.Position + " - identificador (" + id + ") não declarado.");
            }
            
        }
    }
}
