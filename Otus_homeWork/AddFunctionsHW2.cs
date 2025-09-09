using Otus_homeWork.Help;

namespace Otus_homeWork
{
    internal class AddFunctionsHW2
    {
        internal static void AddTaskList(string? inputData = null)
        {
            if (!string.IsNullOrEmpty(inputData))
            {
                Program.TaskList.Add(inputData);
                if (Program.TaskList.Contains(inputData))
                    HelpFunctions.NullOrWhiteSpaseName($"Задача '{inputData}' успешно добавлена");
                else
                    HelpFunctions.NullOrWhiteSpaseName("Ошибка добавления");
            }
            else
            {
                HelpFunctions.NullOrWhiteSpaseName("Напишите задачу для добавления в список");
                inputData = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputData))
                {
                    Program.TaskList.Add(inputData);
                    if (Program.TaskList.Contains(inputData))
                        HelpFunctions.NullOrWhiteSpaseName($"Задача '{inputData}' успешно добавлена");
                    else
                        HelpFunctions.NullOrWhiteSpaseName("Ошибка добавления");
                }
                else
                    HelpFunctions.NullOrWhiteSpaseName("Не корректный ввод задачи");
            }
            HelpFunctions.Pause();
        }

        /// <summary>
        /// удаление задачи, задач или всего списка
        /// </summary>
        /// <param name="parm"></param> индекс\индексы для удаления
        /// <param name="ch"></param> вызов паузы, используется, тк функция имеет рекурсию
        internal static void RemoveTaskList(string? parm = null, bool ch = true)
        {
            if (parm == null)
            {
                PrintTaskList(false);
                HelpFunctions.NullOrWhiteSpaseName("Введите номер задачи для удаления! Для удаления всего списка введите 'all'");
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
            else if ( parm.Contains(',') )
            {
                var changeInd = 0;

                List<string> indArr = new List<string>();

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
                        RemoveTaskList($"{res-changeInd}",false);
                        changeInd++;
                    }
                }
            }
            else if (int.TryParse(parm, out var res) && res >= 1 && res <= Program.TaskList.Count)
            {
                var tempTask = Program.TaskList[res-1];
                Program.TaskList.RemoveAt(res-1);
                Console.WriteLine($"Задача '{tempTask}' удалена");
            }
            else
            {
                Console.WriteLine("Не корректный ввод номерa задачи.");
            }
            if(ch)
                HelpFunctions.Pause();
        }

        /// <summary>
        /// красивый вывод таблицы
        /// </summary>
        /// <param name="clear"></param> очистка консоли
        /// <param name="pause"></param> вызов паузы, используется, тк функция является частью другой функии 
        internal static void PrintTaskList(bool pause = true)
        {
            var index = 1;
            var leng = 8;
            Console.Clear();

            if (Program.TaskList.Count == 0)
                Console.WriteLine("Список пуст");
            else
            {
                HelpFunctions.NullOrWhiteSpaseName("Вот список задач");
                foreach (var task in Program.TaskList)
                {
                    if (leng < task.Length)
                        leng = task.Length;
                }

                Console.Write("┌-------┬");
                PrintFreame('-', leng, '┐');
                Console.Write("| Номер | Задача");
                PrintFreame(' ', leng - 7, '|');
                Console.Write("├-------┼");
                PrintFreame('-', leng, '┤');

                for (int i = 0; i < Program.TaskList.Count; i++)
                {
                    Console.Write("| {0,5} | {1}", index++, Program.TaskList[i]);
                    PrintFreame(' ', leng - Program.TaskList[i].Length - 1, '|');

                    if (i == Program.TaskList.Count - 1)
                    {
                        Console.Write("└-------┴");
                        PrintFreame('-', leng, '┘');
                    }
                    else
                    {
                        Console.Write("├-------┼");
                        PrintFreame('-', leng, '┤');
                    }
                }
            }
            if (pause)
                HelpFunctions.Pause();
        }

        /// <summary>
        /// рисование разделителей динамически
        /// </summary>
        /// <param name="start"></param> символ которым рисуем
        /// <param name="len"></param> длина рисования
        /// <param name="end"></param> конечный символ
        static void PrintFreame(char start, int len, char end)
        {
            for (int i = 0; i <= len; i++)
            {
                Console.Write(start);
            }
            Console.WriteLine(end);
        }
    }
}
