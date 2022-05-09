using BlazorApp.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly ApplicactionDbContex context;

        public GenderController(ApplicactionDbContex context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Add(GenreDto model)
        {
            try
            {
                var genre = new Gender(model.Name);

                await context.Genres.AddAsync(genre);
                await context.SaveChangesAsync();
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("all")]
        public async Task<List<GenreDto>> GetAll()
        {
            return  await context.Genres.Select(g => new GenreDto
            {
                Id=g.Id,
                Name=g.Name
            }).ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<GenreDto> GetById(int id)
        {
            return await context.Genres.Select(g => new GenreDto
            {
                Id = g.Id,
                Name = g.Name
            }).FirstOrDefaultAsync(g=>g.Id.Equals(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(GenreDto model)
        {
            try
            {
                var genre= await context.Genres.FirstOrDefaultAsync(g => g.Id.Equals(model.Id));
                if (genre == null)
                    throw new Exception("Element not found");

                genre.Name = model.Name;
                //context.Update(genre); el mismo trocker de entityt
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
