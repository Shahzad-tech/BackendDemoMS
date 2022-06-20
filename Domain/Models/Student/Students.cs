using Domain.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models.Student
{
    public class Students
    {

        public Students()
        {
            this.CreatedDate = DateTime.Now;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string LastProgram { get; set; }
        [Required]
        public string CurrentProgram { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public float CurrentGPA { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
       public string UserId { get; set; }
       public ApplicationUser ApplicationUser { get; set; }

    }
}
