using Compiladores.Semântico;

namespace Sintatico{
    using Compiladores.Semântico.Acoes_Semanticas;
    using Compiladores.Tipo;
    using System;
    using System.Collections.Generic;
    using System.Text;

public class Semantico : _Constants
{
    public StringBuilder codigoGerado = new StringBuilder();
    public string rotuloWhileGerado = "";
    private static Semantico instance;
    public string OperadorRelacional = "";
    public string OperadorAtbr = "";
    public string tipoIdentificador= "";
    private String nomeArq;
    public Stack<TpTipo> pilha_de_tipos = new Stack<TpTipo>();
    public Stack<string> pilha_de_identificadores = new Stack<string>();
    public Dictionary<string, ItensTabela> tabelaSimbolos = new Dictionary<String, ItensTabela>();
    public List<String> identificadores = new List<String>();
    public Stack<string> rotulos = new Stack<string>(); // Usado para salvar os rotulos de laco de repetição
    public Stack<string> rotuloElse = new Stack<string>(); // Usado para salvar os rotulos do else dos ifs
    public String NomeArq
    {
        get { return nomeArq; }
        set { nomeArq = value; }
    }

    private int label = 0;
    public string geraRotulo()
    {
        label++;
        return "L" + label;
    }
    public string gerarNovoRotuloRepeticao()
    {
        string rotulo = geraRotulo();
        rotulos.Push(rotulo);
        return rotulo;
    }


    public static Semantico GetInstance()
    {
        if (instance == null)
            instance = new Semantico();
        return instance;
    }

    public void executeAction(int action, Token token)	 
    {
        IAction acao = null;
            switch (action)
            {
                case 1:
                    acao = new Action01();
                    break;
                case 2:
                    acao = new Action02();
                    break;
                case 3:
                    acao = new Action03();
                    break;
                case 4:
                    acao = new Action04();
                    break;
                case 5:
                    acao = new Action05();
                    break;
                case 6:
                    acao = new Action06();
                    break;
                case 7:
                    acao = new Action07();
                    break;
                case 8:
                    acao = new Action08();
                    break;
                case 9:
                    acao = new Action09();
                    break;
                case 10:
                    acao = new Action10();
                    break;
                case 11:
                    acao = new Action11();
                    break;
                case 12:
                    acao = new Action12();
                    break;
                case 13:
                    acao = new Action13();
                    break;
                case 14:
                    acao = new Action14();
                    break;
                case 15:
                    acao = new Action15();
                    break;
                case 16:
                    acao = new Action16();
                    break;
                case 17:
                    acao = new Action17();
                    break;
                case 18:
                    acao = new Action18();
                    break;
                case 19:
                    acao = new Action19();
                    break;
                case 20:
                    acao = new Action20();
                    break;
                case 21:
                    acao = new Action21();
                    break;
                case 22:
                    acao = new Action22();
                    break;
                case 23:
                    acao = new Action23();
                    break;
                case 24:
                    acao = new Action24();
                    break;
                case 25:
                    acao = new Action25();
                    break;
                case 26:
                    acao = new Action26();
                    break;
                case 27:
                    acao = new Action27();
                    break;
                case 28:
                    acao = new Action28();
                    break;
                case 29:
                    acao = new Action29();
                    break;
                case 30:
                    acao = new Action30();
                    break;
                case 31:
                    acao = new Action31();
                    break;
                case 32:
                    acao = new Action32();
                    break;
                case 33:
                    acao = new Action33();
                    break;
                case 34:
                    acao = new Action34();
                    break;
                case 35:
                    acao = new Action35();
                    break;
                case 36:
                    acao = new Action36();
                    break;
                case 37:
                    acao = new Action37();
                    break;
                case 38:
                    acao = new Action38();
                    break;
            }
            acao.execute(token);
            Console.WriteLine("Ação #"+action+", Token: "+token);
        
       
    }

    public class ItensTabela
    {
        public TpTipo tipoIdentificador = null; // ( int, bin, hexa, float, string, bool) se for funcao é o tipo do retorno da funcao,
        public bool variavelDeclarada = false;
    }

    public TpTipo tipoDoValor(string valor)
    {
        if (valor.Equals("boolean"))
            return new TpBoolean(true);
        else if (valor.StartsWith("int"))
            return new TpInteger(true);
        else if (valor.StartsWith("string"))
            return new TpString(true);
        else if (valor.Equals("char"))
            return new TpCaracter(true);
        else if (valor.Equals("float"))
            return new TpFloat(true);

        try
        {
            int x = int.Parse(valor);
            return new TpInteger(false);
        }
        catch (Exception) { }
        return null;
    }

    internal static void GetLimpa()
    {
        instance = null;

    }

    internal bool validaTipoValor(string valor)
    {
        switch (tipoIdentificador) 
        {
            case "bool": 
            {
                if (valor.Equals("true") || valor.Equals("false"))
                    return true;
            }break;

            case "int":
                {
                    long _valor=0;
                    if (long.TryParse(valor,out _valor))
                        return true;
                } break;
            case "char":
                {
                    if (valor.Equals(@"\space") || valor.Equals("\newline") || valor.Equals("\tab"))
                        return true;
                } break;
            case "float":
                {
                    double _valor = 0;
                    if (double.TryParse(valor, out _valor))
                        return true;
                } break;
            case "string":
                {
                    if (valor.StartsWith("\""))
                        return true;
                } break;
            
        }
        return false;
    }
}

}
