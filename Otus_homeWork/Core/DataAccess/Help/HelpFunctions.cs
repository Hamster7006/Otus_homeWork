using Otus.ToDoList.ConsoleBot;
using Otus_homeWork.Core.Exceptions;
using Otus_homeWork.TelegramBot;


namespace Otus_homeWork.Core.DataAccess.Help
{
    internal static class HelpFunctions
    {
        internal static string CheckName(string print)
        {
            if (string.IsNullOrEmpty(UpdateHandler.UserData.TelegramUserName))
                return print;
            else
                return $"{UpdateHandler.UserData.TelegramUserName}, {print}";
        }

        internal static string PrintAvaliableCommandsOrHelp(int j)
        {
            string ret = "";
            var acsessCommands = new List<string> ();
            acsessCommands = ["/start", "/info", "/help"];
            string temp = "";
            for (int i = 0; i < VariableData.Length; i++)
            {
                if (j == 0)
                     temp = ", ";
                else
                    temp = "\r\n";
                ;
                if (
                    string.IsNullOrEmpty(UpdateHandler.UserData.TelegramUserName)
                ){
                    if (acsessCommands.Contains(VariableData.AvalibleComands[i, 0]))
                        ret = $"{ret}{temp}{VariableData.AvalibleComands[i, j]}";
                } 
                else
                    ret = $"{ret}{temp}{VariableData.AvalibleComands[i, j]}";
            }

            if(ret.StartsWith(','))
                ret = ret.Substring(2);
                
            return ret ;
        }

        internal static void InitCommandsAndHelp()
        {
            VariableData.AvalibleComands[0, 0] = "/start";
            VariableData.AvalibleComands[0, 1] = "Команда /start запускает знакомство, после которого достуны дополнительные команды";
            VariableData.AvalibleComands[1, 0] = "/help";
            VariableData.AvalibleComands[1, 1] = "Команда /help информация по командам (этот текст)";
            VariableData.AvalibleComands[2, 0] = "/info";
            VariableData.AvalibleComands[2, 1] = "Команда /info версия программы и дата релиза";
            VariableData.AvalibleComands[3, 0] = "/exit";
            VariableData.AvalibleComands[3, 1] = "Команда /exit выход из программы";
            VariableData.AvalibleComands[4, 0] = "/addtask";
            VariableData.AvalibleComands[4, 1] = "Команда '/addtask <string>' добавить задачу в список. \n\r" +
                "     /addtask <string> - Команда с параметром (строка - наименование задачи) добавит задачу в список.";
            VariableData.AvalibleComands[5, 0] = "/showtasks";
            VariableData.AvalibleComands[5, 1] = "Команда /showtasks Вывести список актуальных (не выполненных) задач";
            VariableData.AvalibleComands[6, 0] = "/showalltasks";
            VariableData.AvalibleComands[6, 1] = "Команда /showalltasks Вывести список всех задач";
            VariableData.AvalibleComands[7, 0] = "/removetask";
            VariableData.AvalibleComands[7, 1] = "Команда /removetask <int> удалить задачу из списка. \n\r" +
                "     Команда с параметром 'число' удалит задачу под указанным номером, если она существует \n\r" +
                "     Команда с параметром 'число1,число2..' удалит задачи под указанными номерами, если они существует. Разделитель ',' \n\r" +
                "     Параметр 'all' удалит весь список";
            VariableData.AvalibleComands[8, 0] = "/completetask";
            VariableData.AvalibleComands[8, 1] = "Команда /completetask [#] пометить задачу выполненной из списка. \n\r" +
                "     Команда без параметра выведет список доступных задач для выбора ID и запросит указание ID задачи для выполненния. \n\r" +
                "     Команда с параметром 'ID' пометит задачу под указанным ID ка выполненную, если она существует \n\r" +
                "     Параметр 'all' пометит выполненным весь список";

        }

        static internal string PrintBorder(
            char start, int[] lenArr, char mid, char end
        )
        {
            var str = "";
            for (int i = 0; i < lenArr.Length; i++)
            {
                if (i != lenArr.Length - 1)
                    str = $"{str}{PrintFrame(start, lenArr[i], mid)}";
                else
                    str = $"{str}{PrintFrame(start, lenArr[i], end, true)}";
            }
            return str;
        }
        static internal string PrintFrame(char start, int len, char end, bool wl = false)
        {
            var str = "";
            for (int i = 0; i <= len; i++)
            {
                str = $"{str}{start}";
            }
            str = $"{str}{end}";
            if (wl)
                str = $"{str}\r\n";

            return str ;
        }

        static internal int ParseAndValidateInt(string? str, int min, int max) 
        {
            int returnInt;
            ValidateString(str);
            if (!int.TryParse(str, out returnInt))
                throw new CustomException($"Ошибка ввода параметра (Не число).");
            
            if (returnInt < min || returnInt > max)
                throw new CustomException($"Ошибка ввода параметра (Меньше {min} или больше {max}).");
            
            
            return returnInt;
        }

        static internal void ValidateString(string? str) { 
            if (string.IsNullOrWhiteSpace(str))
                throw new CustomException("Строка пустая или состоит из пробелов");
        }
    }

}
