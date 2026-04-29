using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork.Core.DataAccess.Help;
using Otus_homeWork.TelegramBot;

namespace Otus_homeWork.Core.Services
{
    internal partial class BaseFunction
    {
        public static void Completetask(Chat chat, ITelegramBotClient telegramBotClient, Guid Userid, ToDoService toDoService, string? parm = null)
        {
            var str = "";
            if (parm == null)
            {
                str = toDoService.PrintList(Userid, false);
                str = $"{str}{HelpFunctions.CheckName("Введите ID задачи для выполнения! Для выполнения всего списка введите 'all'")}";
                telegramBotClient.SendMessage(chat, str);
                var index = Console.ReadLine();
                if (index == "all")
                    Completetask(chat, telegramBotClient, Userid, toDoService, "all");
                else
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
        }
    }
}
