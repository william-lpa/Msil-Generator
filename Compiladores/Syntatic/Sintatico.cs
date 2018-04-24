using System.Collections.Generic;

namespace Sintatico{

public class Sintatico : _Constants
{
    private Stack<int> stack = new Stack<int>();
    private Token currentToken;
    private Token previousToken;
    private Lexico scanner;
    private Semantico semanticAnalyser;
    private static ParserConstants parserConst;

    public Sintatico() 
    {
         parserConst = ParserConstants.getInstance();
    }
    
    private static  bool isTerminal(int x)
    {
        return x < parserConst.FIRST_NON_TERMINAL;
    }

    private static bool isNonTerminal(int x)
    {
        return x >= parserConst.FIRST_NON_TERMINAL && x < parserConst.FIRST_SEMANTIC_ACTION;
    }

    private static bool isSemanticAction(int x)
    {
        return x >= parserConst.FIRST_SEMANTIC_ACTION;
    }
	 private string identificadorEncontrado(int a)
      {
          
            if (a >= 27) { return "símbolo especial"; }

        switch (a) 
        { 
            case 2: return "identificador (" + currentToken.Lexeme+")";
            case 3: return "constante inteira (" + currentToken.Lexeme + ")"; 
            case 4: return "constante real (" + currentToken.Lexeme + ")";
            case 5: return "constante string (" + currentToken.Lexeme + ")";
            case 6: return "constante caractere (" + currentToken.Lexeme + ")";
            default: return "palavra reservada (" + currentToken.Lexeme + ")";
            
        }
            
        }

    private bool step()
    {
        if (currentToken == null)
        {
            int pos = 0;
            if (previousToken != null)
                pos = previousToken.Position+previousToken.Lexeme.Length;

            currentToken = new Token(DOLLAR, "$", pos);
        }

        int x = ((int)stack.Pop());
        int a = currentToken.Id;

        if (x == EPSILON)
        {
            return false;
        }
        else if (isTerminal(x))
        {
            if (x == a)
            {
                if (stack.Count==0)
                    return true;
                else
                {
                    previousToken = currentToken;
                    currentToken = scanner.nextToken();
                    return false;
                }
            }
            else
            {
                throw new SyntaticError("encontrado " + identificadorEncontrado(a) + " " + parserConst.PARSER_ERROR[x], currentToken.Position);
                
            }
        }
        else if (isNonTerminal(x))
        {
            if (pushProduction(x, a))
                return false;
            else
            {
                throw new SyntaticError("encontrado " + identificadorEncontrado(a) + " "+ parserConst.PARSER_ERROR[x], currentToken.Position);
                
            }
        }
        else // isSemanticAction(x)
        {
           semanticAnalyser.executeAction(x - parserConst.FIRST_SEMANTIC_ACTION, previousToken);
            return false;
        }
    }

    private bool pushProduction(int topStack, int tokenInput)
    {
        int p = parserConst.PARSER_TABLE[topStack - parserConst.FIRST_NON_TERMINAL, tokenInput - 1];
        if (p >= 0)
        {
            int[] production = parserConst.PRODUCTIONS[p];
            //empilha a produção em ordem reversa
            for (int i=production.Length-1; i>=0; i--)
            {
                stack.Push((production[i]));
            }
            return true;
        }
        else
            return false;
    }

    public void parse(Lexico scanner, Semantico semanticAnalyser)
    {
        this.scanner = scanner;
        this.semanticAnalyser = semanticAnalyser;

        stack.Clear();
        stack.Push((DOLLAR));
        stack.Push((parserConst.START_SYMBOL));

        currentToken = scanner.nextToken();

        while ( ! step() );
    }
}
}
