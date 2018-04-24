using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action22 : IAction
    {
        public void execute(Token token)
        {
            Semantico.GetInstance().tipoIdentificador = token.Lexeme.Trim();
            
        }
    }
}
