using LinqToDB.Mapping;

namespace SharpLive.Db.Tables;

[Table("streamings")]
public class Streaming
{
    [PrimaryKey]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ThumbnailUrl { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    
    [Association(ThisKey = nameof(Id), OtherKey = nameof(ChatMessage.StreamingId))]
    public IReadOnlySet<ChatMessage> ChatMessages { get; set; }
}