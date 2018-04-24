using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action37 : IAction
    {
        /*
        * Operação com caracter
        */
        public void execute(Token token)
        {
            Semantico.GetInstance().pilha_de_tipos.Push(new TpCaracter(false));
            switch (token.Lexeme) 
            {
                case "\\space":
                    {
                        Semantico.GetInstance().codigoGerado.AppendLine("ldstr " + "\" \"");
                    }
                    break;
                case "\\newline":
                    {
                        Semantico.GetInstance().codigoGerado.AppendLine("ldstr " + "\"\n\"");
                    }
                    break;
                case "\\tab":
                    {
                        Semantico.GetInstance().codigoGerado.AppendLine("ldstr " + "\"\t\"");
                    }
                    break; ;
            }

            //Semantico.GetInstance().codigoGerado.AppendLine("ldstr " + token.Lexeme);
        }
    }
}
