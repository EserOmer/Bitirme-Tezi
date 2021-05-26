using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Answer : IEntity
    {
        public int ID { get; set; }
        public int USER_ID { get; set; }
        public int FORM { get; set; }
        public string QUESTION { get; set; }
        public string NAME { get; set; }
        public DateTime DATE { get; set; }
    }
}
