using DataAccess.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IImageDal : IGenericDal<Image>
    {
        List<Image> GetListCategory();
    }
}
