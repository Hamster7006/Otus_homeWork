using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork;
using Otus_homeWork.TelegramBot;

namespace Otus_homeWork
{
    public class Program
    {
        static void Main(Update update, ConsoleBotClient botClient)
        {
            var handler = new UpdateHandler();
            var botClient2 = new ConsoleBotClient();
            botClient2.StartReceiving(handler);
            do
            {
                try
                {
                    new UpdateHandler().HandleUpdateAsync(botClient, update);
                }

                catch (Exception ex)
                {
                    botClient.SendMessage(update.Message.Chat, $"Ошибка: \r\n Type: {ex.GetType()} \r\n Message: {ex.Message} \r\n StackTrace: {ex.StackTrace} \r\n InnerException: {ex.InnerException} \r\n");
                }
            } while (true);
        }
    }
}
