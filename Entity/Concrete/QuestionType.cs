using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class QuestionType : IEntity
    {
        public int ID { get; set; }
        public string TYPE { get; set; }
    }
}
