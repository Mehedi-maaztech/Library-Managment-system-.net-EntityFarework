using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace library_managment_system.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(20)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Available")]
        public bool Is_Active { get; set; }
    }
}
