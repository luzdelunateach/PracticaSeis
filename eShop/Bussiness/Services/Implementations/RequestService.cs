using Bussiness.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Implementations
{
    public class RequestService : IRequest
    {
        List<Request> RequestList = new List<Request>();
        public void AddRequest(Request request)
        {
            RequestList.Add(request);
        }

        public List<Request> GetRequest()
        {
            return RequestList;
        }

        public Request ShoppingCartAlreadyExist()
        {
            var element = RequestList.FirstOrDefault();
            return element;
        }
    }
}
