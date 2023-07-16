using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo1.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Required]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 20, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public int capcity { get; set; }
    }
}
