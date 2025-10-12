using Otus_homeWork.CustomExept;
using Otus_homeWork.Help;
using Otus_homeWork.ToDO;
using System.Linq;

namespace Otus_homeWork.Function
{
    internal class AddFunctionsHW2
    {
        internal static string AddTaskList(string? inputData = null)
        {
            var str = "";
            if (UpdateHandler.UpdateHandler.TaskList.Count + 1 <= UpdateHandler.UpdateHandler.MaxLengthList)
            {
                if (!string.IsNullOrEmpty(inputData))
                {
                    //var lengthTaskInput = inputData.Split(' ')[0];
                    //var taskLengthLimittaskLength = HelpFunctions.ParseAndValidateInt(lengthTaskInput, 1, 100);
                    //inputData = inputData.Replace($"{lengthTaskInput} ","");

                    if (inputData.Length > UpdateHandler.UpdateHandler.TaskLengthLimittaskLength)
                        //throw new TaskLengthLimitException(inputData.Length, Program.TaskLengthLimittaskLength);
                        throw new CustomException($"Длина задачи '{inputData.Length}' превышает максимально допустимое значение {UpdateHandler.UpdateHandler.TaskLengthLimittaskLength}");

                    if (UpdateHandler.UpdateHandler.TaskList.Count != 0)
                        foreach (var loadedTask in UpdateHandler.UpdateHandler.TaskList)
                        {
                            if (loadedTask.TaskName == inputData)
                                //throw new DuplicateTaskException(inputData);
                                throw new CustomException($"Задача '{inputData}' уже существует");
                        }

                    var temp = new ToDoItem(BaseMenuFunctionHW1.UserData, inputData);


                    UpdateHandler.UpdateHandler.TaskList.Add(temp);
                    str = HelpFunctions.CheckName($"Задача '{inputData}' успешно добавлена");
                }
                else
                {
                    str = HelpFunctions.CheckName("Не корректный ввод задачи. Требуется сразу после команды указать задачу для добавлвения");
                }
                //HelpFunctions.Pause();
                return str;
            }
            else
                //throw new TaskCountLimitException(Program.MaxLengthList);
                throw new CustomException($"Превышено максимальное количество задач равное {UpdateHandler.UpdateHandler.MaxLengthList}");
        }

        //internal static void RemoveTaskList(string? inputParam = null, bool checkPrintPause = true)
        internal static string RemoveTaskList(string? inputParam = null)
        {
            var strToReturn = "";
            if (inputParam == null)
            {
                //Console.Clear();
                strToReturn = HelpFunctions.CheckName("Не корректный ввод задачи. Требуется сразу после команды указать номер задачу для удаления");
            }
            else if (inputParam == "all")
            {
                UpdateHandler.UpdateHandler.TaskList.RemoveRange(0, UpdateHandler.UpdateHandler.TaskList.Count);
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
                    if (int.TryParse(ind, out var res) && res >= 1 && res - changeInd <= UpdateHandler.UpdateHandler.TaskList.Count)
                    {
                        //RemoveTaskList($"{res - changeInd}", false);
                        strToReturn = $"{strToReturn}\r\n{RemoveTaskList($"{res - changeInd}")}";
                        changeInd++;
                    }
                }
            }
            else if (int.TryParse(inputParam, out var res) && res >= 1 && res <= UpdateHandler.UpdateHandler.TaskList.Count)
            {
                var tempTask = UpdateHandler.UpdateHandler.TaskList[res - 1];
                UpdateHandler.UpdateHandler.TaskList.RemoveAt(res - 1);
                strToReturn = $"Задача '{tempTask.TaskName}' удалена";
            }
            else
            {
                strToReturn = "Не корректный ввод номерa задачи.";
            }
            return strToReturn;
            //if (checkPrintPause)
            //    HelpFunctions.Pause();
        }


