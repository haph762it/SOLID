using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Composite.Structural
{
    /// <summary>
    /// Composite Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a tree structure

            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            // Add and remove a leaf

            Leaf leaf = new Leaf("Leaf D");
            leaf.Add(new Leaf("Leaf A"));
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            // 5 là depth thụt vào bao nhiêu
            root.Display(5);

            // Wait for user
            //Lớp Component: Đây là lớp trừu tượng đại diện cho thành phần trong cấu trúc Composite.
            //Lớp này có một thuộc tính là tên(name) và định nghĩa các phương thức trừu tượng Add(), Remove(), và Display().
            //Các phương thức này sẽ được triển khai bởi các lớp con.

            //Lớp Composite: Đây là lớp con của Component và đại diện cho thành phần Composite trong cấu trúc.
            //Lớp này bao gồm một danh sách các thành phần con(children).
            //Lớp cung cấp các phương thức để thêm và xóa thành phần con, cũng như hiển thị cấu trúc cây đệ quy bằng cách gọi phương thức Display() trên từng thành phần con.

            //Lớp Leaf: Đây là lớp con của Component và đại diện cho thành phần Leaf(cái duy nhất không có thành phần con) trong cấu trúc Composite.
            //Lớp này không có thành phần con và triển khai các phương thức Add(), Remove(), và Display() dưới dạng thông báo lỗi(vì Leaf không có thành phần con).

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Component' abstract class
    /// </summary>

    public abstract class Component
    {
        protected string name;

        // Constructor

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    /// <summary>
    /// The 'Composite' class
    /// </summary>

    public class Composite : Component
    {
        List<Component> children = new List<Component>();

        // Constructor

        public Composite(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display child nodes

            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    /// <summary>
    /// The 'Leaf' class
    /// </summary>

    public class Leaf : Component
    {
        // Constructor

        public Leaf(string name)
            : base(name)
        {
        }

        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}
