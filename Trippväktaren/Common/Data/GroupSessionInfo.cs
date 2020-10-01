using System.Collections.Generic;

using Discord;

namespace Trippväktaren.Common.Data
{

  public class GroupSessionInfo : SessionInfo
  {
    public GroupSessionInfo(ulong? id) : base(id)
    {
      Members = new List<IGuildUser>();
    }

    public IList<IGuildUser> Members { get; set; }
  }

}