using Trippväktaren.Common.Enums;

namespace Trippväktaren.Common.Data
{

  public class SubstanceBuilder : EntityBuilderBase<SubstanceInfo>
  {
    public SubstanceBuilder()
    {
      Dosage = new SubstanceDosageInfo();
      Duration = new SubstanceDurationInfo();
    }

    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }

    public SubstanceDosageInfo Dosage { get; set; }
    public SubstanceDurationInfo Duration { get; set; }

    public SubstanceBuilder WithName(string value)
    {
      Name = value;
      return this;
    }

    public SubstanceBuilder WithDisplayName(string value)
    {
      DisplayName = value;
      return this;
    }

    public SubstanceBuilder WithDescription(string value)
    {
      Description = value;
      return this;
    }

    public SubstanceBuilder WithDosage(SubstanceDosageInfo value)
    {
      Dosage = value;
      return this;
    }

    public SubstanceBuilder WithDuration(SubstanceDurationInfo value)
    {
      Duration = value;
      return this;
    }

    public SubstanceBuilder AddDosage(SubstanceDoseSize doseSize, MassRange range)
    {
      Dosage.Doses.Add(doseSize, range);
      return this;
    }

    public SubstanceBuilder AddDuration(SubstanceRoute route, SubstanceRouteInfo range)
    {
      Duration.Routes.Add(route, range);
      return this;
    }
    
    public override SubstanceInfo Build(ulong id)
    {
      return new SubstanceInfo
      {
        Id = id,

        Name = Name,
        DisplayName = DisplayName,
        Description = Description,
        Dosage = Dosage,
        Duration = Duration
      };
    }
  }

}