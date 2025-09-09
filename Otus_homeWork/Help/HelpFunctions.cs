using Otus_homeWork.Function;

namespace Otus_homeWork.Help
{
    internal class HelpFunctions
    {
        internal static void Pause()
        {
            Console.WriteLine("\n\r \n\rДля продолжения нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void CheckName(string? print = null)
        {
            if (BaseMenuFunctionHW1.UserData.TelegramUserName != "NoName")
                Console.WriteLine(print);
            else
                Console.WriteLine(BaseMenuFunctionHW1.UserData.TelegramUserName + ", " + print);
        }

        internal static void PrintAvaliableCommandsOrHelp(int j, bool ln)
        {
            bool ch;

            for (int i = 0; i < VariableData.Length; i++)
            {
                ch = true;
                if (VariableData.AvalibleComands[i, 0] == "/echo")
                {
                    if (BaseMenuFunctionHW1.UserData.TelegramUserName != "NoName")
                        Console.Write(VariableData.AvalibleComands[i, j]);
                    else
                        ch = false;
                }
                else
                    Console.Write(VariableData.AvalibleComands[i, j]);

                if (ch && i < VariableData.Length - 1)
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
