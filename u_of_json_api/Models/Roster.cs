using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace u_of_json_api.Models
{
    [Table("roster") ]
    public class Roster
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int studentId { get; set; }
        public Student Student { get; set; }

        public int? courseId { get; set; }
        public Course Course { get; set; }

        public int? gradeId { get; set; }
        public Grade Grade { get; set; }



    }
}
