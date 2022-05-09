using BlazorApp.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services.Abstractions
{
    public interface IGenreApi
    {
        Task<string> Add(GenreDto model);
        Task<List<GenreDto>> GetAll();
        Task<GenreDto> GetById(int id);
        Task<string> Update(GenreDto model);
    }
}
