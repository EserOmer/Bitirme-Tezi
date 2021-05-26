using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Choice : IEntity
    {
        public int ID { get; set; }
        public int QUESTION_ID { get; set; }
        public string NAME { get; set; }

    }
}
