using System;
using System.Threading.Tasks;

using Discord.WebSocket;

namespace Trippväktaren.Common.Services
{

  public class UserHandlingService : HandlingService
  {
    public UserHandlingService(IServiceProvider provider, DiscordSocketClient client) : base(provider, client)
    {
      Client.UserJoined += OnUserJoined;
    }

    private async Task OnUserJoined(SocketGuildUser arg)
    {
    }
  }

}