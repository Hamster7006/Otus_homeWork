
using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork.Help;
using Otus_homeWork.ToDO;
using Otus_homeWork.UpdHan;

namespace Otus_homeWork.Function
{
    internal class BaseMenuFunctionHW1
    {
        //internal static ToDoUser UserData = new();


        //internal static void Start(UserService.UserService user, Update update)
        //{
        //    if (user.GetUser(update.Message.From.Id) == null )
        //        UserData = user.RegisterUser(update.Message.From.Id, update.Message.From.Username);
        //}

        //internal static void Help()
        //{
        //    //Console.Clear();
        //    HelpFunctions.CheckName();
        //    HelpFunctions.PrintAvaliableCommandsOrHelp(1, true);
        //    HelpFunctions.Pause();
        //}
        //internal static void Echo(string stringInput)
        //{
        //    Console.WriteLine(stringInput);
        //    //HelpFunctions.Pause();
        //}
        internal static void Info(Chat chat, ITelegramBotClient telegramBotClient)
        {
            telegramBotClient.SendMessage(chat, $"Версия программы: {VariableData.VersionBot} \r\nДата релиза программы: {VariableData.DateRelise}");
        }


    }
}
