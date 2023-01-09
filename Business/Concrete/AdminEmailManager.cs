using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AdminEmailManager : IAdminEmailService
    {
        IAdminEmailDal _adminEmailDal;

        public AdminEmailManager(IAdminEmailDal adminEmailDal)
        {
            _adminEmailDal = adminEmailDal;
        }

        public void Add(AdminEmail adminEmail)
        {
            _adminEmailDal.Add(adminEmail);
        }

        public void Delete(AdminEmail adminEmail)
        {
            _adminEmailDal.Delete(adminEmail);
        }

        public List<AdminEmail> GetAll()
        {
            return _adminEmailDal.GetAll();
        }

        public AdminEmail GetById(int id)
        {
            return _adminEmailDal.GetById(id);
        }

        public void Update(AdminEmail adminEmail)
        {
            _adminEmailDal.Update(adminEmail);
        }
    }
}
