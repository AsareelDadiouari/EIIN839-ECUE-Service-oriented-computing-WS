using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCalcul.Calculator;

namespace MyCalcul
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorSoapClient calculatorSoapClient = new CalculatorSoapClient();
            Console.WriteLine(calculatorSoapClient.Add(1, 8));
            Console.ReadKey();
        }
    }
}
