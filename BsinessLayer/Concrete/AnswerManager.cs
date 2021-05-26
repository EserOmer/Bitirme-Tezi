using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
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
    public class AnswerManager : IAnswerService
    {
        IAnswerDal _answerDal;
        public AnswerManager(IAnswerDal answerDal)
        {
            _answerDal = answerDal;
        }
        [SecuredOperation("admin,moderator,person")]
        [ValidationAspect(typeof(AnswerValidator))]
        public IResult Add(Answer answer)
        {
            _answerDal.Add(answer);
            return new SuccessResult();
        }
        [SecuredOperation("admin,moderator")]
        public IDataResult<List<Answer>> GetAll()
        {
            return new SuccessDataResult<List<Answer>>(_answerDal.GetAll());

        }
        [SecuredOperation("admin,moderator")]
        public IDataResult<Answer> GetById(int id)
        {
            return new SuccessDataResult<Answer>(_answerDal.Get(a => a.ID == id));

        }
        [SecuredOperation("admin,moderator,person")]
        public IResult Update(Answer answer)
        {
            _answerDal.Update(answer);
            return new SuccessResult();
        }
    }
}
