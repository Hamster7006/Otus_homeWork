using Otus_homeWork.CustomExept;
using Otus_homeWork.Function;
using Otus_homeWork.Help;
using Otus_homeWork.UpdHan;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homeWork.ToDO
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
                        //str = $"Задача {UpdateHandler.TaskList[i].TaskName} помечена выполненной.";
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
                    //Console.WriteLine("Список пуст");
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
            stringToReturn = $"{stringToReturn}┌";


            if (allPrint)
            {
                stringToReturn = $"{stringToReturn}{HelpFunctions.PrintBorder('─', [6, 37, 20, 10, leng], '┬', '┐')}";
                stringToReturn = $"{stringToReturn}{$"| Номер | {"ID",36} | {"Создана",19} | Состояние | Задача"}";
                stringToReturn = $"{stringToReturn}{HelpFunctions.PrintFrame(' ', leng - 7, '|', true)}";
                stringToReturn = $"{stringToReturn}├";
                stringToReturn = $"{stringToReturn}{HelpFunctions.PrintBorder('─', [6, 37, 20, 10, leng], '┼', '┤')}";
            }
            else
            {
                stringToReturn = $"{stringToReturn}{HelpFunctions.PrintBorder('─', [6, 37, 20, leng], '┬', '┐')}";
                stringToReturn = $"{stringToReturn}{$"| Номер | {"Создана",36} | {"ID",19} | Задача"}";
                stringToReturn = $"{stringToReturn}{HelpFunctions.PrintFrame(' ', leng - 7, '|', true)}";
                stringToReturn = $"{stringToReturn}├";
                stringToReturn = $"{stringToReturn}{HelpFunctions.PrintBorder('─', [6, 37, 20, leng], '┼', '┤')}";
            }

            foreach (var task in list)
            {
                if (allPrint)
                {
                    stringToReturn = $"{stringToReturn}{$"| {index++,5} | {task.GuidId,36} | {task.CreateAT.ToString(),19} | {task.State,9} | {task.TaskName}"}";
                    stringToReturn = $"{stringToReturn}{HelpFunctions.PrintFrame(' ', leng - task.TaskName.Length - 1, '|', true)}";
                }
                else
                {
                    stringToReturn = $"{stringToReturn}{$"| {index++,5} | {task.GuidId,36} | {task.CreateAT.ToString(),19} | {task.TaskName}"}";
                    stringToReturn = $"{stringToReturn}{HelpFunctions.PrintFrame(' ', leng - task.TaskName.Length - 1, '|', true)}";
                }
                if (task == list[^1])
                {
                    stringToReturn = $"{stringToReturn}└";
                    if (allPrint)
                        stringToReturn = $"{stringToReturn}{HelpFunctions.PrintBorder('─', [6, 37, 20, 10, leng], '┴', '┘')}";
                    else
                        stringToReturn = $"{stringToReturn}{HelpFunctions.PrintBorder('─', [6, 37, 20, leng], '┴', '┘')}";
                }
                else
                {
                    stringToReturn = $"{stringToReturn}├";
                    if (allPrint)
                        stringToReturn = $"{stringToReturn}{HelpFunctions.PrintBorder('─', [6, 37, 20, 10, leng], '┼', '┤')}";
                    else
                        stringToReturn = $"{stringToReturn}{HelpFunctions.PrintBorder('─', [6, 37, 20, leng], '┼', '┤')}";
                }
            }
            return stringToReturn ;
        }
    }
}
