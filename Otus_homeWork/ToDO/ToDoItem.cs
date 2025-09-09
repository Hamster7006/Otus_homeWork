namespace Otus_homeWork.ToDO
{
    internal enum ToDoItemState {
        Active,
        Completed
    };

    internal class ToDoItem
    {
        public Guid GuidId { get; set; }
        public DateTime CreateAT { get; set; }

        private ToDoUser User;
        private ToDoItemState State;
        private DateTime? StateChangedAt { get; set; }
        private string Name;

        public ToDoItem(ToDoUser user, string name){
            GuidId = Guid.NewGuid();
            Name = name;
            User = user;
            State = ToDoItemState.Active;
            CreateAT = DateTime.Now;
        }

    }
}
