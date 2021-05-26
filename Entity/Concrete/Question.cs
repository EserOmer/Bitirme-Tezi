using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Question : IEntity
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public int? QUESTION_SCORE { get; set; }
        public int? TRUE_CHOICE_ID { get; set; }
        public int QUESTION_TYPE_ID { get; set; }
        public int FORM_ID { get; set; }

    }
}
