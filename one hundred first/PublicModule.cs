using Discord; //все команды с пушем бота
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;
using static System.Net.WebRequestMethods;

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

    [Command("link")]
    [Alias("Discord", "link")]
    public async Task PingAsync()
    {
        _logger.LogInformation("User {user} used the ping command!", Context.User.Username);
        await ReplyAsync("Если имеешь желание, заходи на сервер :з");
        await ReplyAsync("https://discord.gg/H82v6EB4aZ");
    }

    [Command("123")]
    [Alias("123", "123")]
    public async Task aAsync()
    {
        await ReplyAsync("📂");
    }

        private void WithDescription(string v)
    {
        throw new NotImplementedException();
    }

    [Command("stop")]
    public Task Stop()
    {
        _ = _host.StopAsync();
        return Task.CompletedTask;
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