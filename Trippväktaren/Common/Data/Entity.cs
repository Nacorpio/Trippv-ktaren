namespace Trippväktaren.Common.Data
{

  public abstract class Entity : IEntity
  {
    protected internal Entity(ulong? id = null)
    {
      Id = id;
    }

    public ulong? Id { get; internal set; }
  }

}