using System.ComponentModel.DataAnnotations;

namespace Job.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Age { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string EmailAdress { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string Position { get; set; } = null!;
    }
}
