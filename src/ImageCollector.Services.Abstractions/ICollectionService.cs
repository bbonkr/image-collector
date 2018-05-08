using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageCollector.Services.Abstractions
{
    public interface ICollectionService
    {
        string BaseUrl { get; }

        T GetData<T>();

        Task<T> GetDataAsync<T>();
    }
}
