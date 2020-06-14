using Microsoft.Extensions.DependencyInjection;
using System;
using TestSolution.Interface;
using System.Text.RegularExpressions;
using TestSolution.Utility;

namespace TestSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IVehicleTraffic, VehicleTraffic>()
                .AddSingleton<IVehicleList, VehicleList>()
                .BuildServiceProvider();

            var vehicleTraffic = serviceProvider.GetService<IVehicleTraffic>();
            var vehicleList = serviceProvider.GetService<IVehicleList>();

            VehicleOperations vehicleOperations = new VehicleOperations(vehicleTraffic, vehicleList);
            while (true)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Choose required option from below operation list ");
                Console.WriteLine("1.Add Vehicles on Bridge | 2.Remove / Restrcit Vehicles From Bridge");
                Console.WriteLine("--------------------------------");
                string input = Console.ReadLine();
                bool result = ValidateOperationInput(input);

                if (result)
                {
                    switch (input)
                    {
                        case "1":
                            int vehicleInput;

                            var vehicles = vehicleList.Vehicles();
                            do
                            {
                                Console.WriteLine("Select Vehicle :");
                                for (int i = 0; i < vehicles.Count; i++)
                                {
                                    Console.WriteLine(i + 1 + " " + vehicles[i].Name.ToUpper());
                                }
                                Console.WriteLine("--------------------------------");
                                vehicleInput = Convert.ToInt32(Console.ReadLine());
                                if (vehicleInput > vehicles.Count)
                                    Console.WriteLine("Please enter vehicle from above list only");
                            } while (vehicleInput > vehicles.Count);

                            vehicleOperations.AddVehicles(vehicleInput); break;
                        case "2":
                            vehicleOperations.RemoveVehicles(); break;
                        default:
                            Console.WriteLine(Constants.InvalidMessage); break;
                    }
                }
            }
        }

        private static bool ValidateOperationInput(string input)
        {
            Regex checkInputChars = new Regex("^[1-5]+$");
            if (!checkInputChars.IsMatch(input.ToString()))
            {
                Console.WriteLine(Constants.InvalidMessage);
                return false;
            }
            return true;
        }


    }
}
