namespace Otus_homeWork.ToDO
{
    internal class ToDoUser
    {
        private readonly DateTime registeredAt;
        private readonly Guid userId;

        public Guid UserId => userId;
        public string TelegramUserName { get; set; }
        public DateTime RegisteredAt => registeredAt;
        public ToDoUser(string telegramUserName = "NoName")

        {
            registeredAt = DateTime.UtcNow;
            userId = Guid.NewGuid();
            TelegramUserName = telegramUserName;
        }
    }
}
