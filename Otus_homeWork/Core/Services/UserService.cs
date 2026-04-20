using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork.Core.Entities;
using Otus_homeWork.TelegramBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homeWork.Core.Services
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
    }
}
