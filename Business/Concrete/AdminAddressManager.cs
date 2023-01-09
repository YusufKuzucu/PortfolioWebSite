using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AdminAddressManager : IAdminAddressService
    {
        IAdminAddressDal _adminAddress;

        public AdminAddressManager(IAdminAddressDal adminContactInfo)
        {
            _adminAddress = adminContactInfo;
        }

        public void Add(AdminAddress adminAddress)
        {
            _adminAddress.Add(adminAddress);
        }

        public void Delete(AdminAddress adminAddress)
        {
            _adminAddress.Delete(adminAddress);
        }

        public List<AdminAddress> GetAll()
        {
           return _adminAddress.GetAll();
        }

        public AdminAddress GetById(int id)
        {
            return _adminAddress.GetById(id);
        }

        public void Update(AdminAddress adminAddress)
        {
            _adminAddress.Update(adminAddress);
        }
    }
}
