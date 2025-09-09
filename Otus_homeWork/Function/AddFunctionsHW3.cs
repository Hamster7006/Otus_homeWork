using Otus_homeWork.Help;
using Otus_homeWork.ToDO;

namespace Otus_homeWork.Function
{
    internal class AddFunctionsHW3
    {
        public static void Completetask(string? parm = null, bool ch = true)
        {
            if (parm == null)
            {
                Console.Clear();
                AddFunctionsHW2.PrintTaskList(true, false);
                HelpFunctions.CheckName("Введите ID задачи для выполнения! Для выполнения всего списка введите 'all'");
                var index = Console.ReadLine();
                if (index == "all")
                    Completetask("all", false);
                else
                    Completetask(index, false);
            }
            else if (parm == "all")
            {
                for (var i = 0; i < Program.TaskList.Count; i++)
                {
                    Program.TaskList[i].State = ToDoItemState.Completed;
                    Program.TaskList[i].ChangedAt = DateTime.Now;

                }
                Console.WriteLine("Список помечен как выполненый");
            }
            else
            {
                var check = false;
                for (var i = 0; i < Program.TaskList.Count; i++)
                {
                    if (Program.TaskList[i].GuidId.ToString() == parm)
                    {
                        if (Program.TaskList[i].State != ToDoItemState.Completed)
                        {
                            Program.TaskList[i].State = ToDoItemState.Completed;
                            Program.TaskList[i].ChangedAt = DateTime.Now;
                            Console.WriteLine($"Задача {Program.TaskList[i].TaskName} помечена выполненной.");
                        }
                        else
                            Console.WriteLine($"Задача помечена выполненной ранее: {Program.TaskList[i].ChangedAt}");

                        check = true;
                    }
                }

                if (!check)
                    Console.WriteLine("Не корректный ввод ID задачи.");
            }
            if (ch)
                HelpFunctions.Pause();
        }
    }
}
