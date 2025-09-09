using Otus_homeWork.Help;
using Otus_homeWork.ToDO;

namespace Otus_homeWork.Function
{
    internal class AddFunctionsHW2
    {
        internal static void AddTaskList(string? inputData = null)
        {
            if (!string.IsNullOrEmpty(inputData))
            {
                var temp = new ToDoItem(BaseMenuFunctionHW1.UserData, inputData);
                Program.TaskList.Add(temp);
                if (Program.TaskList.Contains(temp))
                    HelpFunctions.CheckName($"Задача '{inputData}' успешно добавлена");
                else
                    HelpFunctions.CheckName("Ошибка добавления");
            }
            else
            {
                HelpFunctions.CheckName("Напишите задачу для добавления в список");
                inputData = Console.ReadLine();
                
                if (!string.IsNullOrEmpty(inputData))
                {
                    ToDoItem temp = new(BaseMenuFunctionHW1.UserData, name: inputData);
                    Program.TaskList.Add(temp);
                    if (Program.TaskList.Contains(temp))
                        HelpFunctions.CheckName($"Задача '{inputData}' успешно добавлена");
                    else
                        HelpFunctions.CheckName("Ошибка добавления");
                }
                else
                    HelpFunctions.CheckName("Не корректный ввод задачи");
            }
            HelpFunctions.Pause();
        }

        internal static void RemoveTaskList(string? parm = null, bool ch = true)
        {
            if (parm == null)
            {
                Console.Clear();
                PrintTaskList(true, false);
                HelpFunctions.CheckName("Введите номер задачи для удаления! Для удаления всего списка введите 'all'");
                var index = Console.ReadLine();
                if (index == "all")
                    RemoveTaskList("all", false);
                else
                    RemoveTaskList(index, false);
            }
            else if (parm == "all")
            {
                Program.TaskList.RemoveRange(0, Program.TaskList.Count);
                Console.WriteLine("Список очищен");
            }
            else if (parm.Contains(','))
            {
                var changeInd = 0;

                List<string> indArr = [];

                foreach (string str in parm.Split(','))
                {
                    if (!indArr.Contains(str))
                        indArr.Add(str);
                }
                indArr.Sort();

                foreach (var ind in indArr)
                {
                    if (int.TryParse(ind, out var res) && res >= 1 && res - changeInd <= Program.TaskList.Count)
                    {
                        RemoveTaskList($"{res - changeInd}", false);
                        changeInd++;
                    }
                }
            }
            else if (int.TryParse(parm, out var res) && res >= 1 && res <= Program.TaskList.Count)
            {
                var tempTask = Program.TaskList[res - 1];
                Program.TaskList.RemoveAt(res - 1);
                Console.WriteLine($"Задача '{tempTask.TaskName}' удалена");
            }
            else
            {
                Console.WriteLine("Не корректный ввод номерa задачи.");
            }
            if (ch)
                HelpFunctions.Pause();
        }


        internal static void PrintTaskList(bool allPrint, bool pause = true)
        {
            var index = 1;
            var leng = 8;

            if (Program.TaskList.Count == 0)
                Console.WriteLine("Список пуст");
            else
            {
                var chStateActive = false;
                if (!allPrint)
                {
                    foreach (var task in Program.TaskList)
                    {
                        if (task.State == ToDoItemState.Active)
                            chStateActive = true;
                    }
                }

                if (!allPrint && !chStateActive)
                    HelpFunctions.CheckName("Активных задач не обнаружено");
                else
                {
                    foreach (var task in Program.TaskList)
                    {
                        if (leng < task.TaskName.Length)
                            leng = task.TaskName.Length;
                    }

                    HelpFunctions.CheckName("Вот список задач");
                    Console.Write("┌");
                    if (allPrint)
                        HelpFunctions.PrintBorder('-', [6, 37, 20, leng], '┬', '┐');
                    else
                        HelpFunctions.PrintBorder('-', [6, 37, 20, 10, leng], '┬', '┐');

                    if (allPrint)
                        Console.Write("| Номер | {0,36} | {1,19} | Состояние | Задача", "ID", "Создана");
                    else
                        Console.Write("| Номер | {0,36} | {1,19} | Задача", "ID", "Создана");

                    HelpFunctions.PrintFrame(' ', leng - 7, '|', true);

                    Console.Write("├");
                    if (allPrint)
                        HelpFunctions.PrintBorder('-', [6, 37, 20, leng], '┼', '┤');
                    else
                        HelpFunctions.PrintBorder('-', [6, 37, 20, 10, leng], '┼', '┤');

                    bool printBorder;
                    for (int i = 0; i < Program.TaskList.Count; i++)
                    {
                        printBorder = true;
                        if (allPrint)
                        {
                            Console.Write("| {0,5} | {1,36} | {2,19} | {3,9} | {4}",
                                        index++,
                                        Program.TaskList[i].GuidId,
                                        Program.TaskList[i].CreateAT.ToString(),
                                        Program.TaskList[i].State,
                                        Program.TaskList[i].TaskName
                                    );
                            HelpFunctions.PrintFrame(' ', leng - Program.TaskList[i].TaskName.Length - 1, '|', true);
                        }
                        else if (Program.TaskList[i].State == ToDoItemState.Active)
                        {
                            Console.Write("| {0,5} | {1,36} | {2,19} | {3}",
                                        index++,
                                        Program.TaskList[i].GuidId,
                                        Program.TaskList[i].CreateAT.ToString(),
                                        Program.TaskList[i].TaskName
                                    );
                            HelpFunctions.PrintFrame(' ', leng - Program.TaskList[i].TaskName.Length - 1, '|', true);
                        }
                        else
                            printBorder = false;

                        if (printBorder)
                            if (i == Program.TaskList.Count - 1)
                            {
                                Console.Write("└");
                                if (allPrint)
                                    HelpFunctions.PrintBorder('-', [6, 37, 20, leng], '┼', '┤');
                                else
                                    HelpFunctions.PrintBorder('-', [6, 37, 20, 10, leng], '┼', '┤');
                            }
                            else
                            {
                                Console.Write("├");
                                if (allPrint)
                                    HelpFunctions.PrintBorder('-', [6,37,20,leng], '┼','┤');
                                else
                                    HelpFunctions.PrintBorder('-', [6, 37, 20, 10, leng], '┼', '┤');
                            }
                    }
                }
            }
            if (pause)
                HelpFunctions.Pause();
        }
    }
}
