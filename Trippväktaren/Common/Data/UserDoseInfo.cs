using System;
using Discord;
using UnitsNet;

namespace Trippväktaren.Common.Data
{
  /// <summary>
  /// Represents an object that stores information about when user took a substance.
  /// </summary>
  public class UserDoseInfo : IEquatable<UserDoseInfo>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="UserDoseInfo"/> class, specifying its unique identifier.
    /// </summary>
    /// <param name="guid">The unique GUID.</param>
    public UserDoseInfo(Guid? guid)
    {
      Guid = guid;
    }


    /// <summary>
    /// Gets the unique GUID of the <see cref="UserDoseInfo"/>.
    /// </summary>
    public Guid? Guid { get; }


    /// <summary>
    /// Gets the substance that was taken.
    /// </summary>
    public SubstanceInfo Substance { get; set; }

    /// <summary>
    /// Gets the dose that was taken.
    /// </summary>
    public Mass? Dose { get; set; }


    /// <summary>
    /// Gets the user that took the dose.
    /// </summary>
    public IGuildUser TakenBy { get; set; }

    /// <summary>
    /// Gets the time at which the dose was taken.
    /// </summary>
    public DateTime? TakenAt { get; set; }


    public bool Equals(UserDoseInfo other)
    {
      if (ReferenceEquals(null, other))
        return false;

      if (ReferenceEquals(this, other))
        return true;

      return Nullable.Equals(Guid, other.Guid);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj))
        return false;

      if (ReferenceEquals(this, obj))
        return true;

      if (obj.GetType() != GetType())
        return false;

      return Equals((UserDoseInfo)obj);
    }

    public override int GetHashCode()
    {
      return Guid.GetHashCode();
    }
  }
}

