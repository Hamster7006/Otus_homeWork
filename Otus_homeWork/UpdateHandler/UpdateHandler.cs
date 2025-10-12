using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork.CustomExept;
using Otus_homeWork.Function;
using Otus_homeWork.Help;
using Otus_homeWork.ToDO;
using Otus_homeWork.UpdateHandler;
using Otus_homeWork.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//var handler = new UpdateHandler();
//var botClient = new ConsoleBotClient();
//botClient.StartReceiving(handler);

namespace Otus_homeWork.UpdateHandler
{
    public class UpdateHandler : IUpdateHandler
    {
        internal static ToDoUser UserData = new();
        public static int MaxLengthList = 0;
        public static List<ToDoItem> TaskList = new List<ToDoItem>(100);
        //private static int testCase = 0;
        public static int TaskLengthLimittaskLength = 0;

        public UserService.UserService User = new ();
        public UpdateHandler(IUserService user, Update update)
        {
            
            //if(User.GetUser(update.Message.From.Id)==null)
            //    UserData = user.RegisterUser(update.Message.From.Id, update.Message.From.Username);
            //else
            //    return UserData;

            //IUserService user = new UserService.UserService();
            //IUserService.GetUser();
        }

        public void HandleUpdateAsync(ITelegramBotClient botClient, Update update)
        {
            botClient.SendMessage(update.Message.Chat, $"Получил '{update.Message.Text}'");
            var exitCheck = false;
            
            do
            {
                try
                {
                    if (MaxLengthList == 0)
                    {
                        HelpFunctions.InitCommandsAndHelp();
                        botClient.SendMessage(update.Message.Chat, "Введите максимально допустимое количество задач:");
                        //Console.WriteLine("Введите максимально допустимое количество задач:");
                        MaxLengthList = HelpFunctions.ParseAndValidateInt(Console.ReadLine(), 1, 100);
                        //Console.Clear();
                    }
                    if (TaskLengthLimittaskLength == 0)
                    {
                        botClient.SendMessage(update.Message.Chat, "Введите максимально допустимое длину задачи:");
                        TaskLengthLimittaskLength = HelpFunctions.ParseAndValidateInt(Console.ReadLine(), 1, 100);
                        //Console.Clear();
                    }

                    botClient.SendMessage(update.Message.Chat, $"{HelpFunctions.CheckName("Добро пожаловать в прогрaмму!")} \r\n Доступные комманды:\r\n {HelpFunctions.PrintAvaliableCommandsOrHelp(0)}");
                    //botClient.SendMessage(update.Message.Chat, "Добро пожаловать в прогрaмму! \r\n Доступные комманды:\r\n "); ;
                    botClient.SendMessage(update.Message.Chat, "------------------------------------------------");

                    var inputData = Console.ReadLine();

                    switch (inputData)
                    {
                        // HW 1
                        case "/start":
                            //BaseMenuFunctionHW1.Start(User, update);
                            //IUpdateHandler(User, update);
                            break;
                        case "/help":
                            //BaseMenuFunctionHW1.Help();
                            botClient.SendMessage(update.Message.Chat, $"{HelpFunctions.PrintAvaliableCommandsOrHelp(1)}");
                            break;
                        case "/info":
                            botClient.SendMessage(update.Message.Chat, $"{BaseMenuFunctionHW1.Info()}");
                            break;
                        case "/exit":
                            exitCheck = true;
                            break;
                        // HW 2
                        case string s when s.StartsWith("/removetask "):
                            botClient.SendMessage(update.Message.Chat, $"{AddFunctionsHW2.RemoveTaskList(s.Replace("/removetask ", ""))}");
                            break;
                        case string s when s.StartsWith("/addtask "):
                            botClient.SendMessage(update.Message.Chat, $"{AddFunctionsHW2.AddTaskList(s.Replace("/addtask ", ""))}");
                            break;
                        case "/showtasks":
                            //Console.Clear();
                            botClient.SendMessage(update.Message.Chat, $"{AddFunctionsHW2.PrintTaskList(false)}");
                            break;
                        // HW 3                    
                        case string s when s.StartsWith("/completetask "):
                            botClient.SendMessage(update.Message.Chat, $"{AddFunctionsHW3.Completetask(s.Replace("/completetask ", ""))}");
                            break;
                        case "/completetask":
                            botClient.SendMessage(update.Message.Chat, $"{AddFunctionsHW3.Completetask()}");
                            break;
                        case "/showalltasks":
                            //Console.Clear();
                            botClient.SendMessage(update.Message.Chat, $"{AddFunctionsHW2.PrintTaskList(true)}");
                            break;
                        default:
                            botClient.SendMessage(update.Message.Chat, "Не корректная команда или не задан параметр, повторите ввод. Если есть проблеммы, воспользуйтесь /help");
                            //HelpFunctions.Pause();
                            break;
                    }
                }
                catch (CustomException ex)
                {
                    //WriteConExept.WriteConsoleExeption(ex);
                    botClient.SendMessage(update.Message.Chat, $"Ошибка: {ex.Message}");
                }
                //catch (TaskCountLimitException ex)
                //{
                //    //WriteConExept.WriteConsoleExeption(ex);
                //    botClient.SendMessage(update.Message.Chat, $"Ошибка: {ex.Message}");
                //}
                //catch (ArgumentException ex)
                //{
                //    //WriteConExept.WriteConsoleExeption(ex);
                //    botClient.SendMessage(update.Message.Chat, $"Ошибка: {ex.Message}");
                //}
                //catch (TaskLengthLimitException ex)
                //{
                //    //WriteConExept.WriteConsoleExeption(ex);
                //    botClient.SendMessage(update.Message.Chat, $"Ошибка: {ex.Message}");
                //}
                //catch (DuplicateTaskException ex)
                //{
                //    //WriteConExept.WriteConsoleExeption(ex);
                //    botClient.SendMessage(update.Message.Chat, $"Ошибка: {ex.Message}");
                //}
            } while (!exitCheck);
        }
    }
}
