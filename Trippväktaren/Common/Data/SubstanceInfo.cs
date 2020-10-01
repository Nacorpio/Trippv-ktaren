using System.Linq;
using Newtonsoft.Json;
using Trippväktaren.Common.Enums;
using UnitsNet;

namespace Trippväktaren.Common.Data
{
  public class SubstanceInfo : Entity
  {
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("display_name")]
    public string DisplayName { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("dosage")]
    public SubstanceDosageInfo Dosage { get; set; }

    [JsonProperty("duration")]
    public SubstanceDurationInfo Duration { get; set; }

    public SubstanceDoseSize GetSize(Mass amount)
    {
      return (from dose in Dosage.Doses
              where dose.Value.IsValueInside(amount)
              select dose.Key).FirstOrDefault();
    }

  }

}