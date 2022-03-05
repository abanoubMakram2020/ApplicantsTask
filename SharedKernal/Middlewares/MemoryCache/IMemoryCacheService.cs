using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernal.Middlewares.MemoryCache
{
    public interface IMemoryCacheService
    {
        TValue Get<TValue>(string key);
        void AddOrUpdate<TValue>(string key, TValue value);
        void Remove(string key);
    }
}
