using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo1.Models
{
    public class DepartmentNames
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
