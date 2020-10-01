using System;

using JetBrains.Annotations;

namespace Trippväktaren.Common.Data
{

  public interface IBuilderStore<TItem, out TBuilder> : IStore<TItem>
    where TItem : IEntity
    where TBuilder : IBuilder<TItem>
  {
    TItem Create([NotNull] Action<TBuilder> act);
    TItem GetItemOrCreate([NotNull] Action<TBuilder> act);
  }

}