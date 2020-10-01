namespace Trippväktaren.Common.Data
{

  public static class Substances
  {
    static Substances()
    {
      Store = new Store<SubstanceInfo>();

    }

    public static IStore<SubstanceInfo> Store { get; }
  }

}