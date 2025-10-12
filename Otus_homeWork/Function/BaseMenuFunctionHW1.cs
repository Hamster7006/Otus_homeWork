
using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork.Help;
using Otus_homeWork.ToDO;
using Otus_homeWork.UpdHan;
using Otus_homeWork.UsServ;

namespace Otus_homeWork.Function
{
    internal class BaseMenuFunctionHW1
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
