using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class IconManager : IIconService
    {
        IIconDal _iconDal;

        public IconManager(IIconDal iconDal)
        {
            _iconDal = iconDal;
        }

        public void Add(Icon icon)
        {
            _iconDal.Add(icon);
        }

        public void Delete(Icon icon)
        {
            _iconDal.Delete(icon);
        }

        public List<Icon> GetAll()
        {
            return _iconDal.GetAll();
        }

        public Icon GetById(int id)
        {
           return  _iconDal.GetById(id);
        }

        public void Update(Icon icon)
        {
            _iconDal.Update(icon);
        }
    }
}
