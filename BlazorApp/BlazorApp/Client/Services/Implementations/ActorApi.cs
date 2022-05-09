using BlazorApp.Client.Services.Abstractions;
using BlazorApp.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services.Implementations
{
    public class ActorApi: IActorApi
    {
        private readonly string _endpoint = "api/actor";
        private readonly HttpClient _httpClient;

        public ActorApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Add(ActorDto model)
        {
            var result = await _httpClient.PostAsJsonAsync(_endpoint, model);
            if (!result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();

            return null;
        }
        public async Task<List<ActorDto>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<ActorDto>>($"{_endpoint}/all");
        }

       
        public async Task<ActorDto> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ActorDto>($"{_endpoint}/{id}");
        }
        public async Task<string> Update(ActorDto model)
        {
            var result = await _httpClient.PutAsJsonAsync(_endpoint, model);
            if (!result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();

            return null;
        }
    }
}
