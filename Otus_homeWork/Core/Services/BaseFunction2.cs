using Otus_homeWork.Core.DataAccess.Help;
using Otus_homeWork.TelegramBot;
using System.Linq;

namespace Otus_homeWork.Core.Services
{
    internal partial class BaseFunction
    {
        
        internal static string RemoveTaskList(string? inputParam = null)
        {
            var strToReturn = "";
            if (inputParam == null)
            {
                strToReturn = HelpFunctions.CheckName("Не корректный ввод задачи. Требуется сразу после команды указать номер задачу для удаления");
            }
            else if (inputParam == "all")
            {
                UpdateHandler.TaskList.RemoveRange(0, UpdateHandler.TaskList.Count);
                strToReturn = "Список очищен";
            }
            else if (inputParam.Contains(','))
            {
                var changeInd = 0;

                List<string> indArr = [];

                foreach (string str in inputParam.Split(','))
                {
                    if (!indArr.Contains(str))
                        indArr.Add(str);
                }
                indArr.Sort();

                foreach (var ind in indArr)
                {
                    if (int.TryParse(ind, out var res) && res >= 1 && res - changeInd <= UpdateHandler.TaskList.Count)
                    {
                        strToReturn = $"{strToReturn}\r\n{RemoveTaskList($"{res - changeInd}")}";
                        changeInd++;
                    }
                }
            }
            else if (int.TryParse(inputParam, out var res) && res >= 1 && res <= UpdateHandler.TaskList.Count)
            {
                var tempTask = UpdateHandler.TaskList[res - 1];
                UpdateHandler.TaskList.RemoveAt(res - 1);
                strToReturn = $"Задача '{tempTask.TaskName}' удалена";
            }
            else
            {
                strToReturn = "Не корректный ввод номерa задачи.";
            }
            return strToReturn;
        }
    }
}
