using System;

namespace Strategy.Structural
{
    /// <summary>
    /// Strategy Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            Context context;

            // Three contexts following different strategies

            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    /// Đây là lớp trừu tượng đại diện cho một chiến lược. 
    /// Lớp này khai báo phương thức trừu tượng AlgorithmInterface() để định nghĩa hành động cụ thể của mỗi chiến lược.

    public abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    /// Lớp ConcreteStrategyA, ConcreteStrategyB và ConcreteStrategyC: Đây là các lớp triển khai của lớp Strategy. 
    /// Mỗi lớp đại diện cho một chiến lược cụ thể và triển khai phương thức AlgorithmInterface() để định nghĩa hành động của từng chiến lược

    public class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
                "Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>

    public class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
                "Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>

    public class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
                "Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    /// Lớp Context: Đây là lớp chứa một đối tượng chiến lược và triển khai phương thức ContextInterface(). 
    /// Phương thức này gọi phương thức AlgorithmInterface() của chiến lược hiện tại để thực hiện hành động tương ứng. 
    /// Lớp Context nhận chiến lược thông qua hàm tạo và lưu trữ trong thuộc tính strategy

    public class Context
    {
        Strategy strategy;

        // Constructor

        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void ContextInterface()
        {
            strategy.AlgorithmInterface();
        }
    }
}
