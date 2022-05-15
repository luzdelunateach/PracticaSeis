using EFeShop.Service.Abstraction;
using Model;
using Share.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeShop.Service.Implementation
{
    public class ProviderService:IProviderService
    {
        private readonly AppDbContext context = new AppDbContext();
        public ProviderDto GetProvider(int id)
        {
            var provider = context.Providers.Select(p => new ProviderDto
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
            var provider = context.Providers.Select(p => new ProviderDto
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
