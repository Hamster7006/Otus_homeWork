namespace Otus_homeWork
{
    internal class BaseMenuFunctionHW1
    {
        internal static void Help()
        {
            Console.Clear();
            HelpFunctions.NullOrWhiteSpaseName();
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
            Program.Name = Console.ReadLine();
            if (!string.IsNullOrEmpty(Program.Name))
            {
                Console.WriteLine("Очень приятно, " + Program.Name);
                HelpFunctions.Pause();
            }
            else
            {
                Console.Clear();
            }
        }
        internal static void Info()
        {
            Console.WriteLine("Версия программы: " + Program.VersionBot);
            Console.WriteLine("Дата релиза программы: " + Program.DateRelise);
            HelpFunctions.Pause();
        }
    }
}
