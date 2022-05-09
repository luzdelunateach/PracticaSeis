using BlazorApp.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services.Abstractions
{
    public interface IActorApi
    {
        Task<string> Add(ActorDto model);
        Task<List<ActorDto>> GetAll();
        Task<ActorDto> GetById(int id);
        Task<string> Update(ActorDto model);
    }
}
