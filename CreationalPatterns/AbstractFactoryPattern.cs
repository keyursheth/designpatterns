using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns
{
    public class AbstractFactoryPattern
    {
        public static void Main()
        {
            IDiningTableFactory victorianDiningFactory = new VictorianDiningTableFactory();
            DiningTable victoriaDiningTable = new DiningTable(victorianDiningFactory);
            victoriaDiningTable.AssembleTable();

            Console.WriteLine(Environment.NewLine);

            IDiningTableFactory modernDiningFactory = new ModernDiningTableFactory();
            DiningTable modernDiningTable = new DiningTable(modernDiningFactory);
            modernDiningTable.AssembleTable();

            Console.ReadLine();
        }
        
        public interface IChair
        {
            string Get();
        }

        public class VictorianChair : IChair
        {
            public string Get()
            {
                return "I am Victorian Chair !!";
            }
        }

        public class ModernChair : IChair
        {
            public string Get()
            {
                return "I am Modern Chair !!";
            }
        }

        public interface ITable
        {
            string Get();
        }

        public class VictorianTable : ITable
        {
            public string Get()
            {
                return "I am Victorian Table !!";
            }
        }

        public class ModernTable : ITable
        {
            public string Get()
            {
                return "I am Modern Table !!";
            }
        }

        public interface IDiningTableFactory
        {
            IChair GetChair();
            ITable GetTable();
        }

        public class VictorianDiningTableFactory : IDiningTableFactory
        {
            public IChair GetChair()
            {
                return new VictorianChair();
            }

            public ITable GetTable()
            {
                return new VictorianTable();
            }
        }

        public class ModernDiningTableFactory : IDiningTableFactory
        {
            public IChair GetChair()
            {
                return new ModernChair();
            }

            public ITable GetTable()
            {
                return new ModernTable();
            }
        }

        public class DiningTable
        {
            private IDiningTableFactory _diningTableFactory;

            public DiningTable(IDiningTableFactory diningTableFactory)
            {
                _diningTableFactory = diningTableFactory;
            }

            public void AssembleTable()
            {
                Console.WriteLine("Preparing your dining table");
                Console.WriteLine(_diningTableFactory.GetChair().Get());
                Console.WriteLine(_diningTableFactory.GetTable().Get());
                Console.WriteLine("Your dining table is ready");
            }
        }
    }
}
