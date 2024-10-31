namespace SolidPrincipleDemo.Srp
{
    public class GarageStation
    {
        public void DoOpenGate()
        {
            //Open the gate functinality
            Console.WriteLine("Open at: 7 AM");
        }

        public void PerformService(Vehicle vehicle)
        {
            //trả ra tên của dịch vụ
            Console.WriteLine(vehicle.NameService);
            //Check if garage is opened
            //finish the vehicle service
        }

        public void DoCloseGate()
        {
            //Close the gate functinality
            Console.WriteLine("Close at: 7 PM");
        }
    }
}
