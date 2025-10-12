using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork.Function;
using Otus_homeWork.ToDO;
using Otus_homeWork.UpdHan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homeWork.UsServ
{
    public class UserService : IUserService
    {
        public ToDoUser RegisterUser(long telegramUserId, string telegramUserName)
        {
            var user = new ToDoUser(telegramUserName, telegramUserId);
            return user;
        }
        public ToDoUser? GetUser(long telegramUserId)
        {
            if (UpdateHandler.UserData.TelegramUserId == telegramUserId)
                return UpdateHandler.UserData;
            else
                return null;
        }

        //public UserService(Update update)
        //{
        //    //Update.Message.From
        //    ToDoUser toDoUser = GetUser(telegramUserId: update.Message.From.Id);
        //    if (toDoUser == null) {
        //        RegisterUser(update.Message.From.Id, update.Message.From.Username);
        //    }
        //}
    }
}
