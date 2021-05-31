using Client.Services.Abstraction;
using Client.Services.Common;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Client.Services.Implementation
{
    public class StudentsService : IStudentsService
    {
        private  const string noteKey = "token";

        private ILocalStorageService _localStore;

        private readonly IHttpService _httpService;
        
        private readonly HttpClient _httpClient;

        private readonly IBrowserStorageService _browserStorageServ;



        public StudentsService(IHttpService httpService, HttpClient httpClient, IBrowserStorageService browserStorageServ, ILocalStorageService localStore)
        {
            this._httpService = httpService;

            this._httpClient = httpClient;

            this._browserStorageServ = browserStorageServ;

            this._localStore = localStore;

        }

         
        public async Task<ReadStudentDto> Addstudent(StudentDto data,string token)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, StudentEndpoints.GetAllStudent);


            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var result = await _httpService.Post<ReadStudentDto,StudentDto>(StudentEndpoints.AddStudent,data);

            return result;
        }

        public async  Task<IEnumerable<ReadStudentDto>> GetAllStudent(string token)
        {

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, StudentEndpoints.GetAllStudent);


           requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",token);

            var result = await _httpClient.SendAsync(requestMessage);

            var jsonResponseData = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<ReadStudentDto>>(jsonResponseData, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

           
        }

        public Task<ReadStudentDto> GetyId(object Id, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveStudent(object Id, string token)
        {
            throw new NotImplementedException();
        }

        public Task<ReadStudentDto> Updatestudent(ReadStudentDto data, string token)
        {
            throw new NotImplementedException();
        }
    }
}
