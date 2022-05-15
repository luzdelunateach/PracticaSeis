using Model.Entities;
using Share.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeShop.Service.Abstraction
{
    public interface IPurchaseOrderCart
    {
        public void RegisterOrder(CartShoppingDto order, List<Product> productos);
        public List<ShoppingCartDto> GetAll();
        public List<ShoppingCartDetailsDto> GetAllDetails(int id);
    }
}
