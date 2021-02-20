using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methode
{
    class Program
    {
        static void Main(string[] args)
        {
            var html = (args.Length >= 1) ? "External :" + string.Join(" ", args) : "Vous n'avez aucun arguments";
            Console.WriteLine(html);
        }
    }
}
