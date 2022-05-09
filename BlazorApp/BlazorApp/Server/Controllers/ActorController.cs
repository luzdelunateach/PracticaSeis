using BlazorApp.Shared.Dto;
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
    public class ActorController : ControllerBase
    {

        private readonly ApplicactionDbContex context;

        public ActorController(ApplicactionDbContex context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActorDto model)
        {
            try
            {
                var actor = new Actor(model.FirstName, model.LastName, model.DateOfBirth, model.YearsActive, model.Photo, model.Biography);

                await context.Actors.AddAsync(actor);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("all")]
        public async Task<List<ActorDto>> GetAll()
        {
            return await context.Actors.Select(a => new ActorDto
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                DateOfBirth = a.DateOfBirth,
                YearsActive=a.YearsActive,
                Photo=a.Photo,
                Biography=a.Biography
            }).ToListAsync();

        }

        

        [HttpGet("{id}")]
        public async Task<ActorDto> GetById(int id)
        {
            return await context.Actors.Select(a => new ActorDto
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                DateOfBirth = a.DateOfBirth,
                YearsActive = a.YearsActive,
                Photo = a.Photo,
                Biography = a.Biography
            }).FirstOrDefaultAsync(g => g.Id.Equals(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ActorDto model)
        {
            try
            {
                var actor = await context.Actors.FirstOrDefaultAsync(g => g.Id.Equals(model.Id));
                if (actor == null)
                    throw new Exception("Element not found");

                actor.FirstName = model.FirstName;
                actor.LastName = model.LastName;
                actor.DateOfBirth = model.DateOfBirth;
                actor.YearsActive = model.YearsActive;
                actor.Photo = model.Photo;
                actor.Biography = model.Biography;
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
