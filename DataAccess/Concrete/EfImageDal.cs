using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfImageDal : GenericRepositori<Image>, IImageDal
    {
        public List<Image> GetListCategory()
        {
            using (var context = new PortfolioContext())
            {
                return context.Images.Include(p => p.Category).ToList();


            }
        }
    }
}
