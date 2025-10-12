using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork;
using Otus_homeWork.CustomExept;
using Otus_homeWork.Function;
using Otus_homeWork.Help;
using Otus_homeWork.ToDO;
using Otus_homeWork.UpdateHandler;
using Otus_homeWork.UserService;

var handler = new UpdateHandler();
var botClient = new ConsoleBotClient();
botClient.StartReceiving(handler);

namespace Otus_homeWork
{
    public class Program
    {
        static void Main(Update update, ConsoleBotClient botClient)
        //static void Main()
        {

            var handler2 = new UpdateHandler.UpdateHandler();
            var checkStopApp = false;
            do
            {
                try
                {
                    handler2.HandleUpdateAsync(botClient, update);
                }
                //catch (TaskCountLimitException ex)
                //{
                //    WriteConExept.WriteConsoleExeption(ex);
                //}
                //catch (ArgumentException ex)
                //{
                //    WriteConExept.WriteConsoleExeption(ex);
                //}
                //catch (TaskLengthLimitException ex)
                //{
                //    WriteConExept.WriteConsoleExeption(ex);
                //}
                //catch (DuplicateTaskException ex)
                //{
                //    WriteConExept.WriteConsoleExeption(ex);
                //}
                catch (Exception ex)
                {
                    //WriteConExept.WriteConsoleExeption(ex, true);
                    botClient.SendMessage(update.Message.Chat, $"Ошибка: \r\n Type: {ex.GetType()} \r\n Message: {ex.Message} \r\n StackTrace: {ex.StackTrace} \r\n InnerException: {ex.InnerException} \r\n");
                }                
                //Console.Clear();
            } while (!checkStopApp);
        }

        //internal static void StartApp()
        //{
            
        //}
    }
}
