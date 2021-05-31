using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions DefaultJsonSerializerOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public HttpService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<TRespons> Delete<TRespons>(string Url)
        {
            var result =await _httpClient.DeleteAsync(Url);
             
            var theres =   await  Deserialize<TRespons>(result, DefaultJsonSerializerOptions);

            return theres;
        }

        public async Task<TRespons> Get<TRespons>(string Url)
        {
            var result = await _httpClient.GetAsync(Url);

            var theres = await Deserialize<TRespons>(result, DefaultJsonSerializerOptions);

            return theres;
        }



        public async Task<TRespons> Put<TData, TRespons>(string Url, TData data)
        {
            //var result = await _httpClient.PutAsync(Url);

            //var theres = await Deserialize<TRespons>(result, DefaultJsonSerializerOptions);

            //return theres;
            throw new NotFiniteNumberException();
        }

        private async Task<TResult> Deserialize<TResult>(HttpResponseMessage httpResponseMessage, JsonSerializerOptions jsonSerializerOptions)
        {
            var jsonResponseData = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResult>(jsonResponseData, jsonSerializerOptions);
        }

        public async Task<TRespons> Post<TRespons, TData>(string Url, TData data)
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(data);

                var jsonDataStringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync(Url, jsonDataStringContent);

                var theres = await Deserialize<TRespons>(result, DefaultJsonSerializerOptions);

                return theres;

            }
            catch (Exception ex)
            {

                throw ;
            }
           

        }
    }
}
