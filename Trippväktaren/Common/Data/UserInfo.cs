using System.Collections.Generic;

using Newtonsoft.Json;

namespace Trippväktaren.Common.Data
{
  /// <summary>
  /// Represents information about a user in a guild.
  /// </summary>
  public class UserInfo : Entity
  {
    public UserInfo()
    {
      Doses = new List <UserDoseInfo>();
    }

    /// <summary>
    /// Gets a collection of the doses that have been taken by the user.
    /// </summary>
    [JsonProperty("doses")]
    public List <UserDoseInfo> Doses { get; }
  }

}