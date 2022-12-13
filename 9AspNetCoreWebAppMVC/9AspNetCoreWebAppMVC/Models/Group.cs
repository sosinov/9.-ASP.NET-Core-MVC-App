using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _9AspNetCoreWebAppMVC.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Group name")]
        [Required(ErrorMessage = "The group name is required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Group name must be between 3 and 15 chars")]
        public string? Name { get; set; }

        public int CourceId { get; set; }
        [ForeignKey("CourceId")]
        public Course? Course { get; set; }

        //Relationships
        public List<Student>? Students { get; set; }
    }
}
