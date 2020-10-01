using System.Collections.Generic;

using Trippväktaren.Common.Enums;

namespace Trippväktaren.Common.Data
{

  public class SubstanceDosageBuilder : EntityBuilderBase <SubstanceDosageInfo>
  {
    private readonly Dictionary<SubstanceDoseSize, MassRange> _doses;

    public SubstanceDosageBuilder()
    {
      _doses = new Dictionary<SubstanceDoseSize, MassRange>();
    }

    public SubstanceDosageBuilder AddDosage(SubstanceDoseSize doseSize, MassRange massRange)
    {
      if (_doses.ContainsKey(doseSize))
      {
        return this;
      }

      _doses.Add(doseSize, massRange);
      return this;
    }

    public override SubstanceDosageInfo Build(ulong id)
    {
      return new SubstanceDosageInfo
      {
        Id = id,
        Doses = _doses
      };
    }
  }

}