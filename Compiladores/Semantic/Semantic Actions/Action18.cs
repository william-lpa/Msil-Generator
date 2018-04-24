using Compiladores.Semântico.Acoes_Semanticas;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action18 : IAction
    {
        public void execute(Token token)
        {
            /*
            ação #15:
                código.adiciona ( .assembly extern mscorlib {}
               .assembly filename() {}
               .module filename().exe

               .class public filename() {
                ) 
            */
            Semantico.GetInstance().codigoGerado
                .AppendLine(".assembly extern mscorlib {}")
                .AppendLine(".assembly " + Semantico.GetInstance().NomeArq + "{}")
                .AppendLine(".module " + Semantico.GetInstance().NomeArq + ".exe")
                .AppendLine(".class public " + Semantico.GetInstance().NomeArq + "{")
                .AppendLine(".method static public void _principal() { .entrypoint");
        }
    }
}
