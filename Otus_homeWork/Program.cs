namespace Otus_homeWork
{
    public class Program
    {
        
        internal static List<string> TaskList = new List<string>();

        static void Main()
        {
            var exitCheck = false;
            LoadHelp.LoadCommands();

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


    }
}
