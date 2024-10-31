namespace SolidPrincipleDemo.Lsp
{
    public abstract class ShapeLsp
    {
        public abstract string GetShape();
    }

    public class TriangleLsp : ShapeLsp
    {
        public override string GetShape()
        {
            return "Triangle";
        }
    }

    public class CircleLsp : TriangleLsp
    {
        public override string GetShape()
        {
            return "Circle";
        }
    }
}
