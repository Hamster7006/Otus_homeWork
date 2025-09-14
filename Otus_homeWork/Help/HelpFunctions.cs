using Otus_homeWork.Function;

namespace Otus_homeWork.Help
{
    internal static class HelpFunctions
    {
        internal static void Pause()
        {
            Console.WriteLine("\n\r \n\rДля продолжения нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void CheckName(string? print = null)
        {
            if (BaseMenuFunctionHW1.UserData.TelegramUserName == null)
                Console.WriteLine(print);
            else
                Console.WriteLine(BaseMenuFunctionHW1.UserData.TelegramUserName + ", " + print);
        }

        internal static void PrintAvaliableCommandsOrHelp(int j, bool ln)
        {
            bool ch;

            for (int i = 0; i < VariableData.Length; i++)
            {
                ch = true;
                if (VariableData.AvalibleComands[i, 0] == "/echo")
                {
                    if (BaseMenuFunctionHW1.UserData.TelegramUserName != null)
                        Console.Write(VariableData.AvalibleComands[i, j]);
                    else
                        ch = false;
                }
                else
                    Console.Write(VariableData.AvalibleComands[i, j]);

                if (ch && i < VariableData.Length - 1)
                {
                    if (ln)
                        Console.WriteLine();
                    else
                        Console.Write(", ");
                }
            }
            Console.WriteLine();
        }

        internal static void InitCommandsAndHelp()
        {
            VariableData.AvalibleComands[0, 0] = "/start";
            VariableData.AvalibleComands[0, 1] = "Команда /start запускает знакомство, после которого достуны дополнительные команды";
            VariableData.AvalibleComands[1, 0] = "/help";
            VariableData.AvalibleComands[1, 1] = "Команда /help информация по командам (этот текст)";
            VariableData.AvalibleComands[2, 0] = "/info";
            VariableData.AvalibleComands[2, 1] = "Команда /info версия программы и дата релиза";
            VariableData.AvalibleComands[3, 0] = "/echo";
            VariableData.AvalibleComands[3, 1] = "Команда /echo <String>  режим ЭХО. Выводи в консоль <string>. Параметр <string> обязаителен для ввода.";
            VariableData.AvalibleComands[4, 0] = "/exit";
            VariableData.AvalibleComands[4, 1] = "Команда /exit выход из программы";
            VariableData.AvalibleComands[5, 0] = "/addtask";
            VariableData.AvalibleComands[5, 1] = "Команда /addtask [#] добавить задачу в список. \n\r" +
                "     Команда без параметра запросит ввод задачи для добавления \n\r" +
                "     Команда с параметром (строка) добавит задачу в список.";
            VariableData.AvalibleComands[6, 0] = "/showtasks";
            VariableData.AvalibleComands[6, 1] = "Команда /showtasks Вывести список актуальных (не выполненных) задач";
            VariableData.AvalibleComands[7, 0] = "/showalltasks";
            VariableData.AvalibleComands[7, 1] = "Команда /showalltasks Вывести список всех задач";
            VariableData.AvalibleComands[8, 0] = "/removetask";
            VariableData.AvalibleComands[8, 1] = "Команда /removetask [#] удалить задачу из списка. \n\r" +
                "     Команда без параметра выведет список доступных задач для выбора номера и запросит указание номера задачи для удаления. \n\r" +
                "     Команда с параметром 'число' удалит задачу под указанным номером, если она существует \n\r" +
                "     Команда с параметром 'число1,число2..' удалит задачи под указанными номерами, если они существует. Разделитель ',' \n\r" +
                "     Параметр 'all' удалит весь список";
            VariableData.AvalibleComands[9, 0] = "/completetask";
            VariableData.AvalibleComands[9, 1] = "Команда /completetask [#] пометить задачу выполненной из списка. \n\r" +
                "     Команда без параметра выведет список доступных задач для выбора ID и запросит указание ID задачи для выполненния. \n\r" +
                "     Команда с параметром 'ID' пометит задачу под указанным ID ка выполненную, если она существует \n\r" +
                "     Параметр 'all' пометит выполненным весь список";

        }

        static internal void PrintBorder(
                char start, int[] lenArr, char mid, char end, bool wl = false
        )
        {
            for (int i = 0; i < lenArr.Length; i++)
            {
                if (i != lenArr.Length - 1)
                    PrintFrame(start, lenArr[i], mid);
                else
                    PrintFrame(start, lenArr[i], end, true);
            }
        }
        static internal void PrintFrame(char start, int len, char end, bool wl = false)
        {
            for (int i = 0; i <= len; i++)
            {
                Console.Write(start);
            }
            Console.Write(end);
            if (wl)
                Console.WriteLine();
        }

        static internal int ParseAndValidateInt(string? str, int min, int max) 
        {
            int returnInt;
            ValidateString(str);
            if (!int.TryParse(str, out returnInt))
                throw new ArgumentException($"Ошибка ввода параметра (Не число).");
            
            if (returnInt < min || returnInt > max)
                throw new ArgumentException($"Ошибка ввода параметра (Меньше 1 или больше 100).");
            
            
            return returnInt;
        }

        static internal void ValidateString(string? str) { 
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentException("Строка пустая или состоит из пробелов");
        }
    }

}
