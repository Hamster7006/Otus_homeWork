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
            if (string.IsNullOrEmpty(VariableData.Name))
                Console.WriteLine(print);
            else
                Console.WriteLine(VariableData.Name + ", " + print);
        }

        internal static void PrintAvaliableCommandsOrHelp(int j, bool ln)
        {
            bool ch;

            for (int i = 0; i < VariableData.Length; i++)
            {
                ch = true;
                if (Program.AvalibleComands[i, 0] == "/echo")
                {
                    if (VariableData.Name != null)
                        Console.Write(Program.AvalibleComands[i, j]);
                    else
                        ch = false;
                }
                else
                    Console.Write(Program.AvalibleComands[i, j]);

                if (ch && i< VariableData.Length -1)
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
