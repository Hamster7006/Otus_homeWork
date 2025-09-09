namespace Otus_homeWork.ToDO
{
    internal class ToDoUser
    {
        public Guid UserId { get; set; }
        public string TelegramUserName { get; set; } = string.Empty;
        public DateTime RegisteredAt { get; set; }
        public ToDoUser(string telegramUserName = "NoName")
        {
            RegisteredAt = DateTime.UtcNow;
            UserId = Guid.NewGuid();
            TelegramUserName = telegramUserName;
        }
    }
}
