using Bussiness.Models;
using Bussiness.Services.Abstractions;
using Data.Entities;
using Data.Enums;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Implementations
{
    public class PurchaseOrderProviderService: IPurchaseOrderProviderService
    {
        private readonly AppDbContext _context;
        public PurchaseOrderProviderService(AppDbContext context)
        {
            _context = context;
        }

        public PurchaseOrderProviderDetail ChangeStatus(int purchaseId, PurchaseOrderStatus status)
        {
            throw new NotImplementedException();
        }

        public List<OrderProviderDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void RegisterOrder(OrderProviderRegestryDto order)
        {
            throw new NotImplementedException();
        }
    }
}
