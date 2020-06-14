using System;
using System.Collections.Generic;
using System.Text;
using TestSolution.Interface;
using TestSolution.Interface.Models;

namespace TestSolution
{
    public class VehicleList : List<Vehicles>, IVehicleList
    {
        public VehicleList()
        {
            AddRange( new List<Vehicles> { 
                new Vehicles() { Id = 1, Name = "MotorCycle", Weight = 200 },
                new Vehicles() { Id = 2, Name = "Car", Weight = 1500 },
                new Vehicles() { Id = 3, Name = "Bus", Weight = 5000 },
                new Vehicles() { Id = 4, Name = "Lorry", Weight = 20000 },
                new Vehicles() { Id = 5, Name = "Tank", Weight = 10000 }
           });

        }
        public List<Vehicles> Vehicles()
        {
            return new List<Vehicles>
            {
                new Vehicles(){Id=1,Name="MotorCycle",Weight=200 },
                new Vehicles(){Id=2,Name="Car",Weight=1500 },
                new Vehicles(){Id=3,Name="Bus",Weight=5000 },
                new Vehicles(){Id=4,Name="Lorry",Weight=20000 },
                new Vehicles(){Id=5,Name="Tank",Weight=10000 }
            };
        }
    }
}
