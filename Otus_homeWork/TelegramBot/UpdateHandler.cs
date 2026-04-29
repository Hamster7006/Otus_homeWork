using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork.Core.DataAccess.Help;
using Otus_homeWork.Core.Entities;
using Otus_homeWork.Core.Exceptions;
using Otus_homeWork.Core.Services;
using Otus_homeWork.TelegramBot;



namespace Otus_homeWork.TelegramBot
{
    public class UpdateHandler : IUpdateHandler
    {
        public static ToDoUser UserData = new();

        public static int MaxLengthList = 0;
        public static int TaskLengthLimittaskLength = 0;
        public static List<ToDoItem> TaskList = new List<ToDoItem>(100);
        public ToDoService toDoService = new ToDoService();

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
                    botClient.SendMessage(update.Message.Chat, "------------------------------------------------");

                    var inputData = Console.ReadLine();

                    switch (inputData)
                    {
                        case "/start":
                            BaseFunction.Start(new UserService(), update, botClient);
                            break;
                        case "/help":
                            botClient.SendMessage(update.Message.Chat, $"{HelpFunctions.PrintAvaliableCommandsOrHelp(1)}");
                            break;
                        case "/info":
                            BaseFunction.Info(update.Message.Chat, botClient);
                            break;
                        case "/exit":
                            exitCheck = true;
                            break;
                        case string s when s.StartsWith("/removetask "):
                            botClient.SendMessage(update.Message.Chat, $"{BaseFunction.RemoveTaskList(s.Replace("/removetask ", ""))}");
                            break;
                        case string s when s.StartsWith("/addtask "):
                            botClient.SendMessage(update.Message.Chat, $"{toDoService.Add(UserData, s.Replace("/addtask ", ""))}");
                            break;
                        case "/showtasks":
                            botClient.SendMessage(update.Message.Chat, $"{toDoService.PrintList(UserData.UserId, false)}");
                            break;
                        case string s when s.StartsWith("/completetask "):
                            BaseFunction.Completetask(update.Message.Chat, botClient, UserData.UserId, toDoService, s.Replace("/completetask ", ""));
                            break;
                        case "/completetask":
                            BaseFunction.Completetask(update.Message.Chat, botClient, UserData.UserId, toDoService);
                            break;
                        case "/showalltasks":
                            botClient.SendMessage(update.Message.Chat, $"{toDoService.PrintList(UserData.UserId, true)}");
                            break;
                        default:
                            botClient.SendMessage(update.Message.Chat, "Не корректная команда или не задан параметр, повторите ввод. Если есть проблеммы, воспользуйтесь /help");
                            break;
                    }
                }
                catch (CustomException ex)
                {
                    botClient.SendMessage(update.Message.Chat, $"Ошибка: {ex.Message}");
                }

            } while (!exitCheck);
        }
    }
}