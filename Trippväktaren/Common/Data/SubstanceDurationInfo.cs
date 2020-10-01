using System.Collections.Generic;

using Trippväktaren.Common.Enums;

namespace Trippväktaren.Common.Data
{

  public class SubstanceDurationInfo
  {
    public SubstanceDurationInfo()
    {
      Routes = new Dictionary<SubstanceRoute, SubstanceRouteInfo>();
    }

    public Dictionary<SubstanceRoute, SubstanceRouteInfo> Routes { get; set; }
  }

}