using System.ComponentModel.DataAnnotations;

namespace EMP.Models
{
    public class Employee
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "* Name can't be blank *")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "* City can't be blank *")]
        public string City { get; set; } = null!;


        public string State { get; set; } = null!;

        [Required(ErrorMessage = "* Salary can't be blank *")]
        public decimal Salary { get; set; } 
       
    }
}
