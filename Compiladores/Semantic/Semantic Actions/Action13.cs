using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action13 : IAction
    {
        public void execute(Token token)
        {
            /*
               tipo1:= pilha.desempilha
               tipo2:= pilha.desempilha
               se (tipo1 = tipo2)
               então pilha.empilha (bool)
               senão erro semântico, halt
               caso operador_relacional
               < : código.adiciona (clt)
               > : código.adiciona (cgt)
               = : código.adiciona (ceq)
            */
            TpTipo tipo1 = Semantico.GetInstance().pilha_de_tipos.Pop();
            TpTipo tipo2 = Semantico.GetInstance().pilha_de_tipos.Pop();

            if (tipo1.ehIdentificador())
                Semantico.GetInstance().pilha_de_identificadores.Pop();
            if (tipo2.ehIdentificador())
                Semantico.GetInstance().pilha_de_identificadores.Pop();

            if (tipo1.GetType() == new TpInteger(false).GetType() && new TpInteger(false).GetType() == tipo2.GetType())
                Semantico.GetInstance().pilha_de_tipos.Push(new TpBoolean(false));
            else if (tipo1.GetType() == new TpFloat(false).GetType() && new TpInteger(false).GetType() == tipo2.GetType())
                Semantico.GetInstance().pilha_de_tipos.Push(new TpBoolean(false));
            else if (tipo1.GetType() == new TpInteger(false).GetType() && new TpFloat(false).GetType() == tipo2.GetType())
                Semantico.GetInstance().pilha_de_tipos.Push(new TpBoolean(false));
            else if (tipo1.GetType() == new TpFloat(false).GetType() && new TpFloat(false).GetType() == tipo2.GetType())
                Semantico.GetInstance().pilha_de_tipos.Push(new TpBoolean(false));
            else if (tipo1.GetType() == new TpString(false).GetType() && new TpString(false).GetType() == tipo2.GetType())
                Semantico.GetInstance().pilha_de_tipos.Push(new TpBoolean(false));
            else
                throw new SemanticError("Erro na linha " + token.Position + " - Tipos incompativeis em expressão relacional");

            switch (Semantico.GetInstance().OperadorRelacional)
            {
                case "<":
                    Semantico.GetInstance().codigoGerado.AppendLine("clt");
                    break;
                case ">":
                    Semantico.GetInstance().codigoGerado.AppendLine("cgt");
                    break;
                case "==":
                    Semantico.GetInstance().codigoGerado.AppendLine("ceq");
                    break;
                case "<>":
                    {
                        Semantico.GetInstance().codigoGerado.AppendLine("ceq");
                        Semantico.GetInstance().codigoGerado.AppendLine("ldc.i4.1");
                        Semantico.GetInstance().codigoGerado.AppendLine("xor");
                        break;
                    }
                case "<=":
                    {
                        Semantico.GetInstance().codigoGerado.AppendLine("dup");
                        Semantico.GetInstance().codigoGerado.AppendLine("stloc TOPO__ALTO");
                        Semantico.GetInstance().codigoGerado.AppendLine("clt");
                        Semantico.GetInstance().codigoGerado.AppendLine("ldloc TOPO__BAIXO");
                        Semantico.GetInstance().codigoGerado.AppendLine("ldloc TOPO__ALTO");
                        Semantico.GetInstance().codigoGerado.AppendLine("ceq");
                        Semantico.GetInstance().codigoGerado.AppendLine("or");
                        break;
                    }
                case ">=":
                    {
                        Semantico.GetInstance().codigoGerado.AppendLine("dup");
                        Semantico.GetInstance().codigoGerado.AppendLine("stloc TOPO__ALTO");
                        Semantico.GetInstance().codigoGerado.AppendLine("cgt");
                        Semantico.GetInstance().codigoGerado.AppendLine("ldloc TOPO__BAIXO");
                        Semantico.GetInstance().codigoGerado.AppendLine("ldloc TOPO__ALTO");
                        Semantico.GetInstance().codigoGerado.AppendLine("ceq");
                        Semantico.GetInstance().codigoGerado.AppendLine("or");
                        break;
                    }
            }
        }
    }
}
