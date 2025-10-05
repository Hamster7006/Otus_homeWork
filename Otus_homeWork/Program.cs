using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork;
using Otus_homeWork.CustomExept;
using Otus_homeWork.Function;
using Otus_homeWork.Help;
using Otus_homeWork.ToDO;



namespace Otus_homeWork
{
    public class Program
    {
        internal static int MaxLengthList = 0;
        internal static List<ToDoItem> TaskList = new List<ToDoItem> (100);
        //private static int testCase = 0;
        internal static int TaskLengthLimittaskLength = 0;

        

        static void Main(Update update, ConsoleBotClient botClient)
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
