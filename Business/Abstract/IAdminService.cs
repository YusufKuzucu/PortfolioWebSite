using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAdminService
    {
        void Add(Admin admin);
        void Delete(Admin admin);
        void Update(Admin admin);
        List<Admin> GetAll();
        Admin GetById(int id);

    }
}
