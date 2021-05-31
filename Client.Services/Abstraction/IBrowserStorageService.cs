using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Abstraction
{
    public interface IBrowserStorageService
    {
        ValueTask<string> GetFromLocalStorage(string key);
        ValueTask<object> SetInLocalStorage(string key, string content);
        ValueTask<object> RemoveFromLocalStorage(string key);
    }
}
