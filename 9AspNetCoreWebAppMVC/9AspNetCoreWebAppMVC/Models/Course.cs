using System.ComponentModel.DataAnnotations;

namespace _9AspNetCoreWebAppMVC.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Course name")]
        [Required(ErrorMessage = "The course name is required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Course name must be between 3 and 15 chars")]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "The description is required")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 150 chars")]
        public string? Description { get; set; }

        //Relationships
        public List<Group>? Groups { get; set; }
    }
}
