using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAdminPhoneNumberService
    {
        void Add(AdminPhoneNumber adminPhoneNumber);
        void Delete(AdminPhoneNumber adminPhoneNumber);
        void Update(AdminPhoneNumber adminPhoneNumber);
        List<AdminPhoneNumber> GetAll();
        AdminPhoneNumber GetById(int id);
    }
}
