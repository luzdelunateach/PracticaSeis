using EFeShop.Service.Abstraction;
using Model;
using Model.Entities;
using Share.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeShop.Service.Implementation
{
    public class PurchaseOrderCartService : IPurchaseOrderCart
    {
        private readonly AppDbContext context = new AppDbContext();
        public void RegisterOrder(CartShoppingDto order, List<Product> producto)
        {
            var orderCart = new PurchaseOrderCart(order.Total);
            try
            {
                context.PurchaseOrderCarts.Add(orderCart);
                context.SaveChanges();
                var idOrderCart = context.PurchaseOrderCarts.OrderByDescending(o => o.Id).FirstOrDefault();
                foreach(var p in producto)
                {
                    context.PurchaseOrderCartDetails.Add(new PurchaseOrderCartDetail(p.Id,idOrderCart.Id));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ShoppingCartDto> GetAll()
        {
            var cart = context.PurchaseOrderCarts.Select(c => new ShoppingCartDto
            {
                Id = c.Id,
                PurchaseDate = c.PurchaseDate.ToShortDateString(),
                Total = c.Total
            }).ToList();

            if (!cart.Any())
                throw new Exception("No hay compras.");

            return cart;
        }

        public List<ShoppingCartDetailsDto> GetAllDetails(int id)
        {
            var cart = context.PurchaseOrderCartDetails
                .Where(d => d.PurchaseOrderCartId == id)
                .Select(c => new ShoppingCartDetailsDto
            {
                Id = c.Id,
                ProductId = c.ProductId,
                PurchaseOrderCartId = c.PurchaseOrderCartId
            }).ToList();

            if (!cart.Any())
                throw new Exception("No hay compras.");

            return cart;
        }
    }
}
