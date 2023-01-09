using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMyServiceService
    {
        void Add(MyService myService);
        void Delete(MyService myService);
        void Update(MyService myService);
        List<MyService> GetAll();
        MyService GetById(int id);
    }
}
