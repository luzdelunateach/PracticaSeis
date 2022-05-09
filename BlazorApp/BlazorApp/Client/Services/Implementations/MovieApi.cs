using BlazorApp.Client.Services.Abstractions;
using BlazorApp.Shared.Dto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services.Implementations
{
    public class MovieApi : IMovieApi
    {
        private readonly string _endpoint = "api/movie";
        private readonly HttpClient _httpClient;
        public MovieApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Add(MovieDto model)
        {
            var result = await _httpClient.PostAsJsonAsync(_endpoint, model);
            if (!result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();

            return null;
        }

        public async Task<List<ActorMovieDto>> GetActorsMovie()
        {
            return await _httpClient.GetFromJsonAsync<List<ActorMovieDto>>($"{_endpoint}/");
        }

        public async Task<List<MovieDto>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<MovieDto>>($"{_endpoint}/all");
        }

        public async Task<MovieDto> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<MovieDto>($"{_endpoint}/{id}");
        }

        public List<Movie> GetMovies()
        {
            return new List<Movie>{
            new Movie { Title = "Mi pelicula I", Poster="https://th.bing.com/th/id/OIP.kvGsuuTy0GL22_ESRd5xbwHaHa?pid=ImgDet&rs=1", ReleaseDate = new DateTime(2007, 12, 28)},
            new Movie { Title = "Mi pelicula II", Poster="https://th.bing.com/th/id/OIP.kvGsuuTy0GL22_ESRd5xbwHaHa?pid=ImgDet&rs=1", ReleaseDate = new DateTime(2008, 11, 28)},
            new Movie { Title = "Mi pelicula III", Poster="https://th.bing.com/th/id/OIP.kvGsuuTy0GL22_ESRd5xbwHaHa?pid=ImgDet&rs=1", ReleaseDate = new DateTime(2009, 10, 28)},
        };
        }

        public async Task<string> Update(MovieDto model)
        {
            var result = await _httpClient.PutAsJsonAsync(_endpoint, model);
            if (!result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();

            return null;
        }
    }
}
