using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork.CustomExept;
using Otus_homeWork.Function;
using Otus_homeWork.Help;
using Otus_homeWork.ToDO;
using Otus_homeWork.UpdHan;
using Otus_homeWork.UsServ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


var handler = new UpdateHandler();
var botClient2 = new ConsoleBotClient();
botClient2.StartReceiving(handler);

namespace Otus_homeWork.UpdHan
{
    public class UpdateHandler : IUpdateHandler
    {
        public static ToDoUser UserData = new();

        public static int MaxLengthList = 0;
        public static int TaskLengthLimittaskLength = 0;
        public static List<ToDoItem> TaskList = new List<ToDoItem>(100);
        public ToDoService toDoService = new ToDoService ();

        public static void Start(UserService user, Update update, ITelegramBotClient telegramBot)
        {
            if (user.GetUser(update.Message.From.Id) == null)
                UserData = user.RegisterUser(update.Message.From.Id, update.Message.From.Username);

            if (MaxLengthList == 0)
            {
                
                telegramBot.SendMessage(update.Message.Chat, "Введите максимально допустимое количество задач:");
                MaxLengthList = HelpFunctions.ParseAndValidateInt(Console.ReadLine(), 1, 100);
            }
            if (TaskLengthLimittaskLength == 0)
            {
                telegramBot.SendMessage(update.Message.Chat, "Введите максимально допустимое длину задачи:");
                TaskLengthLimittaskLength = HelpFunctions.ParseAndValidateInt(Console.ReadLine(), 1, 100);
            }
        }


        public void HandleUpdateAsync(ITelegramBotClient botClient, Update update)
        {
            botClient.SendMessage(update.Message.Chat, $"Получил '{update.Message.Text}'");
            var exitCheck = false;
            HelpFunctions.InitCommandsAndHelp();
            do
            {
                try
                {
                    

                    botClient.SendMessage(update.Message.Chat, $"{HelpFunctions.CheckName("Добро пожаловать в прогрaмму!")} \r\n Доступные комманды:\r\n {HelpFunctions.PrintAvaliableCommandsOrHelp(0)}");
                    //botClient.SendMessage(update.Message.Chat, "Добро пожаловать в прогрaмму! \r\n Доступные комманды:\r\n "); ;
                    botClient.SendMessage(update.Message.Chat, "------------------------------------------------");

                    var inputData = Console.ReadLine();

                    switch (inputData)
                    {
                        // HW 1
                        case "/start":
                            //BaseMenuFunctionHW1.Start(User, update);
                            Start(new UserService(), update, botClient);
                            break;
                        case "/help":
                            //BaseMenuFunctionHW1.Help();
                            botClient.SendMessage(update.Message.Chat, $"{HelpFunctions.PrintAvaliableCommandsOrHelp(1)}");
                            break;
                        case "/info":
                            //botClient.SendMessage(update.Message.Chat, $"Версия программы: {VariableData.VersionBot} \r\n Дата релиза программы: {VariableData.DateRelise}");
                            BaseMenuFunctionHW1.Info(update.Message.Chat, botClient);
                                //Info();
                            break;
                        case "/exit":
                            exitCheck = true;
                            break;
                        // HW 2
                        case string s when s.StartsWith("/removetask "):
                            botClient.SendMessage(update.Message.Chat, $"{AddFunctionsHW2.RemoveTaskList(s.Replace("/removetask ", ""))}");
                            break;
                        case string s when s.StartsWith("/addtask "):
                            botClient.SendMessage(update.Message.Chat, $"{toDoService.Add(UserData ,s.Replace("/addtask ", ""))}");
                            break;
                        case "/showtasks":
                            //Console.Clear();
                            //botClient.SendMessage(update.Message.Chat, $"{AddFunctionsHW2.PrintTaskList(false)}");
                            botClient.SendMessage(update.Message.Chat, $"{toDoService.PrintList(UserData.UserId, false)}");
                            break;
                        // HW 3                    
                        case string s when s.StartsWith("/completetask "):
                            //botClient.SendMessage(update.Message.Chat, $"{AddFunctionsHW3.Completetask(UserData.UserId, toDoService, s.Replace("/completetask ", ""))}");
                            AddFunctionsHW3.Completetask(update.Message.Chat, botClient, UserData.UserId, toDoService, s.Replace("/completetask ", ""));
                            break;
                        case "/completetask":
                            //botClient.SendMessage(update.Message.Chat, $"{AddFunctionsHW3.Completetask(UserData.UserId, toDoService)}");
                            AddFunctionsHW3.Completetask(update.Message.Chat, botClient, UserData.UserId, toDoService);
                            break;
                        case "/showalltasks":
                            //Console.Clear();
                            //botClient.SendMessage(update.Message.Chat, $"{AddFunctionsHW2.PrintTaskList(true)}");
                            botClient.SendMessage(update.Message.Chat, $"{toDoService.PrintList(UserData.UserId, true)}");
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
