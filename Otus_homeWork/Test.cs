using Otus_homeWork.Function;
using Otus_homeWork.Help;
using Otus_homeWork.ToDO;

namespace Otus_homeWork
{
    internal class Test
    {
        /// <summary>
        /// Тестирование программы: Загрузка данных
        /// </summary>
        internal static void TestLoad()
        {
            BaseMenuFunctionHW1.Start();

            for (int i = 0; i < 10; i++)
            {
                AddFunctionsHW2.AddTaskList($"35 'Автотест': Задача {i} добавление");
            }
            AddFunctionsHW2.PrintTaskList(true);
            TestHW();
        }

        /// <summary>
        /// Тестирование программы ДЗ : Логика
        /// </summary>
        internal static void TestHW(int testCase = 0)
        {
            switch (testCase)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    HelpFunctions.Pause("Добавление 11 задачи ( превышение лимита задач)");
                    Console.ResetColor();
                    AddFunctionsHW2.AddTaskList($"35 'Автотест': Задача 11 добавление");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    HelpFunctions.Pause("Удаляем 10 задачу и добавляем новую + вывод");
                    Console.ResetColor();
                    AddFunctionsHW2.RemoveTaskList("10");
                    AddFunctionsHW2.AddTaskList($"'Автотест': Задача 10 NEW добавление");
                    AddFunctionsHW2.PrintTaskList(true);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    HelpFunctions.Pause("Удаляем 9 задачу и добавляем новую c ошибкой длины + вывод");
                    Program.TaskLengthLimittaskLength = 4;
                    Console.ResetColor();
                    AddFunctionsHW2.RemoveTaskList("9");
                    AddFunctionsHW2.AddTaskList($"'Автотест': Задача 10 NEW добавление");
                    AddFunctionsHW2.PrintTaskList(true);
                    break;
                case 2:
                    Program.TaskLengthLimittaskLength = 100;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    HelpFunctions.Pause("Добавляем задачу с существующим именем + вывод");
                    Console.ResetColor();
                    AddFunctionsHW2.AddTaskList($"'Автотест': Задача 2 добавление");
                    AddFunctionsHW2.PrintTaskList(true);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    HelpFunctions.Pause("Проверка Catch общего (прерывания программы)");
                    Console.ResetColor();
                    throw new Exception("EXIT");
                    break;
            }
        }
    }
}
