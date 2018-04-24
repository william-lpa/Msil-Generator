using System;
public class Token
{
    private int id;
    private String lexeme;
    private int position;

    public Token(int id, String lexeme, int position)
    {
        this.id = id;
        this.lexeme = lexeme;
        this.position = position;
    }

    public int Id
        {
            get { return id; }
        }

    public String Lexeme
    {
        get {return lexeme;}
    }

    public int Position
    {
        get { return position;}
    }

    public String toString()
    {
        return id+" ( "+lexeme+" ) @ "+position;
    }

    public string getTipoToken()
    {
        if (Id > 32) { return "símbolo especial"; }

        switch (Id) 
        {

            case 2: return "identificador";
            case 3: return "constante inteira";
            case 4: return "constante real";
            case 5: return "constante string";
            case 6: return "constante caractere";
            case 7: return "constante data";
            case 8: return "constante hora";
            default: return "palavra reservada";
            
        }
    }
}
