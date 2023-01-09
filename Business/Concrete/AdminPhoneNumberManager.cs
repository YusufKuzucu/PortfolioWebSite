using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AdminPhoneNumberManager : IAdminPhoneNumberService
    {
        IAdminPhoneNumberDal _adminPhoneNumberDal;

        public AdminPhoneNumberManager(IAdminPhoneNumberDal adminPhoneNumberDal)
        {
            _adminPhoneNumberDal = adminPhoneNumberDal;
        }

        public void Add(AdminPhoneNumber adminPhoneNumber)
        {
            _adminPhoneNumberDal.Add(adminPhoneNumber);
        }

        public void Delete(AdminPhoneNumber adminPhoneNumber)
        {
            _adminPhoneNumberDal.Delete(adminPhoneNumber);
        }

        public List<AdminPhoneNumber> GetAll()
        {
            return _adminPhoneNumberDal.GetAll();
        }

        public AdminPhoneNumber GetById(int id)
        {
            return _adminPhoneNumberDal.GetById(id);
        }

        public void Update(AdminPhoneNumber adminPhoneNumber)
        {
            _adminPhoneNumberDal.Update(adminPhoneNumber);
        }
    }
}
