using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork;
using Otus_homeWork.Infrastructure.DataAccess;
using Otus_homeWork.TelegramBot;

namespace Otus_homeWork
{
    public class Program
    {
        static void Main(Update update, ConsoleBotClient botClient)
        {
            
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
