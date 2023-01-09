using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAdminEmailService
    {
        void Add(AdminEmail adminEmail);
        void Delete(AdminEmail adminEmail);
        void Update(AdminEmail adminEmail);
        List<AdminEmail> GetAll();
        AdminEmail GetById(int id);
    }
}
