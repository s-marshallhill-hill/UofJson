using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace u_of_json_api.Models.Transformer
{
    public class StudentTransformer
    {
        public int ID { get; }
        public string first { get; }
        public string last { get; }
        public int age { get;  }
        public string address { get; }
        public string state { get;  }
        public string zip { get;  }
        public string email { get;  }
        public int gradYear { get;  }
        public System.Collections.Generic.IEnumerable<RosterTransformer> Rosters { get; set; }

        public StudentTransformer(Student student)
        {
            this.ID = student.ID;
            this.first = student.first;
            this.last = student.last;
            this.age = student.age;
            this.address = student.address;
            this.state = student.state;
            this.zip = student.zip;
            this.email = student.email;
            this.gradYear = student.gradYear;

            if (student.Rosters != null)
            {
                this.Rosters = student.Rosters.Select(r => new RosterTransformer(r));
            }
        }

    }
}
