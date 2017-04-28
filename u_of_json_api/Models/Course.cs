using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace u_of_json_api.Models
{
    public class Course
    {

        [Required]
        public int ID { get; set; }

        [StringLength(50)]
        [Column("course")]
        public string code { get; set; }

        //public List<Student> Students { get; set; }

        public List<Roster> Rosters { get; set; }

    }
}
