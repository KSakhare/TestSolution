using System;
using TestSolution.Interface;
using TestSolution.Interface.Models;
using TestSolution.Utility;

namespace TestSolution
{
    public class VehicleOperations
    {
        private readonly IVehicleTraffic _vehicleTraffic;
        private readonly IVehicleList _vehicleList;
        public VehicleOperations(IVehicleTraffic vehicleTraffic,IVehicleList vehicleList)
        {
            this._vehicleTraffic = vehicleTraffic;
            this._vehicleList = vehicleList;

        }

        public void AddVehicles(int vehicleId)
        {
            try
            {
                if (vehicleId >= 1 && vehicleId <= 5)
                {
                    if (_vehicleTraffic.CheckBridgeLoad())
                    {
                        var vehicles = _vehicleList.Vehicles();
                        var vehicle = vehicles.Find(x => x.Id == vehicleId);
                        ValidateVehicles(vehicle);
                    }
                    else
                        Console.WriteLine("Bridge capacity is exceeded over 100 tonnes");

                }
                else
                {
                    Console.WriteLine(Constants.InvalidMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidateVehicles(Vehicles vehicle)
        {
            if (vehicle.Name != Constants.Tank)
            {
                if (_vehicleTraffic.CheckLorry(vehicle))
                {
                    var result = _vehicleTraffic.AddVehicle(vehicle);
                    if (!string.IsNullOrEmpty(result))
                    {

                        Console.WriteLine( result.ToUpper() + " is running on bridge & available capacity of bridge is : " + (100 - _vehicleTraffic.CurrentBridgeWeight));
                      
                    }
                    else
                        Console.WriteLine("Exceeding Bridge Limit !!");
                }
                else
                    Console.WriteLine(" Already 3 Lorries are running on Bridge.More than 3 Lorries are not allowed !!");

            }
            else
                Console.WriteLine("Tank is Not Allowed on the Bridge !!");
        }

        public void RemoveVehicles()
        {
            try
            {
                if (_vehicleTraffic.CurrentBridgeWeight > 0)
                {
                   var vehicleName= _vehicleTraffic.RemoveVehicle();
                   Console.WriteLine(vehicleName.ToUpper() + " is removed  & Total weight on bridge is " +  _vehicleTraffic.CurrentBridgeWeight);
                    
                }
                else
                    Console.WriteLine("No Vehicles are running on Bridge..");
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }
    }
}
