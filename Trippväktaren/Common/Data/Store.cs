using System;
using System.Collections;
using System.Collections.Generic;

using Discord;

namespace Trippväktaren.Common.Data
{
  public class Store<T> : IStore<T> where T : Entity, new()
  {
    private readonly Dictionary<ulong, T> _items;

    public Store()
    {
      _items = new Dictionary<ulong, T>();
    }


    public T this[ulong itemId] => TryGetItem(itemId, out var item) ? item : null;

    IEntity IStore.this[ulong itemId] => this[itemId];


    public T Create(Action<T> func)
    {
      var newId = (ulong)_items.Count;

      if (_items.ContainsKey(newId))
      {
        throw new ArgumentException();
      }

      var item = new T
      {
        Id = newId
      };

      Add(item);
      func?.Invoke(item);

      return item;
    }

    public T GetItemOrDefault(ulong itemId, T @default = default)
    {
      return _items.TryGetValue(itemId, out var item) ? item : @default;
    }

    public T GetItemOrCreate(Action<T> func)
    {
      if (_items.TryGetValue((ulong)_items.Count, out var i))
      {
        return i;
      }

      return Create(func);
    }

    public void Add(T item)
    {
      if (!(item.Id is ulong id))
      {
        return;
      }

      _items.Add(id, item);
    }

    void IStore.Add(IEntity item)
    {
      Add((T)item);
    }


    public bool Contains(T item)
    {
      return item.Id is ulong id && _items.ContainsKey(id);
    }

    bool IStore.Contains(IEntity item)
    {
      return Contains((T)item);
    }


    public bool Remove(T item)
    {
      return item.Id is ulong id && _items.Remove(id);
    }

    bool IStore.Remove(IEntity item)
    {
      return Remove((T)item);
    }


    public bool TryGetItem(ulong itemId, out T item)
    {
      return _items.TryGetValue(itemId, out item);
    }

    bool IStore.TryGetItem(ulong itemId, out IEntity item)
    {
      if (!TryGetItem(itemId, out var tItem))
      {
        item = null;
        return false;
      }

      item = tItem;
      return true;
    }


    public IEnumerator<T> GetEnumerator()
    {
      return _items.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }

}