﻿namespace SolidPrincipleDemo.Isp
{
    public interface IOrder
    {
        void AddToCart();
        void CCProcess();
    }

    public class OnlineOrder : IOrder
    {
        public void AddToCart()
        {
            //Do Add to Cart
        }

        public void CCProcess()
        {
            //process through credit card
            Console.WriteLine("Phương thức thanh toán");
        }
    }

    public class OfflineOrder : IOrder
    {
        public void AddToCart()
        {
            //Do Add to Cart
        }

        public void CCProcess()
        {
            //Not required for Cash/ offline Order
            throw new NotImplementedException();
        }
    }
}
