using System;

using Newtonsoft.Json;

using Trippväktaren.Common.Data;

using UnitsNet;
using UnitsNet.Units;

namespace Trippväktaren.Common.Converters
{

  public class MassRangeJsonConverter : JsonConverter<MassRange>
  {
    public override void WriteJson(JsonWriter writer, MassRange value, JsonSerializer serializer)
    {
      writer.WriteValue((int)value.Min.Unit);

      writer.WriteValue(value.Min.Value);
      writer.WriteValue(value.Max.Value);
    }

    public override MassRange ReadJson
      (JsonReader reader, Type objectType, MassRange existingValue, bool hasExistingValue, JsonSerializer serializer)
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

      var unit = (MassUnit)Enum.ToObject(typeof(MassUnit), vUnit);

      var min = new Mass(vMin, unit);
      var max = new Mass(vMax, unit);

      return new MassRange(min, max);
    }
  }

}