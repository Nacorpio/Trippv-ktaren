namespace Trippväktaren.Common.Data
{

  public abstract class BuilderBase<TOutput, TInput> : IBuilder<TOutput, TInput> where TOutput : IEntity
  {
    public abstract TOutput Build(TInput input);
  }

  public abstract class EntityBuilderBase<TOutput> : BuilderBase<TOutput, ulong> where TOutput : IEntity
  {
  }

}