using DataAccess.Abstract;
using DataAccess.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfMyServiceDal : GenericRepositori<MyService>, IMyServiceDal
    {
    }
}
