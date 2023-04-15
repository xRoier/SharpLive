namespace SharpLive.Features;

public class Config
{
    public string ConnectionString { get; set; }
    
    public string DiscordClientId { get; set; }
    
    public string DiscordClientSecret { get; set; }

    public string GetConnectionString() => Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? ConnectionString;
    
    public string GetDiscordClientId() => Environment.GetEnvironmentVariable("DISCORD_CLIENT_ID") ?? DiscordClientId;

    public string GetDiscordClientSecret() => Environment.GetEnvironmentVariable("DISCORD_CLIENT_SECRET") ?? DiscordClientSecret;
}