using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FooterImageManager : IFooterImageService
    {
        IFooterImageDal _footerImageDal;

        public FooterImageManager(IFooterImageDal footerImageDal)
        {
            _footerImageDal = footerImageDal;
        }

        public void Add(FooterImage footerImage)
        {
            _footerImageDal.Add(footerImage);
        }

        public void Delete(FooterImage footerImage)
        {
            _footerImageDal.Delete(footerImage);
        }

        public List<FooterImage> GetAll()
        {
            return _footerImageDal.GetAll();
        }

        public FooterImage GetById(int id)
        {
            return _footerImageDal.GetById(id);
        }

        public void Update(FooterImage footerImage)
        {
            _footerImageDal.Update(footerImage);
        }
    }
}
