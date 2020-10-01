using System.Collections.Generic;
using Newtonsoft.Json;
using Trippväktaren.Common.Enums;

namespace Trippväktaren.Common.Data
{

  public class SubstanceDosageInfo : Entity
  {
    public SubstanceDosageInfo()
    {
      Doses = new Dictionary <SubstanceDoseSize, MassRange>();
    }

    [JsonProperty("doses")]
    public Dictionary <SubstanceDoseSize, MassRange> Doses { get; set; }
  }

}