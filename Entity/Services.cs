using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Services
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public int CounterID { get; set; }
        public List<Question> Question { get; set; }
    }
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionString { get; set; }
    }
}
