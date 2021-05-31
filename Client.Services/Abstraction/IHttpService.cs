using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services
{
   public  interface IHttpService
    {

        Task<TRespons> Get<TRespons>(string Url);
        Task<TRespons> Post<TRespons, TData>(string Url, TData data);
        Task<TRespons> Put<TData,TRespons>(string Url, TData data);
        Task<TRespons> Delete<TRespons>(string Url);


    }
}
