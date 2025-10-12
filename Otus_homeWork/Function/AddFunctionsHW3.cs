using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork.Help;
using Otus_homeWork.ToDO;
using Otus_homeWork.UpdHan;

namespace Otus_homeWork.Function
{
    internal class AddFunctionsHW3
    {
        //public static void Completetask(string? parm = null, bool ch = true)
        public static void Completetask(Chat chat, ITelegramBotClient telegramBotClient, Guid Userid, ToDoService toDoService, string? parm = null)
        {
            var str = "";
            if (parm == null)
            {
                //Console.Clear();
                //AddFunctionsHW2.PrintTaskList(true, false);
                str = toDoService.PrintList(Userid, false);
                //str = AddFunctionsHW2.PrintTaskList(true);
                str = $"{str}{HelpFunctions.CheckName("Введите ID задачи для выполнения! Для выполнения всего списка введите 'all'")}";
                telegramBotClient.SendMessage(chat, str);
                var index = Console.ReadLine();
                if (index == "all")
                    //Completetask("all", false);
                    Completetask(chat, telegramBotClient, Userid, toDoService, "all");
                else
                    //Completetask(index, false);
                    Completetask(chat, telegramBotClient, Userid, toDoService, index);
            }
            else if (parm == "all")
            {
                for (var i = 0; i < UpdateHandler.TaskList.Count; i++)
                {
                    toDoService.MarkCompleted(UpdateHandler.TaskList[i].GuidId);
                }
                telegramBotClient.SendMessage(chat, "Список помечен как выполненый");
            }
            else
            {
                try
                {
                    Guid temp = UpdateHandler.TaskList.Where(t => t.GuidId.ToString() == parm).Select(t => t.GuidId).First();
                    toDoService.MarkCompleted(temp);
                    telegramBotClient.SendMessage(chat, $"Задача {temp} помечана выполненой");
                }
                catch {
                    telegramBotClient.SendMessage(chat, $"Задача c ID {parm} не найдена");
                }
            }
            //if (ch)
            //    HelpFunctions.Pause();
        }
    }
}
