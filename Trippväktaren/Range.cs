using System;

namespace Trippväktaren
{

  public abstract class Range<T> : IRange<T> where T : IEquatable<T>
  {
    protected Range(T min, T max)
    {
      Min = min;
      Max = max;
    }

    public T Min { get; }
    public T Max { get; }

    public abstract bool IsValueInside(T value);
  }

}