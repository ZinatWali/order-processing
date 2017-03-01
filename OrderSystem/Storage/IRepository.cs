using System;

namespace OrderSystem.Storage
{
    public interface IRepository<T>
    {
        T Get(int itemId);
        void Save(T item);
    }
}