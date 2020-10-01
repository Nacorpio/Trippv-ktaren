using System;
using System.Threading.Tasks;

using Discord.WebSocket;

using Trippväktaren.Common.Data;

namespace Trippväktaren.Common.Services
{

  public class GuildHandlingService : HandlingService
  {
    public GuildHandlingService(IServiceProvider provider, DiscordSocketClient client) : base(provider, client)
    {
      Client.GuildAvailable += OnGuildAvailable;
      Client.GuildUnavailable += OnGuildUnavailable;
    }

    private async Task OnGuildAvailable(SocketGuild arg)
    {
      Console.WriteLine($"Guild '{arg.Id}' available; fetching user information.");

      if (!Guilds.Store.TryGetItem(arg.Id, out var storage))
      {
        Console.WriteLine($"Guild '{arg.Id}: Storage was not found; creating new storage.");

        storage = new GuildStorage
        {
          Id = arg.Id
        };

        Guilds.Store.Add(storage);
      }

      foreach (var user in arg.Users)
      {
        Console.WriteLine($"Guild '{arg.Id}': Fetching user '{user.Id}'...");

        var userInfo = new UserInfo
        {
          Id = user.Id
        };

        Users.Store.Add(userInfo);
        storage.AddUser(userInfo);
      }
    }

    private async Task OnGuildUnavailable(SocketGuild arg)
    {
    }
  }

}