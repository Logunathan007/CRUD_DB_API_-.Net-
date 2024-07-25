using System.ComponentModel.DataAnnotations;

namespace CRUD_DB_Using_API.Model.Entitys
{
    public class Employee
    {
        [Key]
        [Required]
   
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MinLength(1)]
        public string Designation { get; set; }
    }
}
