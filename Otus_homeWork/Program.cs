using Otus_homeWork.CustomExept;
using Otus_homeWork.Function;
using Otus_homeWork.Help;
using Otus_homeWork.ToDO;

namespace Otus_homeWork
{
    public class Program
    {
        internal static int MaxLengthList = 0;
        internal static int TaskLengthLimittaskLength = 0;
        internal static List<ToDoItem> TaskList = new List<ToDoItem> (100);
        private static int testCase = 0;



        
        static void Main()
        {
            var paramStart = 2; // 0 - обычный запуск | 2 - автотесты 
            var checkStopApp = false;
            do
            {
                try
                {
                    if (MaxLengthList == 0 || TaskLengthLimittaskLength == 0)
                        StartApp(paramStart);
                    else
                        StartApp(paramStart+1);
                }
                catch (TaskCountLimitException ex)
                {
                    WriteConExept.WriteConsoleExeption(ex);
                }
                catch (ArgumentException ex)
                {
                    WriteConExept.WriteConsoleExeption(ex);
                }
                catch (TaskLengthLimitException ex)
                {
                    WriteConExept.WriteConsoleExeption(ex);
                }
                catch (DuplicateTaskException ex)
                {
                    WriteConExept.WriteConsoleExeption(ex);
                }
                catch (Exception ex)
                {
                    WriteConExept.WriteConsoleExeption(ex, true);
                    checkStopApp = true;
                }                
                Console.Clear();
            } while (!checkStopApp);
        }
        internal static void StartApp(int param)
        {
            switch (param)
            {
                case 0:
                    LoadMenuFirst();
                    break;
                case 1:
                    LoadMenuSecond();
                    break;
                case 2:
                    MaxLengthList = 10;
                    TaskLengthLimittaskLength = 100;
                    Test.TestLoad();
                    break;
                default:
                    testCase++;
                    Test.TestHW(testCase);
                    break;
            }
        }

        internal static void LoadMenuFirst()
        {
            HelpFunctions.InitCommandsAndHelp();
            Console.WriteLine("Введите максимально допустимое количество задач:");
            var tempIn = Console.ReadLine();
            MaxLengthList = HelpFunctions.ParseAndValidateInt(tempIn, 1, 100);
            Console.Clear();

            Console.WriteLine("Введите максимально допустимое длину задачи:");
            tempIn = Console.ReadLine();
            TaskLengthLimittaskLength = HelpFunctions.ParseAndValidateInt(tempIn, 1, 100);
            LoadMenuSecond();
        }
        internal static void LoadMenuSecond()
        {
            var exitCheck = false;
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
                    case string s when BaseMenuFunctionHW1.UserData.TelegramUserName != null && s.StartsWith("/echo ") && !(s.Equals("/echo") || s.Equals("/echo ")):
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
