using Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstractions
{
    public interface IProviderService
    {
        public ProviderDto GetProvider(int id);
        public List<ProviderDto> GetAll();

    }
}
