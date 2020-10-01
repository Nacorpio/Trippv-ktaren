using System;

namespace Trippväktaren
{

  public interface IRange<T>
    where T : IEquatable<T>
  {
    T Min { get; }
    T Max { get; }

    bool IsValueInside(T value);
  }

}