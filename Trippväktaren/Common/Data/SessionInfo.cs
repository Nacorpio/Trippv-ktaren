using System;
using System.Collections.Generic;

namespace Trippväktaren.Common.Data
{

  public abstract class SessionInfo
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="SessionInfo"/> class, specifying its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier.</param>
    protected SessionInfo(ulong? id)
    {
      Doses = new List <UserDoseInfo>();
      Id    = id;
    }


    /// <summary>
    /// Gets the unique identifier of the <see cref="SessionInfo"/>.
    /// </summary>
    public ulong? Id { get; }


    /// <summary>
    /// Gets the time at which the session was started.
    /// </summary>
    public DateTime? StartedAt { get; set; }

    /// <summary>
    /// Gets the time at which the session was ended.
    /// </summary>
    public DateTime? EndedAt { get; set; }


    /// <summary>
    /// Gets the last dose that was taken in the session.
    /// </summary>
    public UserDoseInfo LastDose { get; set; }


    /// <summary>
    /// Gets a collection of all doses taken in the session.
    /// </summary>
    public IList <UserDoseInfo> Doses { get; }
  }

}