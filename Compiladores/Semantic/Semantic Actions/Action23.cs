using Compiladores.Semântico.Acoes_Semanticas;
using Compiladores.Tipo;
using Sintatico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiladores.Semântico
{
    class Action23 : IAction
    {
        public void execute(Token token)
        {
            string valor = token.Lexeme;
            TpTipo tipo = Semantico.GetInstance().tipoDoValor(Semantico.GetInstance().tipoIdentificador);
            
            List<string> listaIds = new List<string>(); // Nesta lista deve estar os nomes das variaveis
//            KeyValuePair<string, Sintatico.Semantico.ItensTabela> it in Semantico.GetInstance().tabelaSimbolos
            foreach (var x in Semantico.GetInstance().pilha_de_identificadores)
            {
                var it = Semantico.GetInstance().tabelaSimbolos[x];
                if (!it.variavelDeclarada)
                {
                    listaIds.Add(x);
                    Semantico.GetInstance().tabelaSimbolos[x].variavelDeclarada = true;
                    Semantico.GetInstance().tabelaSimbolos[x].tipoIdentificador = tipo;
                }
                else { throw new SemanticError("Erro na linha " + token.Position + " - identificador (" + x + ") já declarado"); }
            }

            if (tipo != null)
                declararIds(listaIds, tipo, valor);

            Semantico.GetInstance().pilha_de_identificadores.Clear();
        }

        private void declararIds(List<string> listaIds, TpTipo tipo, string valor)
        {
            string codigoTipo = "";
            string codigoMSIL = "";

            if (tipo is TpInteger)
            {
                codigoTipo = "int64";
                codigoMSIL = "ldc.i8 {0}";
            }
            else if (tipo is TpFloat)
            {
                codigoTipo = "float64";
                codigoMSIL = "ldc.r8 {0}";
            }
            else if (tipo is TpBoolean)
            {
                codigoTipo = "bool";
                codigoMSIL = "ldc.i4 {0}";
            }
            else if (tipo is TpCaracter)
            {
                codigoTipo = "string";
                codigoMSIL = "ldstr {0}";
            }
            else if (tipo is TpString)
            {
                codigoTipo = "string";
                codigoMSIL = "ldstr {0}";
            }

            if (listaIds.Count > 0)
            {
                Semantico.GetInstance().codigoGerado.Append(".locals (");
                for (int i = 0; i < listaIds.Count; i++)
                {
                    Semantico.GetInstance().codigoGerado.Append(codigoTipo + " " + listaIds[i]);
                    if ((i + 1) < listaIds.Count)
                        Semantico.GetInstance().codigoGerado.Append(", ");
                }
                Semantico.GetInstance().codigoGerado.AppendLine(")");
            }

            if (Semantico.GetInstance().validaTipoValor(valor))
            {
                for (int i = 0; i < listaIds.Count; i++)
                {
                    if (tipo is TpBoolean)
                    {
                        if (valor == "true")
                            Semantico.GetInstance().codigoGerado.AppendLine("ldc.i4.1");
                        else
                            Semantico.GetInstance().codigoGerado.AppendLine("ldc.i4.0");
                    }
                    else
                        Semantico.GetInstance().codigoGerado.AppendLine(string.Format(codigoMSIL, valor));

                    Semantico.GetInstance().codigoGerado.AppendLine("stloc " + listaIds[i]);

                }
            }
        }
    }
}
