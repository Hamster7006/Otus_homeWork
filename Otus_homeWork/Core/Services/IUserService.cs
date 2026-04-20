using Otus_homeWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homeWork.Core.Services
{
    interface IUserService
    {
        ToDoUser RegisterUser(long telegramUserId, string telegramUserName);
        ToDoUser? GetUser(long telegramUserId);
    }
}
