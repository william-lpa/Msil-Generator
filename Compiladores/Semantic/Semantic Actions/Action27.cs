using Compiladores.Semântico.Acoes_Semanticas;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action27 : IAction
    {
        public void execute(Token token)
        {
            if(!Semantico.GetInstance().validaTipoValor(token.Lexeme))
            throw new SemanticError("Erro na linha " + token.Position + " - tipos incompativeis em comando de atribuição");
        }
    }
}
