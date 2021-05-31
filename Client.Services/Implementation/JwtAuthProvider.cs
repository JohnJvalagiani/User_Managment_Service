using Blazored.LocalStorage;
using Client.Services.Abstraction;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Services.Implementation
{
    public class JwtAuthProvider
    {

        const string noteKey = "token";
        private readonly IBrowserStorageService _browserStorageService;
        private readonly IJWTClaimParserService _JWTClaimParserService;
        private readonly HttpClient _httpClient;
        private ILocalStorageService _localStore;

        private const string TOKENKEY = "TOKENKEY";

        public JwtAuthProvider(
            IBrowserStorageService browserStorageService, ILocalStorageService localStore,
            IJWTClaimParserService JWTClaimParserService,
            HttpClient httpClient)
        {
            this._localStore = localStore;
            _browserStorageService = browserStorageService;
            _JWTClaimParserService = JWTClaimParserService;
            _httpClient = httpClient;
        }

        private AuthenticationState Anonymous => BuildAnonymousAuthenticationState();

        private AuthenticationState BuildAnonymousAuthenticationState()
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public  async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _browserStorageService.GetFromLocalStorage(TOKENKEY);

            if (string.IsNullOrWhiteSpace(token)) return Anonymous;

            return await BuildAuthenticationStateAsync(token);
        }

        public async Task<AuthenticationState> BuildAuthenticationStateAsync(string token)
        {
            var claims = await _JWTClaimParserService.ParseAsync(token);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt")));
        }

        public async Task LoginAsync(string token)
        {

            await _localStore.SetItemAsync(noteKey, token);


           var oken= await _localStore.GetItemAsync<string>(noteKey);


            var authState = await BuildAuthenticationStateAsync(token);

            //await _browserStorageService.SetInLocalStorage(TOKENKEY, token);

            //NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task LogoutAsync()
        {
            await _browserStorageService.RemoveFromLocalStorage(TOKENKEY);
            _httpClient.DefaultRequestHeaders.Authorization = null;

           // NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        }

    }
}
