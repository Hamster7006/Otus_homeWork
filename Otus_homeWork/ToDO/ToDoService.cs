using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homeWork.ToDO
{
    public class ToDoService : IToDoService
    {
        public IReadOnlyList<ToDoItem> GetAllByUserId(Guid userId)
        {
            var tempList = new List<ToDoItem>();
            foreach (var temp in UpdateHandler.UpdateHandler.TaskList)
            {
                if (temp.User.UserId == userId)
                    tempList.Add(temp);
            }
            return tempList;
        }
        //Возвращает ToDoItem для UserId со статусом Active
        public IReadOnlyList<ToDoItem> GetActiveByUserId(Guid userId)
        {
            var tempList = new List<ToDoItem>();
            foreach (var temp in UpdateHandler.UpdateHandler.TaskList)
            {
                if (temp.User.UserId == userId && temp.State == ToDoItemState.Active)
                    tempList.Add(temp);
            }
            return tempList;
        }
        public ToDoItem Add(ToDoUser user, string name)
        {
            return null;
        }
        public void MarkCompleted(Guid id)
        {
        
        }
        public void Delete(Guid id)
        {
            
        }

    }
}
