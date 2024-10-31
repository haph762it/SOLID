namespace SolidPrincipleDemo.Srp
{
    public class GarageStationSrp
    {
        IGarageUtility _garageUtil;

        public GarageStationSrp(IGarageUtility garageUtil)
        {
            this._garageUtil = garageUtil;
        }
        public void OpenForService()
        {
            _garageUtil.OpenGate();
        }
        public void DoService()
        {
            //Check if service station is opened and then
            //finish the vehicle service
            Console.WriteLine("Do service something...");
        }
        public void CloseGarage()
        {
            _garageUtil.CloseGate();
        }
    }

    /// <summary>
    /// GarageStationUtility
    /// </summary>
    public class GarageStationUtility : IGarageUtility
    {
        public void OpenGate()
        {
            //Open the Garage for service
            Console.WriteLine("Open at: 7 AM");
        }

        public void CloseGate()
        {
            //Close the Garage functionlity
            Console.WriteLine("Close at: 7 PM");
        }
    }

    public interface IGarageUtility
    {
        void OpenGate();
        void CloseGate();
    }
}
