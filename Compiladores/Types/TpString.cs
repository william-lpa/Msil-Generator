namespace Compiladores.Tipo
{
    class TpString : TpTipo
    {
        public TpString(bool x)
            : base(x)
        {
        }

        public override string ToString()
        {
            return "string";
        }
    }
}
