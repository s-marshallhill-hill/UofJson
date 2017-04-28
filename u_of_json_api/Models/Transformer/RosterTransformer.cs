using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace u_of_json_api.Models.Transformer
{
    public class RosterTransformer
    {
        public int id { get; }
        public string course { get; }
        public string studentName { get; }
        public int gradYear { get; }
        public string grade { get; }
        public RosterTransformer(Roster roster)
        {
            this.id = roster.ID;
            this.course = (roster.Course == null) ? "" : roster.Course.code;
            this.studentName = roster.Student.first + " " + roster.Student.last;
            this.gradYear = roster.Student.gradYear;
            this.grade = (roster.Grade == null) ? "" : roster.Grade.grade;

        }
    }
}
