using UnitsNet;

namespace Trippväktaren.Common.Data
{
  public sealed class MassRange : Range<Mass>
  {
    public MassRange(Mass min, Mass max) : base(min, max)
    {
    }

    public override bool IsValueInside(Mass value)
    {
      return value >= Min && value <= Max;
    }
  }

}