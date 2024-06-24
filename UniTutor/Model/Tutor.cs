using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniTutor.Model
{
    public class Tutor
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        public string password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Ocupation { get; set; }
        public string ModeOfTeaching { get; set; }
        public string Medium { get; set;}
        public string subject { get; set; }
        public string Qualification { get; set; }
        [Required]
        public string HomeTown { get; set; }
        // Image properties
        public string CVFileName { get; set; }
        public string CVContentType { get; set; }
        public byte[] CVData { get; set; }

        public string UniIDFileName { get; set; }
        public string UniIDContentType { get; set; }
        public byte[] UniIDData { get; set; }

        [NotMapped]
        public IFormFile CvFile { get; set; }

        [NotMapped]
        public IFormFile UniIdFile { get; set; }
        public int accept { get; set; }=0;


    }
}
