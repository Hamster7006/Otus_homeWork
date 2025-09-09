using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homeWork
{
    internal class LoadHelp
    {

        internal static void LoadCommands()
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
            VariableData.AvalibleComands[6, 1] = "Команда /showtasks Вывести список задач";
            VariableData.AvalibleComands[7, 0] = "/removetask";
            VariableData.AvalibleComands[7, 1] = "Команда /removetask [#] удалить задачу из списка. \n\r" +
                "     Команда без параметра выведет список доступных задач для выбора номера указание номера задачи для удаления. \n\r" +
                "     Команда с параметром 'число' удалит задачу под указанным номером, если она существует \n\r" +
                "     Команда с параметром 'число1,число2..' удалит задачи под указанными номерами, если они существует. Разделитель ',' \n\r" +
                "     Параметр 'all' удалит весь список";
        }
    }
}
