using UnitsNet;

namespace Trippväktaren.Common.Data
{

  public sealed class DurationRange : Range<Duration>
  {
    public DurationRange(Duration min, Duration max) : base(min, max)
    {
    }

    public override bool IsValueInside(Duration value)
    {
      return value >= Min && value <= Max;
    }
  }

}