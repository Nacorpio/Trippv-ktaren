namespace Trippväktaren.Common.Data
{

  public interface IBuilder<out TOutput, in TInput>
    where TOutput : IEntity
  {
    TOutput Build(TInput input);
  }

}