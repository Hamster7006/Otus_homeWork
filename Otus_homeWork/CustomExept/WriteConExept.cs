using Otus_homeWork.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homeWork.CustomExept
{
    internal class WriteConExept
    {
        internal static void WriteConsoleExeption(Exception ex, bool fullData = false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----ERROR----");
            if (fullData)
                Console.WriteLine(ex.GetType());

            Console.WriteLine(ex.Message);

            if (fullData)
                Console.WriteLine(ex.StackTrace);

            if (fullData)
                Console.WriteLine(ex.InnerException);

            Console.ResetColor();
            HelpFunctions.Pause();
        }
    }
}
