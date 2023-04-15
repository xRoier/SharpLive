using LinqToDB.Mapping;

namespace SharpLive.Db.Tables;

[Table("chat_messages")]
public class ChatMessage
{
    [PrimaryKey]
    public Guid Id { get; set; }
    public ulong AuthorId { get; set; }
    public Guid StreamingId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string Content { get; set; }

    [Association(ThisKey = nameof(AuthorId), OtherKey = nameof(User.DiscordId))]
    public User Author { get; set; }
}