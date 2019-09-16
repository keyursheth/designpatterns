using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns
{
    public class FactoryMethodPattern
    {
        public static void Main()
        {
            Console.WriteLine("Testing Factory Method Pattern");
            TestFactoryMethodPattern(new GroundTransport());
            Console.WriteLine(Environment.NewLine);
            TestFactoryMethodPattern(new WaterTransport());
            Console.ReadLine();
        }

        public static void TestFactoryMethodPattern(TransportCreator transportCreator)
        {            
            transportCreator.StartDelivery();
        }
    }

    public interface ITransportVehicle
    {
        string Deliver();
    }

    public class Truck : ITransportVehicle
    {
        public string Deliver()
        {
            return "Delivered by a Truck !";
        }
    }

    public class Ship : ITransportVehicle
    {
        public string Deliver()
        {
            return "Delivered by a Ship !";
        }
    }

    public abstract class TransportCreator
    {
        public abstract ITransportVehicle GetTransportVehicleFactoryMethod();

        // core business logic
        public void StartDelivery()
        {            
            ITransportVehicle transportVehicle = GetTransportVehicleFactoryMethod();
            Console.WriteLine("Starting delivery by " + transportVehicle.GetType().ToString());
            Console.WriteLine(transportVehicle.Deliver());
        }
    }

    public class GroundTransport : TransportCreator
    {
        public override ITransportVehicle GetTransportVehicleFactoryMethod()
        {
            return new Truck();
        }
    }

    public class WaterTransport : TransportCreator
    {
        public override ITransportVehicle GetTransportVehicleFactoryMethod()
        {
            return new Ship();
        }
    }
}
