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
    public class EfQuestionDal : EfEntityRepositoryBase<Question, FormContext>, IQuestionDal
    {
    }
}
