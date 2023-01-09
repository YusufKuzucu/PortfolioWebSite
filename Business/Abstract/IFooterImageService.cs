using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFooterImageService
    {
        void Add(FooterImage footerImage);
        void Delete(FooterImage footerImage);
        void Update(FooterImage footerImage);
        List<FooterImage> GetAll();
        FooterImage GetById(int id);
    }
}
