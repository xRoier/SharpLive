using AspNet.Security.OAuth.Discord;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MudBlazor.Services;
using SharpLive.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddHttpContextAccessor();
var config = new Config();
builder.Configuration.Bind(config);
builder.Services.AddSingleton(config);
builder.Services.AddAuthentication(x =>
{
    x.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    x.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    x.DefaultAuthenticateScheme = DiscordAuthenticationDefaults.AuthenticationScheme;
}).AddCookie().AddDiscord(options =>
{
    options.Scope.Add("identify");
    options.Scope.Add("email");

    options.ClientId = config.GetDiscordClientId();
    options.ClientSecret = config.GetDiscordClientSecret();

    options.ClaimActions.Clear();
    options.ClaimActions.MapJsonKey(DiscordClaims.UserId, "id");
    options.ClaimActions.MapJsonKey(DiscordClaims.Username, "username");
    options.ClaimActions.MapJsonKey(DiscordClaims.Email, "email");
    options.ClaimActions.MapJsonKey(DiscordClaims.AvatarHash, "avatar");
    options.ClaimActions.MapJsonKey(DiscordClaims.Discriminator, "discriminator");
});
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.MapControllers();
app.MapBlazorHub();
app.UseCookiePolicy(new CookiePolicyOptions
{
    Secure = CookieSecurePolicy.Always,
    MinimumSameSitePolicy = SameSiteMode.Strict
});
app.MapFallbackToPage("/_Host");

app.Run();