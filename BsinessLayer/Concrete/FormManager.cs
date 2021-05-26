using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FormManager : IFormService
    {
        IFormDal _formDal;

        public FormManager(IFormDal formDal)
        {
            _formDal = formDal;
        }

        [SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(FormValidator))]
        public IResult Add(Form form)
        {
            _formDal.Add(form);
            return new SuccessResult();
        }

        public IDataResult<List<Form>> GetAll()
        {
            return new SuccessDataResult<List<Form>>(_formDal.GetAll());
        }

        public IDataResult<Form> GetById(int id)
        {
            return new SuccessDataResult<Form>(_formDal.Get(f => f.ID == id));
        }


        public IResult Update(Form form)
        {
            _formDal.Update(form);
            return new SuccessResult();
        }
    }
}
