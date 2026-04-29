
using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork.Core.DataAccess.Help;
using Otus_homeWork.TelegramBot;

namespace Otus_homeWork.Core.Services
{
    internal partial class BaseFunction
    {
        public static void Start(UserService user, Update update, ITelegramBotClient telegramBot)
        {
            if (user.GetUser(update.Message.From.Id) == null)
                UpdateHandler.UserData = user.RegisterUser(update.Message.From.Id, update.Message.From.Username);

            if (UpdateHandler.MaxLengthList == 0)
            {

                telegramBot.SendMessage(update.Message.Chat, "Введите максимально допустимое количество задач:");
                UpdateHandler.MaxLengthList = HelpFunctions.ParseAndValidateInt(Console.ReadLine(), 1, 100);
            }
            if (UpdateHandler.TaskLengthLimittaskLength == 0)
            {
                telegramBot.SendMessage(update.Message.Chat, "Введите максимально допустимое длину задачи:");
                UpdateHandler.TaskLengthLimittaskLength = HelpFunctions.ParseAndValidateInt(Console.ReadLine(), 1, 100);
            }
        }
        internal static void Info(Chat chat, ITelegramBotClient telegramBotClient)
        {
            telegramBotClient.SendMessage(chat, $"Версия программы: {VariableData.VersionBot} \r\nДата релиза программы: {VariableData.DateRelise}");
        }
    }
}
