using Discord;

namespace Trippväktaren.Common.Data
{

  public static class Users
  {
    static Users()
    {
      Store = new Store<UserInfo>();
    }

    public static IStore<UserInfo> Store { get; }
  }

}