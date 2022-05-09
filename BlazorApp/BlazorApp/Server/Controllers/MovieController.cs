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
    public class MovieController : ControllerBase
    {
        private readonly ApplicactionDbContex context;

        public MovieController(ApplicactionDbContex context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<ActorMovieDto>> GetActorsMovie()
        {
            return await context.Actors.Select(a => new ActorMovieDto
            {
                ActorsId = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName
            }).ToListAsync();

        }
        [HttpPost]
        public async Task<IActionResult> Add(MovieDto model)
        {
            try
            {
                var genres = context.Genres.Where(g => model.Genres.Contains(g.Id)).ToList();
                var actors = context.Actors.Where(a => model.Actors.Contains(a.Id)).ToList();
                var movie = new Movie(model.Title, model.Poster, model.ReleaseDate);
                foreach(var genre in genres)
                {
                    movie.Genders.Add(genre);
                }
                foreach(var actor in actors)
                {
                    movie.Actors.Add(actor);
                }

                await context.Movies.AddAsync(movie);
                await context.SaveChangesAsync();

                return Ok();

                /*var movie = new Movie(model.Title,model.Poster, model.ReleaseDate, model.Actors, model.Genres);

                await context.Movies.AddAsync(movie);
                await context.SaveChangesAsync();*/
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("all")]
        public async Task<List<MovieDto>> GetAll()
        {
            return await context.Movies.Select(m => new MovieDto
            {
                Id = m.Id,
                Title = m.Title,
                Poster = m.Poster,
                ReleaseDate = m.ReleaseDate,
                Genderss = m.Genders,
                Actorss = m.Actors

            }).ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<MovieDto> GetById(int id)
        {
            //return await context.Movies.Select(m => new MovieDto
            var movies= context.Movies.Select(m => new MovieDto
            {
                Id = m.Id,
                Title = m.Title,
                Poster = m.Poster,
                ReleaseDate = m.ReleaseDate,
                Genres = m.Genders.Select(g => g.Id).ToList(),
                Actors = m.Actors.Select(a=> a.Id).ToList(),
                Genderss = m.Genders,
                Actorss = m.Actors
            }).FirstOrDefaultAsync(g => g.Id.Equals(id));
            return await movies;
        }

        [HttpPut]
        public async Task<IActionResult> Update(MovieDto model)
        {
            try
            {
                var movie = await context.Movies.Include("Genders").Include("Actors").FirstOrDefaultAsync(g => g.Id.Equals(model.Id));
                //se trae el contexto para identificar las tablas relacionales, si no se pone el include, entity nunca detecta los camibos en ellas
                if (movie == null)
                    throw new Exception("The movie does not exist.");

                var genres = context.Genres.Where(g => model.Genres.Contains(g.Id)).ToList();
                var actors = context.Actors.Where(a => model.Actors.Contains(a.Id)).ToList();

                movie.Poster = model.Poster;
                movie.ReleaseDate = model.ReleaseDate;
                movie.Title = model.Title;

                movie.Genders.Clear();
                movie.Actors.Clear();

                foreach(var genre in genres)
                {
                    movie.Genders.Add(genre);
                }
                foreach (var actor in actors)
                {
                    movie.Actors.Add(actor);
                }

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
