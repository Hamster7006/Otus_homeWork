namespace Otus_homeWork.ToDO
{
    internal class ToDoUser
    {
        public Guid UserId { get; set; }
        public string TelegramUserName { get; set; }
        public DateTime RegisteredAt { get; set; }
        public long TelegramUserId { get; set; }
        public ToDoUser(string telegramUserName = null, long telegramUserId = 0)
        {
            RegisteredAt = DateTime.UtcNow;
            UserId = Guid.NewGuid();
            TelegramUserName = telegramUserName;
            TelegramUserId = telegramUserId;
        }
    }
}
