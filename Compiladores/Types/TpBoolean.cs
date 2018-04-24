namespace Compiladores.Tipo
{
    public class TpBoolean : TpTipo
    {
        public TpBoolean(bool x)
            : base(x)
        {
        }

        public override string ToString()
        {
            return "bool";
        }
    }
}
