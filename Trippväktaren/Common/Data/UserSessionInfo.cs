using Discord;

namespace Trippväktaren.Common.Data
{

  /// <summary>
  /// Represents an object that stores information about a solo session in which a user consumes substances.
  /// </summary>
  /// <remarks>
  /// <c>Note</c><br/>
  /// If allowed by the user, a session will be automatically created as the first dose is taken.<br/>
  /// The session can either be ended automatically or by manual user action.
  /// </remarks>
  public class UserSessionInfo : SessionInfo
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="UserSessionInfo"/> class.
    /// </summary>
    /// <param name="id">The unique identifier.</param>
    public UserSessionInfo(ulong? id) : base(id)
    {
    }

    /// <summary>
    /// Gets the user host of the session.
    /// </summary>
    public IGuildUser User { get; set; }
  }

}