using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalPatterns
{
    class PrototypePattern
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Environment.NewLine);

            Company c1 = new Company(1, "company 1", 400064, "Mumbai");
            //Company c2 = c1;
            //Company c2 = c1.MakeShallowCopy();
            //Company c2 = c1.MakeDeepCopy();
            Company c2 = c1.MakeDeepCopyBySerialization();


            c1.CompanyID = 2;
            c1.CompanyName = "company 2";
            c1.CompanyAddress.Pincode = 123456;
            c1.CompanyAddress.City = "Pune";
            c1.EmpIds.Add(4);
            c1.EmpNames.Add("vivaan");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("After modifications");
            Console.WriteLine(Environment.NewLine);
            c1.PrintDetails();
            Console.WriteLine("--------------------");
            c2.PrintDetails();

            Console.ReadLine();
        }
    }

    class Company
    {
        public Company(int id, string name, int pincode, string city)
        {
            this.CompanyID = id;
            this.CompanyName = name;
            this.CompanyAddress = new Address(pincode, city);

            this.EmpIds = new List<int>();
            this.EmpIds.Add(1);
            this.EmpIds.Add(2);
            this.EmpIds.Add(3);

            this.EmpNames = new List<string>();
            this.EmpNames.Add("keyur");
            this.EmpNames.Add("dipti");
        }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public Address CompanyAddress { get; set; }

        public List<int> EmpIds;
        public List<string> EmpNames;

        public Company MakeShallowCopy()
        {
            return this.MemberwiseClone() as Company;
        }

        public Company MakeDeepCopy()
        {
            Company c2 = this.MemberwiseClone() as Company;
            c2.EmpIds = new List<int>();
            c2.EmpIds.AddRange(this.EmpIds);
            c2.EmpNames = new List<string>();
            c2.EmpNames.AddRange(this.EmpNames);
            c2.CompanyAddress = new Address(this.CompanyAddress.Pincode, this.CompanyAddress.City);

            return c2;
        }

        public Company MakeDeepCopyBySerialization()
        {
            Company c1 = this;
            Company clone = JsonConvert.DeserializeObject<Company>(JsonConvert.SerializeObject(c1));
            return clone;
        }

        public void PrintDetails()
        {
            Console.WriteLine("Company ID : " + this.CompanyID);
            Console.WriteLine("Company Name : " + this.CompanyName);
            Console.WriteLine("Company Pincode : " + this.CompanyAddress.Pincode);
            Console.WriteLine("Company City : " + this.CompanyAddress.City);
            Console.WriteLine("Company Employee Id's : " + this.EmpIds.ListValuesToString());
            Console.WriteLine("Company Employee Name's : " + this.EmpNames.ListValuesToString());
        }
    }

    class Address
    {
        public Address(int pin, string city)
        {
            this.Pincode = pin;
            this.City = city;
        }
        public string City { get; set; }
        public int Pincode { get; set; }
    }

    static class Extensions
    {
        public static string ListValuesToString<T>(this List<T> lst)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in lst)
            {
                sb.Append(item);
                sb.Append(",");
            }

            if (sb.Length > 0)
                sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }
    }
}
