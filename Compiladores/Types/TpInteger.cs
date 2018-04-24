namespace Compiladores.Tipo
{
    public class TpInteger  : TpTipo
    {
        public TpInteger(bool x)
            : base(x)
        {
        }

        public override string ToString()
        {
            return "int64";
        }
    }
}
