using JetBrains.Annotations;

using Trippväktaren.Common.Enums;

namespace Trippväktaren.Common.Data
{

  public class SubstanceRouteInfo
  {
    public SubstanceRouteInfo([NotNull] SubstanceRoute route, [NotNull] DurationRange duration)
    {
      Route    = route;
      Duration = duration;
    }

    public SubstanceRoute Route { get; }
    public DurationRange Duration { get; }
  }

}