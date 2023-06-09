﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DurikBot;

public class PublicModule : ModuleBase<SocketCommandContext>
{
    private readonly ILogger<PublicModule> _logger;
    //You can inject the host. This is useful if you want to shutdown the host via a command, but be careful with it.
    private readonly IHost _host;

    public PublicModule(IHost host, ILogger<PublicModule> logger)
    {
        _host = host;
        _logger = logger;
    }

    [Command("ping")]
    [Alias("Discord", "link")]
    public async Task PingAsync()
    {
        _logger.LogInformation("User {user} used the ping command!", Context.User.Username);
        await ReplyAsync("Если имеешь желание, заходи на сервер :з");
        await ReplyAsync("https://discord.gg/AFvfyMd9ef");
    }

    [Command("stop")]
    public Task Stop()
    {
        _ = _host.StopAsync();
        return Task.CompletedTask;
    }
    [Command("info")]
    private async Task Info(SocketGuildUser socketGuildUser = null)
    {
        if (socketGuildUser == null)
        {
            var embed = new EmbedBuilder()
                .WithColor(Color.Orange)
                .WithTitle(Context.User.Username)
                .WithImageUrl(Context.User.GetAvatarUrl())
                .AddField("User ID:", Context.User.Id, true)
                .AddField("Created at", Context.User.CreatedAt, true);

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }
        else
        {
            var embed = new EmbedBuilder()
                .WithColor(Color.Orange)
                .WithTitle(socketGuildUser.Username)
                .WithImageUrl(socketGuildUser.GetAvatarUrl())
                .AddField("User ID:", socketGuildUser.Id, true)
                .AddField("Created at:", socketGuildUser.CreatedAt, true);

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }
    }

    [Command("log")]
    public Task TestLogs()
    {
        _logger.LogTrace("This is a trace log");
        _logger.LogDebug("This is a debug log");
        _logger.LogInformation("This is an information log");
        _logger.LogWarning("This is a warning log");
        _logger.LogError(new InvalidOperationException("Invalid Operation"), "This is a error log with exception");
        _logger.LogCritical(new InvalidOperationException("Invalid Operation"), "This is a critical load with exception");

        _logger.Log(GetLogLevel(LogSeverity.Error), "Error logged from a Discord LogSeverity.Error");
        _logger.Log(GetLogLevel(LogSeverity.Info), "Information logged from Discord LogSeverity.Info ");

        return Task.CompletedTask;
    }

    private static LogLevel GetLogLevel(LogSeverity severity)
        => (LogLevel)Math.Abs((int)severity - 5);
}