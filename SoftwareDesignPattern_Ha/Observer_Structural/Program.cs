using System;
using System.Collections.Generic;

namespace Observer.Structural
{
    /// <summary>
    /// Observer Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Configure Observer pattern

            ConcreteSubject s = new ConcreteSubject();

            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            // Change subject and notify observers

            s.SubjectState = "ABC";
            s.Notify();

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    /// Lớp Subject: Đây là lớp trừu tượng đại diện cho đối tượng được quan sát. 
    /// Lớp này bao gồm một danh sách các quan sát viên (observers). Lớp triển khai phương thức Attach() để thêm một quan sát viên vào danh sách, 
    /// Detach() để xóa một quan sát viên khỏi danh sách, và Notify() để thông báo cho tất cả các quan sát viên trong danh sách.

    public abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
    }

    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    /// Lớp ConcreteSubject: Đây là lớp triển khai lớp Subject. 
    /// Lớp này có một trạng thái (subjectState) và triển khai thuộc tính SubjectState để lấy và đặt trạng thái của đối tượng

    public class ConcreteSubject : Subject
    {
        private string subjectState;

        // Gets or sets subject state

        public string SubjectState
        {
            get { return subjectState; }
            set { subjectState = value; }
        }
    }

    /// <summary>
    /// The 'Observer' abstract class
    /// </summary>
    /// Lớp Observer: Đây là lớp trừu tượng đại diện cho quan sát viên. Lớp này khai báo phương thức Update() để xử lý thông báo từ đối tượng được quan sát

    public abstract class Observer
    {
        public abstract void Update();
    }

    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    /// Lớp ConcreteObserver: Đây là lớp triển khai lớp Observer. 
    /// Lớp này có một tên (name), một trạng thái của quan sát viên (observerState), và một đối tượng ConcreteSubject để quan sát. 
    /// Lớp triển khai phương thức Update() để xử lý thông báo từ đối tượng được quan sát và hiển thị thông báo trạng thái mới

    public class ConcreteObserver : Observer
    {
        private string name;
        private string observerState;
        private ConcreteSubject subject;

        // Constructor

        public ConcreteObserver(
            ConcreteSubject subject, string name)
        {
            this.subject = subject;
            this.name = name;
        }

        public override void Update()
        {
            observerState = subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}",
                name, observerState);
        }

        // Gets or sets subject

        public ConcreteSubject Subject
        {
            get { return subject; }
            set { subject = value; }
        }
    }
}
