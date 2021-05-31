using Client.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Client.Services.Implementation
{
    public class BrowserStorageService : IBrowserStorageService
    {
        private readonly IJSRuntime _jSRuntime;

        private const string Get = "localStorage.getItem";
        private const string Set = "localStorage.setItem";
        private const string Remove = "localStorage.removeItem";

        public BrowserStorageService(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async ValueTask<string> GetFromLocalStorage(string key)
        {
            var result= await _jSRuntime.InvokeAsync<string>(Get, key);
            return result;
        }

        public async ValueTask<object> SetInLocalStorage(string key, string content)
        {
            var res= await _jSRuntime.InvokeAsync<object>(Set, key, content);
            return res;
        }

        public async ValueTask<object> RemoveFromLocalStorage(string key)
        {
            return await _jSRuntime.InvokeAsync<object>(Remove, key);
        }
    }
}
