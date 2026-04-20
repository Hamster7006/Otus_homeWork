using Otus_homeWork.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homeWork.Core.DataAccess
{
    public interface IToDoService
    {
        IReadOnlyList<ToDoItem> GetAllByUserId(Guid userId);
        //Возвращает ToDoItem для UserId со статусом Active
        IReadOnlyList<ToDoItem> GetActiveByUserId(Guid userId);
        ToDoItem Add(ToDoUser user, string name);
        void MarkCompleted(Guid id);
        void Delete(Guid id);
    }
}
