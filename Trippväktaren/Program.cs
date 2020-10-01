using System;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

using Microsoft.Extensions.DependencyInjection;

using Trippväktaren.Common.Services;

namespace Trippväktaren
{

  public class Program
  {
    public static DiscordSocketClient Client;

    public const string ClientToken = "NzQ4NTYzMDc0MDAwMjI0NDQ3.X0fPsA.jSwKfsaJa8NUBdO5smc8bz3gmtk";

    private static void Main(string[] args)
    {
      new Program().Run().GetAwaiter().GetResult();
    }

    public async Task Run()
    {
      Client = new DiscordSocketClient();

      var services = ConfigureServices();

      await services
       .GetRequiredService<CommandHandlingService>()
       .InitializeAsync();

      services.GetRequiredService<GuildHandlingService>();
      services.GetRequiredService<UserHandlingService>();

      await Client.LoginAsync(TokenType.Bot, ClientToken);
      await Client.StartAsync();

      await Task.Delay(-1);
    }

    private static IServiceProvider ConfigureServices()
    {
      return new ServiceCollection()
          .AddSingleton(Client)
          .AddSingleton<CommandService>()
          .AddSingleton<CommandHandlingService>()
          .AddSingleton<GuildHandlingService>()
          .AddSingleton<UserHandlingService>()
          .BuildServiceProvider();
    }
  }
}
