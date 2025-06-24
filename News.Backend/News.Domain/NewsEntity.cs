namespace News.Domain;

public class NewsEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string[]? Tags { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? ModifiedTime { get; set; }
}