using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns
{
    class BuilderPattern
    {
        public static void Main()
        {
            IHouseBuilder houseBuilder = new HouseBuilder();
            houseBuilder.Reset();

            Director director = new Director(houseBuilder);
            director.BuildSimpleHouse();

            House simpleHouse = houseBuilder.GetHouse();

            houseBuilder.Reset();
            director.BuildFancyHouse();

            House fancyHouse = houseBuilder.GetHouse();

            Console.WriteLine("Simple House " + simpleHouse.ListParts());
            Console.WriteLine("Fancy House " + fancyHouse.ListParts());

            Console.ReadLine();
        }
    }


    public interface IHouseBuilder
    {
        void Reset();
        void BuildWalls();
        void BuildDoors();
        void BuildWindows();
        void BuildGarden();
        void BuildSwimmingPool();
        House GetHouse();
    }

    public class HouseBuilder : IHouseBuilder
    {
        private House house;

        public HouseBuilder()
        {
            Reset();
        }

        public void BuildDoors()
        {
            house.Add("doors");
        }

        public void BuildGarden()
        {
            house.Add("garden");
        }

        public void BuildSwimmingPool()
        {
            house.Add("swimming pool");
        }

        public void BuildWalls()
        {
            house.Add("walls");
        }

        public void BuildWindows()
        {
            house.Add("windows");
        }

        public House GetHouse()
        {
            return house;
        }

        public void Reset()
        {
            house = new House();
        }
    }


    public class House
    {
        private List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public string ListParts()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var part in _parts)
            {
                stringBuilder.Append(part + ", ");
            }

            string partsList = "Parts List : " + stringBuilder.ToString();
            partsList = partsList.Remove(partsList.Length - 2, 2);

            return partsList;
        }
    }



    public class Director
    {

        IHouseBuilder _houseBuilder;

        public Director(IHouseBuilder houseBuilder)
        {
            _houseBuilder = houseBuilder;
        }

        public void BuildSimpleHouse()
        {
            _houseBuilder.BuildWalls();

            _houseBuilder.BuildDoors();

            _houseBuilder.BuildWindows();
        }


        public void BuildFancyHouse()
        {
            _houseBuilder.BuildWalls();

            _houseBuilder.BuildDoors();

            _houseBuilder.BuildWindows();

            _houseBuilder.BuildGarden();

            _houseBuilder.BuildSwimmingPool();
        }
    }
}
