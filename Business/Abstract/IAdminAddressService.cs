using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAdminAddressService
    {
        void Add(AdminAddress adminAddress);
        void Delete(AdminAddress adminAddress);
        void Update(AdminAddress adminAddress);
        List<AdminAddress> GetAll();
        AdminAddress GetById(int id);
    }
}
