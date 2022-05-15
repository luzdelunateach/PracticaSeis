using Share.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFeShop.Service.Abstraction
{
    public interface ISubdepartmentService
    {
        List<SubdeparmentDto> GetAll();
    }
}
