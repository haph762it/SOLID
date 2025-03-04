﻿using System;
using System.Collections.Generic;

namespace Observer.RealWorld
{
    /// <summary>
    /// Observer Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create IBM stock and attach investors

            IBM ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));

            // Fluctuating prices will notify investors

            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;

            // Wait for user
            //IBM là 1 Subject
            //Investor là  1 ConcreteObserver

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>

    public abstract class Stock
    {
        private string symbol;
        private double price;
        private List<IInvestor> investors = new List<IInvestor>();

        // Constructor

        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }

        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (IInvestor investor in investors)
            {
                investor.Update(this);
            }

            Console.WriteLine("");
        }

        // Gets or sets the price

        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }

        // Gets the symbol

        public string Symbol
        {
            get { return symbol; }
        }
    }

    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>

    public class IBM : Stock
    {
        // Constructor

        public IBM(string symbol, double price)
            : base(symbol, price)
        {
        }
    }

    /// <summary>
    /// The 'Observer' interface
    /// </summary>

    public interface IInvestor
    {
        void Update(Stock stock);
    }

    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>

    public class Investor : IInvestor
    {
        private string name;
        private Stock stock;

        // Constructor

        public Investor(string name)
        {
            this.name = name;
        }

        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                "change to {2:C}", name, stock.Symbol, stock.Price);
        }

        // Gets or sets the stock

        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}
