namespace Compiladores.Tipo
{
    class TpCaracter : TpTipo
    {
        public TpCaracter(bool x)
            : base(x)
        {
        }


        public override string ToString()
        {
            return "string";
        }
    }
}
