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
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;
        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }
        //[SecuredOperation("question.add,admin,moderator")]
        //[ValidationAspect(typeof(QuestionValidator))]
        //[CacheRemoveAspect("IQuestionService.Get")]
        public IResult Add(Question question)
        {
            _questionDal.Add(question);
            return new SuccessResult();
        }

        //[CacheAspect]
        public IDataResult<List<Question>> GetAll()
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll());
        }

        public IDataResult<List<Question>> GetByFormId(int formId)
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll(q => q.FORM_ID == formId));
        }

        public IDataResult<Question> GetById(int id)
        {
            return new SuccessDataResult<Question>(_questionDal.Get(q => q.FORM_ID == id));
        }

        [SecuredOperation("question.add,admin,moderator")]
        [ValidationAspect(typeof(QuestionValidator))]
        [CacheRemoveAspect("IQuestionService.Get")]
        public IResult Update(Question question)
        {
            _questionDal.Update(question);
            return new SuccessResult();
        }
    }
}
