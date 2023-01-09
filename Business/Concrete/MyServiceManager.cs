using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MyServiceManager : IMyServiceService
    {
        IMyServiceDal _myServiceDal;

        public MyServiceManager(IMyServiceDal myServiceDal)
        {
            _myServiceDal = myServiceDal;
        }

        public void Add(MyService myService)
        {
            _myServiceDal.Add(myService);
        }

        public void Delete(MyService myService)
        {
            _myServiceDal.Delete(myService);
        }

        public List<MyService> GetAll()
        {
            return _myServiceDal.GetAll();
        }

        public MyService GetById(int id)
        {
            return _myServiceDal.GetById(id);
        }

        public void Update(MyService myService)
        {
            _myServiceDal.Update(myService);
        }
    }
}
