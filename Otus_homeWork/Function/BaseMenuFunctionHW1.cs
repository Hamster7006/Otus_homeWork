using Otus_homeWork.Help;
using Otus_homeWork.ToDO;

namespace Otus_homeWork.Function
{
    internal class BaseMenuFunctionHW1
    {
        internal static ToDoUser UserData = new("NoName");
        internal static void Help()
        {
            Console.Clear();
            HelpFunctions.CheckName();
            HelpFunctions.PrintAvaliableCommandsOrHelp(1, true);
            HelpFunctions.Pause();
        }
        internal static void Echo(string stringInput)
        {
            Console.WriteLine(stringInput);
            HelpFunctions.Pause();
        }

        internal static void Start()
        {
            Console.WriteLine("Давайите познакомимся, укажите как к вам обращаться");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Очень приятно, " + name);
                UserData = new(name);
                // \/ ИЛИ /\ ? ХЗ ЧТО ЛУЧШЕ ИСПОЛЬЗОВАТЬ 
                //UserData.TelegramUserName = name;

                HelpFunctions.Pause();
            }
            else
            {
                Console.Clear();
            }
        }
        internal static void Info()
        {
            Console.WriteLine($"Версия программы: {VariableData.VersionBot}");
            Console.WriteLine($"Дата релиза программы: {VariableData.DateRelise}");
            HelpFunctions.Pause();
        }


    }
}
