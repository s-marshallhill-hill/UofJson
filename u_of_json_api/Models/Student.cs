using System.ComponentModel.DataAnnotations;

namespace u_of_json_api.Models
{
    public class Student
    {
        [Required]
        public int ID { get; set; }

        [StringLength(150)]
        public string first { get; set; }

        [StringLength(150)]
        public string last { get; set; }

        public int age { get; set; }

        [StringLength(150)]
        public string address { get; set; }

        [StringLength(150)]
        public string city { get; set; }

        [StringLength(50)]
        public string state { get; set; }

        [StringLength(10)]
        public string zip { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public int gradYear { get; set; }

        public System.Collections.Generic.List<Roster> Rosters { get; set; }

        //public System.Collections.Generic.List<Course> Courses { get; set; }
    }
}
