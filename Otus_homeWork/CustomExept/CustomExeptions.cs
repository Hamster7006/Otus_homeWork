using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homeWork.CustomExept
{
    internal class TaskCountLimitException : Exception
    {
        public TaskCountLimitException(string message)
                : base (message)
        { }

        public TaskCountLimitException(int taskCountLimit)
                : this($"Превышено максимальное количество задач равное {taskCountLimit}")
        { }
    }
}
