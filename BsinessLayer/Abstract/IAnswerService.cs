using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnswerService 
    {
        IDataResult<List<Answer>> GetAll();
        IDataResult<Answer> GetById(int id);
        IResult Add(Answer answer);
        IResult Update(Answer answer);
    }
}
