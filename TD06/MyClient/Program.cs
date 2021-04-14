using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClient.MathOperations;
namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperationsClient maths = new MathsOperationsClient();
            Console.WriteLine(maths.Add(5,8));
            Console.WriteLine(maths.Multiply(40, -985));
            Console.WriteLine(maths.Divide(0, 2));
            Console.WriteLine(maths.Substract(1, 999));

            Console.ReadKey();
        }
    }
}
