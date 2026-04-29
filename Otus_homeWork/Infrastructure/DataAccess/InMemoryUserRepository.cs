using Otus.ToDoList.ConsoleBot;
using Otus.ToDoList.ConsoleBot.Types;
using Otus_homeWork.Core.DataAccess;
using Otus_homeWork.Core.Entities;
using Otus_homeWork.TelegramBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homeWork.Infrastructure.DataAccess
{

    internal class InMemoryUserRepository : IUserRepository
    {
        List<ToDoUser> inMemoryUserRepository = new List<ToDoUser>(500);
        public void Add(ToDoUser user)
        {
            inMemoryUserRepository.Add(user);
        }

        public ToDoUser? GetUser(Guid userId)
        {
            var user = inMemoryUserRepository.Where(i => i.UserId == userId).ToList();
            if (user.Count == 1)
                return user[0];
            else
                return null;
        }

        public ToDoUser? GetUserByTelegramUserId(long telegramUserId)
        {
            var user = inMemoryUserRepository.Where(i => i.TelegramUserId == telegramUserId).ToList();
            if (user.Count == 1)
                return user[0];
            else
                return null;
        }
    }
}
