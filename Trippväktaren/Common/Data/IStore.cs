using System;
using System.Collections.Generic;

using Discord;

using JetBrains.Annotations;

namespace Trippväktaren.Common.Data
{

  public interface IStore<T> : IStore, IEnumerable<T>
    where T : IEntity
  {
    new T this[ulong itemId] { get; }

    T Create([NotNull] Action<T> func);

    T GetItemOrCreate([NotNull] Action<T> func);
    T GetItemOrDefault(ulong itemId, T @default = default);

    void Add([NotNull] T item);
    bool Contains([NotNull] T item);
    bool Remove([NotNull] T item);

    bool TryGetItem(ulong itemId, out T item);
  }

  public interface IStore
  {
    IEntity this[ulong itemId] { get; }

    void Add([NotNull] IEntity item);
    bool Contains([NotNull] IEntity item);
    bool Remove([NotNull] IEntity item);

    bool TryGetItem(ulong itemId, out IEntity item);
  }

}