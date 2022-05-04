using Bussiness.Models;
using Bussiness.Services.Abstractions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Implementations
{
    public class ProviderService:IProviderService
    {
        private readonly AppDbContext _context;

        public ProviderService(AppDbContext context)
        {
            _context = context;
        }
        public ProviderDto GetProvider(int id)
        {
            var provider = _context.Providers.Select(p => new ProviderDto
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber,
                Email = p.EmailAddress,
                City = p.City
                
            }).FirstOrDefault(s => s.Id == id);
            if (provider is null)
                throw new Exception("El producto no existe.");

            return provider;
        }

        public List<ProviderDto> GetAll()
        {
            var provider = _context.Providers.Select(p => new ProviderDto
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber,
                Email = p.EmailAddress,
                City = p.City

            }).ToList();

            if (!provider.Any())
                throw new Exception("No hay productos.");

            return provider;
        }

    }
}
