using System;

using Discord.WebSocket;

using JetBrains.Annotations;

namespace Trippväktaren.Common.Services
{
  public class MessageHandlingService : HandlingService
  {
    public MessageHandlingService
    (
      [NotNull] IServiceProvider provider,
      [NotNull] DiscordSocketClient client) : base(
      provider,
      client
    )
    {
    }

  }

}