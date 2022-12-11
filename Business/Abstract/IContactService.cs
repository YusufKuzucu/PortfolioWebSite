using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IContactService
    {
        void Add(Contact Contact);
        void Delete(Contact Contact);
        void Update(Contact Contact);
        List<Contact> GetAll();
        Contact GetById(int id);
    }
}
