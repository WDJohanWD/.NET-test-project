namespace Test.Models
{
    public class TaskItem(int id, string title, string description, bool isCompleted)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string? Description { get; set; } = description;
        public bool IsCompleted { get; set; } = isCompleted;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}    