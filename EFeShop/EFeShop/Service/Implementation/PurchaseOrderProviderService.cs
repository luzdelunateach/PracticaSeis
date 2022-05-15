using EFeShop.Service.Abstraction;
using Model;
using Model.Entities;
using Share.Dto;
using Share.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeShop.Service.Implementation
{
    public class PurchaseOrderProviderService: IPurchaseOrderProviderService
    {
        private readonly AppDbContext context = new AppDbContext();

        public void RegisterOrder(OrderProviderRegestryDto order)
        {
            var orderProvider= new PurchaseOrderProvider(order.Total, order.ProviderId);
            try
            {
                var prueba=context.PurchaseOrderProviders.Add(orderProvider);
                context.SaveChanges();
                var idOrderProvider = context.PurchaseOrderProviders.OrderByDescending(o=>o.Id).FirstOrDefault();
                var detail = new PurchaseOrderProviderDetail(idOrderProvider.Id,order.ProductoId,order.Cantidad);
                context.PurchaseOrderProviderDetails.Add(detail);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<OrderProviderDto> GetAll()
        {
            var ordenes = context.PurchaseOrderProviders.Select(o => new OrderProviderDto
            {
                Id = o.Id,
                Total = o.Total,
                PurchaseDate = o.PurchaseDate,
                Status = o.Status,
                ProviderName = o.Provider.Name,
                Cantidad = o.PurchaseOrderProviderDetails.FirstOrDefault(p => p.PurchaseOrderProviderId == o.Id).Cantidad,
                ProductName = o.PurchaseOrderProviderDetails.FirstOrDefault(p=> p.PurchaseOrderProviderId == o.Id).Product.Name,
                Precio= o.PurchaseOrderProviderDetails.FirstOrDefault(p=> p.PurchaseOrderProviderId == o.Id).Product.Price
            }).ToList();

            if (!ordenes.Any())
                throw new Exception("No hay ordenes de compra.");

            return ordenes;
        }

        public PurchaseOrderProviderDetail ChangeStatus(int purchaseId,PurchaseOrderStatus status)
        {
            var orden = context.PurchaseOrderProviders.FirstOrDefault(o => o.Id == purchaseId);
            try
            {
                orden.Status = status;
                context.SaveChanges();
                var detail = orden.PurchaseOrderProviderDetails.FirstOrDefault(p => p.PurchaseOrderProviderId == orden.Id);
                return detail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
