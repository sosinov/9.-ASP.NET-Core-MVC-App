using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _9AspNetCoreWebAppMVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Group ID")]
        [Required(ErrorMessage = "The group id is required")]
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group? Group { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "The first name is required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "First name must be between 3 and 15 chars")]
        public string? First_Name { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "The last name is required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Last name must be between 3 and 15 chars")]
        public string? Last_Name { get; set; }

    }
}
