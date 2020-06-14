using TestSolution.Interface.Models;

namespace TestSolution.Interface
{
    public interface IVehicleTraffic
    {
        double CurrentBridgeWeight { get; set; }
        string AddVehicle(Vehicles vehicles);
        string RemoveVehicle();
        bool CheckBridgeLoad();
        bool CheckLorry(Vehicles vehicle);
    }
}
