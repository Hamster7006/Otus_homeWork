namespace Otus_homeWork
{
    public class Program
    {
        //internal static string? Name;
        //internal static string VersionBot = "1.2.0";
        //internal static string DateRelise = "16.08.2025";
        internal static string[,] AvalibleComands = new string[8, 2];
        internal static List<string> TaskList = new List<string>();
        //var data = new VariableData();

        static void Main()
        {
            var exitCheck = false;
            LoadCommands();

            //AvalibleComands[0, 0] = "/start";
            //AvalibleComands[0, 1] = "Команда /start запускает знакомство, после которого достуны дополнительные команды";
            //AvalibleComands[1, 0] = "/help";
            //AvalibleComands[1, 1] = "Команда /help информация по командам (этот текст)";
            //AvalibleComands[2, 0] = "/info";
            //AvalibleComands[2, 1] = "Команда /info версия программы и дата релиза";
            //AvalibleComands[3, 0] = "/echo";
            //AvalibleComands[3, 1] = "Команда /echo <String>  режим ЭХО. Выводи в консоль <string>. Параметр <string> обязаителен для ввода.";
            //AvalibleComands[4, 0] = "/exit";
            //AvalibleComands[4, 1] = "Команда /exit выход из программы";
            //AvalibleComands[5, 0] = "/addtask";
            //AvalibleComands[5, 1] = "Команда /addtask [#] добавить задачу в список. \n\r" +
            //    "     Команда без параметра запросит ввод задачи для добавления \n\r" +
            //    "     Команда с параметром (строка) добавит задачу в список.";
            //AvalibleComands[6, 0] = "/showtasks";
            //AvalibleComands[6, 1] = "Команда /showtasks Вывести список задач";
            //AvalibleComands[7, 0] = "/removetask";
            //AvalibleComands[7, 1] = "Команда /removetask [#] удалить задачу из списка. \n\r" +
            //    "     Команда без параметра выведет список доступных задач для выбора номера указание номера задачи для удаления. \n\r" +
            //    "     Команда с параметром 'число' удалит задачу под указанным номером, если она существует \n\r" +
            //    "     Команда с параметром 'число1,число2..' удалит задачи под указанными номерами, если они существует. Разделитель ',' \n\r" +
            //    "     Параметр 'all' удалит весь список";

            do
            {
                HelpFunctions.NullOrWhiteSpaseName("Добро пожаловать в прогрaмму!");
                Console.WriteLine("доступные комманды:");
                HelpFunctions.PrintAvaliableCommandsOrHelp(0, false);
                Console.WriteLine("------------------------------------------------");

                var inputData = Console.ReadLine();

                switch (inputData)
                {
                    case "/start":
                        BaseMenuFunctionHW1.Start();
                        break;
                    case "/help":
                        BaseMenuFunctionHW1.Help();
                        break;
                    case "/info":
                        BaseMenuFunctionHW1.Info();
                        break;
                    case string s when !string.IsNullOrEmpty(VariableData.Name) && s.StartsWith("/echo ") && !(s.Equals("/echo") || s.Equals("/echo ")):
                        BaseMenuFunctionHW1.Echo(s.Replace("/echo ", ""));
                        break;
                    case string s when s.StartsWith("/removetask "):
                        AddFunctionsHW2.RemoveTaskList(s.Replace("/removetask ", ""));
                        break;
                    case string s when s.StartsWith("/addtask "):
                        AddFunctionsHW2.AddTaskList(s.Replace("/addtask ", ""));
                        break;
                    case "/showtasks":
                        AddFunctionsHW2.PrintTaskList();
                        break;
                    case "/exit":
                        exitCheck = true;
                        break;
                    default:
                        Console.WriteLine("Не корректная команда или не задан параметр, повторите ввод. Если есть проблеммы, воспользуйтесь /help");
                        HelpFunctions.Pause();
                        break;
                }
            } while (!exitCheck);
        }

        internal static void LoadCommands()
        {
            AvalibleComands[0, 0] = "/start";
            AvalibleComands[0, 1] = "Команда /start запускает знакомство, после которого достуны дополнительные команды";
            AvalibleComands[1, 0] = "/help";
            AvalibleComands[1, 1] = "Команда /help информация по командам (этот текст)";
            AvalibleComands[2, 0] = "/info";
            AvalibleComands[2, 1] = "Команда /info версия программы и дата релиза";
            AvalibleComands[3, 0] = "/echo";
            AvalibleComands[3, 1] = "Команда /echo <String>  режим ЭХО. Выводи в консоль <string>. Параметр <string> обязаителен для ввода.";
            AvalibleComands[4, 0] = "/exit";
            AvalibleComands[4, 1] = "Команда /exit выход из программы";
            AvalibleComands[5, 0] = "/addtask";
            AvalibleComands[5, 1] = "Команда /addtask [#] добавить задачу в список. \n\r" +
                "     Команда без параметра запросит ввод задачи для добавления \n\r" +
                "     Команда с параметром (строка) добавит задачу в список.";
            AvalibleComands[6, 0] = "/showtasks";
            AvalibleComands[6, 1] = "Команда /showtasks Вывести список задач";
            AvalibleComands[7, 0] = "/removetask";
            AvalibleComands[7, 1] = "Команда /removetask [#] удалить задачу из списка. \n\r" +
                "     Команда без параметра выведет список доступных задач для выбора номера указание номера задачи для удаления. \n\r" +
                "     Команда с параметром 'число' удалит задачу под указанным номером, если она существует \n\r" +
                "     Команда с параметром 'число1,число2..' удалит задачи под указанными номерами, если они существует. Разделитель ',' \n\r" +
                "     Параметр 'all' удалит весь список";
        }
    }
}
