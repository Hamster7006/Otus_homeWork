namespace Otus_homeWork.Core.Entities
{
    public enum ToDoItemState
    {
        Active,
        Completed
    };

    public class ToDoItem
    {
        public Guid GuidId { get; set; }
        public DateTime CreateAT { get; set; }
        public string TaskName { get; set; }
        public ToDoUser User { get; set; }
        public ToDoItemState State { get; set; }
        public DateTime ChangedAt { get; set; }
        public ToDoItem(ToDoUser user, string name)
        {
            GuidId = Guid.NewGuid();
            TaskName = name;
            User = user;
            State = ToDoItemState.Active;
            CreateAT = DateTime.Now;
        }
    }
}
