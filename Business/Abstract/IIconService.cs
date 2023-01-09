using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IIconService
    {
        void Add(Icon icon);
        void Delete(Icon icon);
        void Update(Icon icon);
        List<Icon> GetAll();
        Icon GetById(int id);
    }
}
