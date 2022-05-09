using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server
{
    public class ApplicactionDbContex : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Gender> Genres { get; set; }
        public ApplicactionDbContex(DbContextOptions<ApplicactionDbContex> options): base(options)
        {

        }
    }
}