        //internal static void PrintTaskList(bool allPrint, bool pause = true)
        internal static string PrintTaskList(bool allPrint)
        {
            var index = 1;
            var leng = 8;
            var stringToReturn = "";

            if (UpdateHandler.UpdateHandler.TaskList.Count == 0)
                //Console.WriteLine("Список пуст");
                stringToReturn = HelpFunctions.CheckName("Список пуст");
            else
            {
                var chStateActive = false;
                if (!allPrint)
                {
                    foreach (var task in UpdateHandler.UpdateHandler.TaskList)
                    {
                        if (task.State == ToDoItemState.Active)
                            chStateActive = true;
                    }
                }

                if (!allPrint && !chStateActive)
                    stringToReturn = HelpFunctions.CheckName("Активных задач не обнаружено");
                else
                {
                    foreach (var task in UpdateHandler.UpdateHandler.TaskList)
                    {
                        if (leng < task.TaskName.Length)
                            leng = task.TaskName.Length;
                    }

                    stringToReturn = HelpFunctions.CheckName("Вот список задач \r\n");
                    stringToReturn = $"{stringToReturn}┌";
                    if (allPrint)
                        stringToReturn = $"{stringToReturn}{HelpFunctions.PrintBorder('─', [6, 37, 20, 10, leng], '┬', '┐')}"; 
                    else
                        stringToReturn = $"{stringToReturn}{HelpFunctions.PrintBorder('─', [6, 37, 20, leng], '┬', '┐')}";

                    if (allPrint)
                        //var temp = ;
                        stringToReturn =$"{stringToReturn}{$"| Номер | {"ID",36} | {"Создана",19} | Состояние | Задача"}";
                    else
                        //Console.Write("| Номер | {0,36} | {1,19} | Задача", "ID", "Создана");
                        stringToReturn = $"{stringToReturn}{$"| Номер | {"Создана",36} | {"ID",19} | Задача"}";

                    stringToReturn = $"{stringToReturn}{HelpFunctions.PrintFrame(' ', leng - 7, '|', true)}";

                    stringToReturn = $"{stringToReturn}├";
                    if (allPrint)
                        stringToReturn = $"{stringToReturn}{HelpFunctions.PrintBorder('─', [6, 37, 20, 10, leng], '┼', '┤')}"; 
                    else
                        stringToReturn = $"{stringToReturn}{HelpFunctions.PrintBorder('─', [6, 37, 20, leng], '┼', '┤')}";

                    bool printBorder;
                    for (int i = 0; i < UpdateHandler.UpdateHandler.TaskList.Count; i++)
                    {
                        printBorder = true;
                        if (allPrint)
                        {
                            stringToReturn = $"{stringToReturn}{$"| {index++,5} | {UpdateHandler.UpdateHandler.TaskList[i].GuidId,36} "+
                                    $"| {UpdateHandler.UpdateHandler.TaskList[i].CreateAT.ToString(),19} | {UpdateHandler.UpdateHandler.TaskList[i].State,9} | {UpdateHandler.UpdateHandler.TaskList[i].TaskName}"
                                }";
                            stringToReturn = $"{stringToReturn}{HelpFunctions.PrintFrame(' ', leng - UpdateHandler.UpdateHandler.TaskList[i].TaskName.Length - 1, '|', true)}";
                        }
                        else if (UpdateHandler.UpdateHandler.TaskList[i].State == ToDoItemState.Active)
                        {
                            stringToReturn = $"{stringToReturn}{($"| {index++,5} | {UpdateHandler.UpdateHandler.TaskList[i].GuidId,36} | {UpdateHandler.UpdateHandler.TaskList[i].CreateAT.ToString(),19} "+
                                    $"| {UpdateHandler.UpdateHandler.TaskList[i].TaskName}"
                                )}";
                            stringToReturn = $"{stringToReturn}{HelpFunctions.PrintFrame(' ', leng - UpdateHandler.UpdateHandler.TaskList[i].TaskName.Length - 1, '|', true)}";
                        }
                        else
                            printBorder = false;

                        if (printBorder)
                            if (i == UpdateHandler.UpdateHandler.TaskList.Count - 1)
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
                }
                
            }

            return stringToReturn;
            //if (pause)
            //    HelpFunctions.Pause();
        }
    }
}
