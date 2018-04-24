using Compiladores.Semântico.Acoes_Semanticas;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action12 : IAction
    {
        public void execute(Token token)
        {
            Semantico.GetInstance().codigoGerado.AppendLine(".locals( int64 TOPO__BAIXO, int64 TOPO__ALTO)");
            Semantico.GetInstance().OperadorRelacional = token.Lexeme.Trim();
            Semantico.GetInstance().codigoGerado.AppendLine("dup");
            Semantico.GetInstance().codigoGerado.AppendLine("stloc TOPO__BAIXO");
        }
    }
}
