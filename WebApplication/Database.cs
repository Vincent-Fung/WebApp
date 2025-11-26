using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("COMPANY")]
    public class Company
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string NAME { get; set; }

        public int AGE { get; set; }
        public string ADDRESS { get; set; }
        public int SALARY { get; set; }
    }
}
