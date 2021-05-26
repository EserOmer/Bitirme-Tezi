using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataLayer.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFormDal : EfEntityRepositoryBase<Form, FormContext>, IFormDal
    {
        //public List<FormDto> GetForm()
        //{
        //    using (FormContext context = new FormContext())
        //    {
        //        var result = from f in context.FORM
        //                     join q in context.QUESTION on 
        //    }
        //}
    }
}
