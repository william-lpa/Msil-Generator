using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action26 : IAction
    {
        public void execute(Token token)
        {
            Semantico.GetInstance().codigoGerado.AppendLine("call string [mscorlib]System.Console::ReadLine()");
            Object tipo = Semantico.GetInstance().tabelaSimbolos[Semantico.GetInstance().identificadores[Semantico.GetInstance().identificadores.Count - 1]].tipoIdentificador;
            if (tipo != null)
            {
                if (tipo.GetType() != new TpString(false).GetType())
                {


                    if (tipo.GetType() == new TpInteger(false).GetType())
                        Semantico.GetInstance().codigoGerado.AppendLine("call int64 [mscorlib]System.Int64::Parse(string)");
                    //else if (tipo.GetType() == new TpBoolean(false).GetType())
                    //  Semantico.GetInstance().codigoGerado.AppendLine("call bool [mscorlib]System.Boolean::Parse(string)");
                    else if (tipo.GetType() == new TpFloat(false).GetType())
                        Semantico.GetInstance().codigoGerado.AppendLine("call float64 [mscorlib]System.Double::Parse(string)");
                    else
                    {
                        throw new SemanticError("Erro na linha " + token.Position + " - tipos inconpatíveis em expressão");

                    }
                }
                    
                Semantico.GetInstance().codigoGerado.AppendLine("stloc " + Semantico.GetInstance().identificadores[Semantico.GetInstance().identificadores.Count - 1]);
            }
            else 
            {
                throw new SemanticError("Erro na linha " + token.Position + " - identificador"+
                    "("+Semantico.GetInstance().pilha_de_identificadores.Pop()+")"+ " não declarado");
            }
        }
    }
}
