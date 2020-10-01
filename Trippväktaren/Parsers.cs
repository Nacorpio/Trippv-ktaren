using System.Globalization;
using System.Linq;
using System.Threading;

using Sprache;
using UnitsNet;

namespace Trippväktaren
{

  public static class Parsers
  {
    private static readonly CultureInfo SwedishCulture;

    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    static Parsers()
    {
      SwedishCulture = new CultureInfo("sv-SE")
      {
       NumberFormat = new NumberFormatInfo
       {
         NumberDecimalSeparator = ",",
         CurrencyDecimalSeparator = ",",
         PercentDecimalSeparator = ","
       }
      };

      Thread.CurrentThread.CurrentCulture = SwedishCulture;
    }

    /// <summary>
    /// Represents a parser that parses and returns a <see cref="Mass"/>.
    /// </summary>
    public static Parser<Mass> MassParser =
      from value in Parse.Decimal.Once()
      from _ in Parse.WhiteSpace.Optional()
      from unit in Parse.Letter.Many().Text()
      select Mass.Parse(value.FirstOrDefault() + unit, SwedishCulture);

    /// <summary>
    /// Represents a parser that parses and returns what substance and how much.
    /// </summary>
    public static Parser<(string substanceName, Mass mass)> SubstanceMassParser =
      from m in MassParser.Once()
      from _ in Parse.WhiteSpace.AtLeastOnce()
      from sn in Parse.AnyChar.AtLeastOnce()
      select (new string(sn.ToArray()), m.FirstOrDefault());

    /// <summary>
    /// Represents a parser that parses and returns a <see cref="Duration"/>.
    /// </summary>
    public static Parser<Duration> DurationParser =
      from value in Parse.Decimal.Once()
      from _ in Parse.Decimal.Once()
      from unit in Parse.Letter.Many().Text()
      select Duration.Parse(value.FirstOrDefault() + unit, SwedishCulture);
  }

}