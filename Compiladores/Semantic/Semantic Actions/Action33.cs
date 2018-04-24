using Compiladores.Semântico.Acoes_Semanticas;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action33 : IAction
    {
        public void execute(Token token)
        {
            string rotulo = Semantico.GetInstance().gerarNovoRotuloRepeticao();
            Semantico.GetInstance().codigoGerado.AppendLine("brfalse " + rotulo);
            
        }
    }
}
