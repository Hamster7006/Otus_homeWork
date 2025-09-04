using Otus_homeWork;
using System.ComponentModel;

namespace Otus_homeWork
{
    internal class HelpFunctions
    {
        internal static void Pause()
        {
            Console.WriteLine("\n\r \n\rДля продолжения нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void NullOrWhiteSpaseName(string? print = null)
        {
            if (string.IsNullOrEmpty(Program.Name))
                Console.WriteLine(print);
            else
                Console.WriteLine(Program.Name + ", " + print);
        }

        internal static void PrintAvaliableCommandsOrHelp(int j, bool ln)
        {
            var ch = true;

            for (int i = 0; i < Program.AvalibleComands.GetLength(0); i++)
            {
                ch = true;
                if (Program.AvalibleComands[i, 0] == "/echo")
                {
                    if (Program.Name != null)
                        Console.Write(Program.AvalibleComands[i, j]);
                    else
                        ch = false;
                }
                else
                    Console.Write(Program.AvalibleComands[i, j]);

                if (ch)
                {
                    if (ln)
                        Console.WriteLine();
                    else
                        Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
    }
  
}
