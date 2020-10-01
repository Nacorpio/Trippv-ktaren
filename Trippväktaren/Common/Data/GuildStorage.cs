using System;
using System.Collections.Generic;
using System.Linq;

using Discord;

using JetBrains.Annotations;

using Newtonsoft.Json.Linq;

namespace Trippväktaren.Common.Data
{
  

  public class GuildStorage : Entity
  {
    private readonly Dictionary<ulong, UserInfo> _users;
    private readonly Dictionary<Guid, UserDoseInfo> _doses;

    /// <summary>
    /// Initializes a new instance of the <see cref="GuildStorage"/> class.
    /// </summary>
    public GuildStorage()
    {
      _users = new Dictionary<ulong, UserInfo>();
      _doses = new Dictionary<Guid, UserDoseInfo>();
    }

    /// <summary>
    /// Gets all the users contained in the <see cref="GuildStorage"/>.
    /// </summary>
    public IEnumerable<UserInfo> Users => _users.Values;

    /// <summary>
    /// Gets all the doses contained in the <see cref="GuildStorage"/>.
    /// </summary>
    public IEnumerable<UserDoseInfo> Doses => _doses.Values;


    /// <summary>
    /// Adds the specified user to the <see cref="GuildStorage"/>.
    /// </summary>
    /// <param name="userInfo">The user to add.</param>
    public void AddUser([NotNull] UserInfo userInfo)
    {
      if (HasUser(userInfo))
      {
        return;
      }

      if (!(userInfo.Id is ulong id))
      {
        return;
      }

      _users.Add(id, userInfo);
    }

    /// <summary>
    /// Adds the specified dose to the <see cref="GuildStorage"/>.
    /// </summary>
    /// <param name="doseInfo">The dose to add.</param>
    public void AddDose([NotNull] UserDoseInfo doseInfo)
    {
      if (HasDose(doseInfo))
      {
        return;
      }

      if (!(doseInfo.Guid is Guid guid))
      {
        return;
      }

      _doses.Add(guid, doseInfo);
    }


    /// <summary>
    /// Returns a user with the specified identifier.
    /// </summary>
    /// <param name="userId">The identifier of the user to get.</param>
    /// <returns>The user, if found; otherwise, <c>default</c>.</returns>
    public UserInfo GetUser(ulong userId) =>
      HasUser(userId)
        ? _users.TryGetValue(userId, out var userInfo)
          ? userInfo
          : default
        : null;

    /// <summary>
    /// Returns a dose with the specified identifier.
    /// </summary>
    /// <param name="doseGuid">The GUID of the dose to get.</param>
    /// <returns>The dose, if found; otherwise, <c>default</c>.</returns>
    public UserDoseInfo GetDose(Guid doseGuid) =>
      HasDose(doseGuid)
        ? _doses.TryGetValue(doseGuid, out var doseInfo)
          ? doseInfo
          : default
        : null;


    /// <summary>
    /// Returns a collection of the doses that have been taken by the specified <see cref="IUser"/>.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <returns>The doses that have been taken by the user, if successful; otherwise, <c>null</c>.</returns>
    public IEnumerable<UserDoseInfo> GetDoses([NotNull] IUser user)
    {
      return Doses.Where(x => x.TakenBy.Equals(user));
    }

    /// <summary>
    /// Returns a collection of the doses that have been taken by the specified <see cref="UserInfo"/>.
    /// </summary>
    /// <param name="userInfo">The user information.</param>
    /// <returns>The doses that have been taken by the user, if successful; otherwise, <c>null</c>.</returns>
    public IEnumerable<UserDoseInfo> GetDoses([NotNull] UserInfo userInfo)
    {
      return Doses.Where(x => x.TakenBy.Id.Equals(userInfo.Id));
    }

    /// <summary>
    /// Returns a collection of the doses that have been taken of the specified <see cref="SubstanceInfo"/>.
    /// </summary>
    /// <param name="substanceInfo"></param>
    /// <returns>The doses that have been taken of the substance, if successful; otherwise, <c>null</c>.</returns>
    public IEnumerable<UserDoseInfo> GetDoses([NotNull] SubstanceInfo substanceInfo)
    {
      return Doses.Where(x => x.Substance.Id.Equals(substanceInfo.Id));
    }


    /// <summary>
    /// Returns a value indicating whether the <see cref="GuildStorage"/> contains the specified <see cref="IUser"/>.
    /// </summary>
    /// <param name="user">The user to find.</param>
    /// <returns><c>true</c> if the user was found; otherwise, <c>false</c>.</returns>
    public bool HasUser([NotNull] IUser user)
    {
      return HasUser(user.Id);
    }

    /// <summary>
    /// Returns a value indicating whether the <see cref="GuildStorage"/> contains the specified <see cref="UserInfo"/>.
    /// </summary>
    /// <param name="userInfo">The user information to find.</param>
    /// <returns><c>true</c> if the user information was found; otherwise, <c>false</c>.</returns>
    public bool HasUser([NotNull] UserInfo userInfo)
    {
      return userInfo.Id is ulong id && _users.ContainsKey(id);
    }

    /// <summary>
    /// Returns a value indicating whether the <see cref="GuildStorage"/> contains a user with the specified identifier.
    /// </summary>
    /// <param name="userId">The identifier of the user to get.</param>
    /// <returns><c>true</c> if the user was found; otherwise, <c>false</c>.</returns>
    public bool HasUser(ulong userId)
    {
      return _users.ContainsKey(userId);
    }


    /// <summary>
    /// Returns a value indicating whether the <see cref="GuildStorage"/> contains the specified <see cref="UserDoseInfo"/>.
    /// </summary>
    /// <param name="doseInfo">The dose information to find.</param>
    /// <returns><c>true</c> if the dose information was found; otherwise, <c>false</c>.</returns>
    public bool HasDose([NotNull] UserDoseInfo doseInfo)
    {
      return doseInfo.Guid is Guid guid && _doses.ContainsKey(guid);
    }

    /// <summary>
    /// Returns a value indicating whether the <see cref="GuildStorage"/> contains a <see cref="UserDoseInfo"/> with the specified identifier.
    /// </summary>
    /// <param name="doseGuid">The GUID of the dose information to find.</param>
    /// <returns><c>true</c> if the dose information was found; otherwise, <c>false</c>.</returns>
    public bool HasDose(Guid doseGuid)
    {
      return _doses.ContainsKey(doseGuid);
    }


    public JObject ToJsonObject()
    {
      return null;
    }

    public void FromJsonObject([NotNull] JObject jobj)
    {
    }
  }
}