using Compiladores.Semântico.Acoes_Semanticas;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action28 : IAction
    {
        public void execute(Token token)
        {
            Semantico.GetInstance().OperadorAtbr = token.Lexeme.Trim();
            if (Semantico.GetInstance().OperadorAtbr == "+=" || Semantico.GetInstance().OperadorAtbr == "-=") 
            {
                string id= Semantico.GetInstance().pilha_de_identificadores.First();
                Semantico.GetInstance().codigoGerado.AppendLine("ldloc " + id);
            }
        }
    }
}
