namespace Otus_homeWork.ToDO
{
    internal class ToDoUser
    {
        public Guid UserId { get; set; }
        public string TelegramUserName { get; set; }
        public DateTime RegisteredAt { get; set; }
        public ToDoUser(string telegramUserName = null)
        {
            RegisteredAt = DateTime.UtcNow;
            UserId = Guid.NewGuid();
            TelegramUserName = telegramUserName;
        }
    }
}
