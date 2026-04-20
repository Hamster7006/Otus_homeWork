using Otus_homeWork.Core.DataAccess;
using Otus_homeWork.Core.DataAccess.Help;
using Otus_homeWork.Core.Entities;
using Otus_homeWork.Core.Exceptions;
using Otus_homeWork.TelegramBot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homeWork.Core.Services
{
    public class ToDoService : IToDoService
    {
        public IReadOnlyList<ToDoItem> GetAllByUserId(Guid userId)
        {
            var tempList = new List<ToDoItem>();
            foreach (var temp in UpdateHandler.TaskList)
            {
                if (temp.User.UserId == userId)
                    tempList.Add(temp);
            }
            return tempList;
        }
        //Возвращает ToDoItem для UserId со статусом Active
        public IReadOnlyList<ToDoItem> GetActiveByUserId(Guid userId)
        {
            var tempList = new List<ToDoItem>();
            foreach (var temp in UpdateHandler.TaskList)
            {
                if (temp.User.UserId == userId && temp.State == ToDoItemState.Active)
                    tempList.Add(temp);
            }
            return tempList;
        }
        public ToDoItem Add(ToDoUser user, string name)
        {

            if (UpdateHandler.TaskList.Count + 1 <= UpdateHandler.MaxLengthList)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if (name.Length > UpdateHandler.TaskLengthLimittaskLength)
                        throw new CustomException($"Длина задачи '{name.Length}' превышает максимально допустимое значение {UpdateHandler.TaskLengthLimittaskLength}");

                    if (UpdateHandler.TaskList.Count != 0)
                        foreach (var loadedTask in UpdateHandler.TaskList)
                        {
                            if (loadedTask.TaskName == name)
                                throw new CustomException($"Задача '{name}' уже существует");
                        }

                    var temp = new ToDoItem(UpdateHandler.UserData, name);

                    UpdateHandler.TaskList.Add(temp);
                    return temp;
                }
                else
                {
                    throw new CustomException("Не корректный ввод задачи. Требуется сразу после команды указать задачу для добавлвения");
                }
            }
            else
                throw new CustomException($"Превышено максимальное количество задач равное {UpdateHandler.MaxLengthList}");
        }
        public void MarkCompleted(Guid id)
        {
            var check = false;
            for (var i = 0; i < UpdateHandler.TaskList.Count; i++)
            {
                if (UpdateHandler.TaskList[i].GuidId == id)
                {
                    if (UpdateHandler.TaskList[i].State != ToDoItemState.Completed)
                    {
                        UpdateHandler.TaskList[i].State = ToDoItemState.Completed;
                        UpdateHandler.TaskList[i].ChangedAt = DateTime.Now;
                    }
                    else
                        throw new CustomException($"Задача помечена выполненной ранее: {UpdateHandler.TaskList[i].ChangedAt}");

                    check = true;
                }
            }

            if (!check)
                throw new CustomException("Не корректный ввод ID задачи.");
        }
           
        public void Delete(Guid id)
        {
            
        }

        public string PrintList(Guid id, bool allPrint)
        {
            if(allPrint)
                if (GetAllByUserId(id).Count == 0)
                    return HelpFunctions.CheckName("Список пуст");
                else 
                    return PrintList2(GetAllByUserId(id), allPrint);
            else
                if (GetActiveByUserId(id).Count == 0)
                    return HelpFunctions.CheckName("Список пуст");
                else
                    return PrintList2(GetActiveByUserId(id), allPrint) ;

        }

        private string PrintList2(IReadOnlyList<ToDoItem> list, bool allPrint)
        {
            var index = 1;
            var leng = 8;
            var stringToReturn = "";
            foreach (var task in list)
            {
                if (leng < task.TaskName.Length)
                    leng = task.TaskName.Length;
            }

            stringToReturn = HelpFunctions.CheckName("Вот список задач \r\n");

            if (allPrint)
                stringToReturn = $"{stringToReturn}{$"| Номер | {"ID",36} | {"Создана",19} | Состояние | Задача"}\r\n";
            else
                stringToReturn = $"{stringToReturn}{$"| Номер | {"Создана",36} | {"ID",19} | Задача"}\r\n";


            foreach (var task in list)
            {
                if (allPrint)
                    stringToReturn = $"{stringToReturn}{$"| {index++,5} | {task.GuidId,36} | {task.CreateAT.ToString(),19} | {task.State,9} | {task.TaskName}"}\r\n";
                else
                    stringToReturn = $"{stringToReturn}{$"| {index++,5} | {task.GuidId,36} | {task.CreateAT.ToString(),19} | {task.TaskName}"}\r\n";
            }
            return stringToReturn ;
        }
    }
}
