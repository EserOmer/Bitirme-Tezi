using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFormService
    {
        IDataResult<List<Form>> GetAll();
        IDataResult<Form> GetById(int id);
        IResult Add(Form form);
        IResult Update(Form form);
    }
}
