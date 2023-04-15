using System.Security.Claims;

namespace SharpLive.Features;

public static class Extensions
{
    public static string GetAvatarUrl(this ClaimsPrincipal user, int size = 128)
    {
        var id = user.FindFirstValue(DiscordClaims.UserId);
        var hash = user.FindFirstValue(DiscordClaims.AvatarHash);
        return $"https://cdn.discordapp.com/avatars/{id}/{hash}.png?size={size}";
    }
    
    public static string GetUsername(this ClaimsPrincipal user)
    {
        var username = user.FindFirstValue(DiscordClaims.Username);
        var discriminator = user.FindFirstValue(DiscordClaims.Discriminator);
        return $"{username}#{discriminator}";
    }
    
    public static string GetEmail(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(DiscordClaims.Email)!;
    }
    
    public static string GetId(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(DiscordClaims.UserId)!;
    }
}