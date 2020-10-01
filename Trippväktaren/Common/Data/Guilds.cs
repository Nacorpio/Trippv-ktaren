using System.Collections.Generic;
using System.Runtime.InteropServices;

using Discord;
using Discord.WebSocket;

namespace Trippväktaren.Common.Data
{

  public static class Guilds
  {
    static Guilds()
    {
      Store = new Store<GuildStorage>();
    }

    public static IStore<GuildStorage> Store { get; }
  }

}