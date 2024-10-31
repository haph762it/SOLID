using System;

namespace DoFactory.GangOfFour.Factory.Structural
{
    /// <summary>
    /// MainApp startup class for Structural 
    /// Factory Method Design Pattern.
    /// </summary>

    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>

        static void Main()
        {
            // An array of creators

            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            // Iterate over creators and create products

            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}",
                  product.GetType().Name);
            }
            //Creator: Là lớp trừu tượng đại diện cho một creator(người tạo) và khai báo phương thức FactoryMethod, là phương thức trừu tượng để tạo ra một đối tượng của lớp Product.

            //ConcreteCreatorA và ConcreteCreatorB: Là hai lớp con kế thừa từ Creator, triển khai phương thức FactoryMethod để tạo ra các đối tượng cụ thể(đối tượng ConcreteProductA và ConcreteProductB).

            //Product: Là lớp trừu tượng đại diện cho một sản phẩm(product).

            //ConcreteProductA và ConcreteProductB: Là hai lớp cụ thể kế thừa từ Product, đại diện cho các sản phẩm cụ thể mà ConcreteCreatorA và ConcreteCreatorB tạo ra.

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Product' abstract class
    /// </summary>

    abstract class Product
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>

    class ConcreteProductA : Product
    {
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>

    class ConcreteProductB : Product
    {
    }

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>

    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>

    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}
