namespace SolidPrincipleDemo.Lsp
{
    public class Triangle
    {
        public virtual string GetShape()
        {
            return "Triangle";
        }
    }

    public class Circle : Triangle
    {
        public override string GetShape()
        {
            return "Circle";
        }
    }
}
