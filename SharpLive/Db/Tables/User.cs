using LinqToDB.Mapping;

namespace SharpLive.Db.Tables;

[Table("users")]
public class User
{
    [PrimaryKey]
    public ulong DiscordId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string AvatarUrl { get; set; }
    public bool IsBanned { get; set; }
    public bool IsMod { get; set; }
    public bool IsFollowing { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastMessageTime { get; set; }
    
    [Association(ThisKey = nameof(DiscordId), OtherKey = nameof(ChatMessage.AuthorId))]
    public IReadOnlySet<ChatMessage> ChatMessages { get; set; }
}