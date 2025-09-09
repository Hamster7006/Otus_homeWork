using Otus_homeWork.Function;
using Otus_homeWork.Help;
using Otus_homeWork.ToDO;

namespace Otus_homeWork
{
    internal class Test
    {
        internal static void TestLoad()
        {
            BaseMenuFunctionHW1.Start();

            for (int i = 0; i < 10; i++)
            {
                AddFunctionsHW2.AddTaskList($"'Автотест': Задача {i} добавление");
            }
            AddFunctionsHW2.AddTaskList($"'Автотест': ОЧЕНЬ БОЛЬШАЯ Задача добавление");

            Console.WriteLine("'Автотест': 2 задача выполнена");
            Program.TaskList[1].State = ToDoItemState.Completed;
            Program.TaskList[1].ChangedAt = DateTime.Now;
            HelpFunctions.Pause();

            //test 1

            Console.Clear();
            Console.WriteLine("'Автотест 1 ': /showtasks");
            AddFunctionsHW2.PrintTaskList(false);
            Console.Clear();
            Console.WriteLine("'Автотест 1': /showalltasks");
            AddFunctionsHW2.PrintTaskList(true);

            // test 2 correct input
            Console.WriteLine("'Автотест 2': /completetask (корректный ввод)");
            AddFunctionsHW3.Completetask();
            Console.Clear();
            Console.WriteLine("'Автотест 2': /showtasks");
            AddFunctionsHW2.PrintTaskList(false);
            Console.Clear();
            Console.WriteLine("'Автотест 2': /showalltasks");
            AddFunctionsHW2.PrintTaskList(true);

            // test 3 err input
            Console.WriteLine("'Автотест 3': /completetask (Ошибочный ввод)");
            AddFunctionsHW3.Completetask();
            Console.Clear();
            Console.WriteLine("'Автотест 3': /showtasks");
            AddFunctionsHW2.PrintTaskList(false);
            Console.Clear();
            Console.WriteLine("'Автотест 3': /showalltasks");
            AddFunctionsHW2.PrintTaskList(true);


            // test 4 all
            Console.WriteLine("'Автотест 4': /completetask all");
            AddFunctionsHW3.Completetask("all");
            Console.Clear();
            Console.WriteLine("'Автотест 4': /showalltasks");
            AddFunctionsHW2.PrintTaskList(true);

            // test 5 err2 input
            Console.WriteLine("'Автотест 5': /completetask (Корректный ввод АВТО 1 задачи, когда она уже отмечена выполненной)");
            AddFunctionsHW3.Completetask(Program.TaskList[0].GuidId.ToString());

            // test 6 remove item
            Console.WriteLine("'Автотест 6': /removetask 1 ");
            AddFunctionsHW2.RemoveTaskList("1");
            Console.Clear();
            Console.WriteLine("'Автотест 6': /showalltasks");
            AddFunctionsHW2.PrintTaskList(true);

            // test 7 remove all item
            Console.WriteLine("'Автотест 7': /removetask all ");
            AddFunctionsHW2.RemoveTaskList("all");
            Console.Clear();
            Console.WriteLine("'Автотест 7': /showtasks");
            AddFunctionsHW2.PrintTaskList(false);
            Console.Clear();
            Console.WriteLine("'Автотест 7': /showalltasks");
            AddFunctionsHW2.PrintTaskList(true);
        }
    }
}
