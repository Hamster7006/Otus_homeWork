using Otus_homeWork.Function;
using Otus_homeWork.Help;
using Otus_homeWork.ToDO;

namespace Otus_homeWork
{
    public class Program
    {

        internal static List<ToDoItem> TaskList = [];

        static void Main()
        {
            LoadMenu();
            Test.TestLoad();

        }

        internal static void LoadMenu()
        {
            var exitCheck = false;
            LoadHelp.LoadCommands();

            do
            {
                HelpFunctions.CheckName("Добро пожаловать в прогрaмму!");
                Console.WriteLine("доступные комманды:");
                HelpFunctions.PrintAvaliableCommandsOrHelp(0, false);
                Console.WriteLine("------------------------------------------------");

                var inputData = Console.ReadLine();

                switch (inputData)
                {
                    // HW 1
                    case "/start":
                        BaseMenuFunctionHW1.Start();
                        break;
                    case "/help":
                        BaseMenuFunctionHW1.Help();
                        break;
                    case "/info":
                        BaseMenuFunctionHW1.Info();
                        break;
                    case string s when BaseMenuFunctionHW1.UserData.TelegramUserName != "NoName" && s.StartsWith("/echo ") && !(s.Equals("/echo") || s.Equals("/echo ")):
                        BaseMenuFunctionHW1.Echo(s.Replace("/echo ", ""));
                        break;
                    case "/exit":
                        exitCheck = true;
                        break;
                    // HW 2
                    case string s when s.StartsWith("/removetask "):
                        AddFunctionsHW2.RemoveTaskList(s.Replace("/removetask ", ""));
                        break;
                    case "/removetask":
                        AddFunctionsHW2.RemoveTaskList();
                        break;
                    case string s when s.StartsWith("/addtask "):
                        AddFunctionsHW2.AddTaskList(s.Replace("/addtask ", ""));
                        break;
                    case "/addtask":
                        AddFunctionsHW2.AddTaskList();
                        break;
                    case "/showtasks":
                        Console.Clear();
                        AddFunctionsHW2.PrintTaskList(false);
                        break;
                    // HW 3                    
                    case string s when s.StartsWith("/completetask "):
                        AddFunctionsHW3.Completetask(s.Replace("/completetask ", ""));
                        break;
                    case "/completetask":
                        AddFunctionsHW3.Completetask();
                        break;
                    case "/showalltasks":
                        Console.Clear();
                        AddFunctionsHW2.PrintTaskList(true);
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
