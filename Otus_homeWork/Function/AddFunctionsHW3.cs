using Otus_homeWork.Help;
using Otus_homeWork.ToDO;

namespace Otus_homeWork.Function
{
    internal class AddFunctionsHW3
    {
        //public static void Completetask(string? parm = null, bool ch = true)
        public static string Completetask(string? parm = null)
        {
            var str = "";
            if (parm == null)
            {
                //Console.Clear();
                //AddFunctionsHW2.PrintTaskList(true, false);
                str = AddFunctionsHW2.PrintTaskList(true);
                str = $"{str}{HelpFunctions.CheckName("Введите ID задачи для выполнения! Для выполнения всего списка введите 'all'")}";                
                var index = Console.ReadLine();
                if (index == "all")
                    //Completetask("all", false);
                    str = $"{str}{Completetask("all")}";
                else
                    //Completetask(index, false);
                    str = $"{Completetask(index)}";
            }
            else if (parm == "all")
            {
                for (var i = 0; i < Program.TaskList.Count; i++)
                {
                    Program.TaskList[i].State = ToDoItemState.Completed;
                    Program.TaskList[i].ChangedAt = DateTime.Now;

                }
                str = "Список помечен как выполненый";
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
                            str = $"Задача {Program.TaskList[i].TaskName} помечена выполненной.";
                        }
                        else
                            str = $"Задача помечена выполненной ранее: {Program.TaskList[i].ChangedAt}";

                        check = true;
                    }
                }

                if (!check)
                    str = "Не корректный ввод ID задачи.";
                
            }
            return str;
            //if (ch)
            //    HelpFunctions.Pause();
        }
    }
}
