using Compiladores.Semântico.Acoes_Semanticas;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action29 : IAction
    {
        public void execute(Token token)
        {

            /*
             * Função que inicia o "do", laco de repetição
             * Então é criado um rotulo
             */

            string rotulo = Semantico.GetInstance().gerarNovoRotuloRepeticao();
            Semantico.GetInstance().codigoGerado.AppendLine(rotulo + ": ");
            Semantico.GetInstance().rotuloWhileGerado = rotulo + ": ";

            
        }
    }
}
