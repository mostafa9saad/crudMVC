using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo1.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Required]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Name { get; set; }


        [RegularExpression(@"[a-zA-Z0-9]+@[a-zA-Z]+.[a-zA-Z]{2,4}"), Required]
        [Remote("CheckEmail", "Student", AdditionalFields = "Id", HttpMethod = "get", ErrorMessage = "this Email is aready exsit")]

        public string Email { get; set; }
        public int age { get; set; }

        public int Deptid { get; set; }
    }
}
