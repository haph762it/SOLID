namespace SolidPrincipleDemo.Isp
{
    public interface IOrderIsp
    {
        void AddToCartIsp();
    }

    public interface IOnlineOrderIsp
    {
        void CCProcessIsp();
    }

    public class OnlineOrderIsp : IOrderIsp, IOnlineOrderIsp
    {
        public void AddToCartIsp()
        {
            //Do Add to Cart
        }

        public void CCProcessIsp()
        {
            //process through credit card
        }
    }

    public class OfflineOrderIsp : IOrderIsp
    {
        public void AddToCartIsp()
        {
            //Do Add to Cart
        }
    }
}
