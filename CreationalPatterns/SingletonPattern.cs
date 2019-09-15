using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CreationalPatterns
{    
    class SingletonPattern
    {
        public static void Main()
        {
            Thread t1 = new Thread(() =>
            {
                Singleton singleton1 = Singleton.GetInstance("from singleton 1");
                Console.WriteLine(singleton1.ReadMyVal);
            });

            Thread t2 = new Thread( () => {
                Singleton singleton2 = Singleton.GetInstance("from singleton 2");
                Console.WriteLine(singleton2.ReadMyVal);
            });

            t1.Start();
            Thread.Sleep(500);
            t2.Start();

            t1.Join();
            t2.Join();

            Console.ReadLine();
        }
    }

    class Singleton
    {
        private static readonly object _lock = new object();
        private Singleton() { }

        private static Singleton _instance;

        public string ReadMyVal { get; private set; }

        public static Singleton GetInstance(string val)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                        _instance.ReadMyVal = val;
                    }
                } 
            }

            return _instance;
        }
    }
}
