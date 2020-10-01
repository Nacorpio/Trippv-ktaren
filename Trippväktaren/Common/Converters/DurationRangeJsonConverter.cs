using System;

using Newtonsoft.Json;

using Trippväktaren.Common.Data;

using UnitsNet;
using UnitsNet.Units;

namespace Trippväktaren.Common.Converters
{

  public class DurationRangeJsonConverter : JsonConverter<DurationRange>
  {
    public override void WriteJson(JsonWriter writer, DurationRange value, JsonSerializer serializer)
    {
      writer.WriteValue((int)value.Min.Unit);

      writer.WriteValue(value.Min.Value);
      writer.WriteValue(value.Max.Value);
    }

    public override DurationRange ReadJson
    (
      JsonReader reader,
      Type objectType,
      DurationRange existingValue,
      bool hasExistingValue,
      JsonSerializer serializer)
    {
      if (!reader.Read() || !(reader.Value is int vUnit))
      {
        return null;
      }

      if (!reader.Read() || !(reader.Value is double vMin))
      {
        return null;
      }

      if (!reader.Read() || !(reader.Value is double vMax))
      {
        return null;
      }

      var unit = (DurationUnit)Enum.ToObject(typeof(DurationUnit), vUnit);

      var min = new Duration(vMin, unit);
      var max = new Duration(vMax, unit);

      return new DurationRange(min, max);
    }
  }

}