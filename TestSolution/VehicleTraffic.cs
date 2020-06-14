using System.Collections.Generic;
using System.Linq;
using TestSolution.Interface;
using TestSolution.Interface.Models;
using TestSolution.Utility;

namespace TestSolution
{
    public class VehicleTraffic : IVehicleTraffic
    {
        public double currentBridgeWeight = 0;
        public const double bridgeWegihtCapacity = 100;
        private readonly Queue<Vehicles> vehiclesOnBridge = new Queue<Vehicles>();

        public double CurrentBridgeWeight
        {
            get { return currentBridgeWeight; }
            set { currentBridgeWeight = value; }
        }
        public string AddVehicle(Vehicles vehicles)
        {
            if (CheckWeight(vehicles))
            {
                vehiclesOnBridge.Enqueue(vehicles);
                currentBridgeWeight = vehiclesOnBridge.Select(x => x.Weight).Sum() / 1000d;
                return vehicles.Name;
            }
            return null;
        }

        private bool CheckWeight(Vehicles vehicles)
        {
            return currentBridgeWeight + vehicles.Weight / 1000 < 100 ? true : false;
        }

        public bool CheckLorry(Vehicles vehicle)
        { 
            if(vehicle.Name == Constants.Lorry)
                return vehiclesOnBridge.Where(x => x.Name == Constants.Lorry).Count() < 3 ? true : false;

            return true;
        }

        public string RemoveVehicle()
        {
            var vehicleName=vehiclesOnBridge.Dequeue();
            currentBridgeWeight = vehiclesOnBridge.Select(x => x.Weight).Sum() / 1000d;
            return vehicleName.Name;
        }

        public bool CheckBridgeLoad()
        {
            if (currentBridgeWeight < bridgeWegihtCapacity)
                return true;
            return false;
        }
    }
}
