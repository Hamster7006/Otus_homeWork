using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homeWork.CustomExept
{
    internal class WriteConExept
    {
        internal static void WriteConsoleExeption(Exception ex)
        {
            Console.WriteLine("--------");
            Console.WriteLine(ex.GetType());
            Console.WriteLine("--------");
            Console.WriteLine(ex.Message);
            Console.WriteLine("--------");
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine("--------");
            Console.WriteLine(ex.InnerException);
        }
    }
}
