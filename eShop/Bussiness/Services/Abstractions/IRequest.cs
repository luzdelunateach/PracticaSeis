using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstractions
{
    public interface IRequest
    {
        public List<Request> GetRequest();
        public void AddRequest(Request request);
        public Request ShoppingCartAlreadyExist();
    }
}
