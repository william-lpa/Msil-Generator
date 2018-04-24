namespace Compiladores.Tipo
{
    class TpFloat : TpTipo
    {
        public TpFloat(bool x)
            : base(x)
        {
        }


        public override string ToString()
        {
            return "float64";
        }
    }
}
