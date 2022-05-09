using BlazorApp.Shared.Dto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services.Abstractions
{
    public interface IMovieApi
    {
        Task<string> Add(MovieDto model);
        Task<List<ActorMovieDto>> GetActorsMovie();
        Task<List<MovieDto>> GetAll();
        List<Movie> GetMovies();//deberian ser dtos
        Task<MovieDto> GetById(int id);
        Task<string> Update(MovieDto model);
    }
}
