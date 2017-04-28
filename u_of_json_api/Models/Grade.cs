using System.ComponentModel.DataAnnotations;

namespace u_of_json_api.Models
{
    public class Grade
    {
        [Required]
        public int ID { get; set; }
        [StringLength(1)]
        public string grade { get; set; }
    }
}
