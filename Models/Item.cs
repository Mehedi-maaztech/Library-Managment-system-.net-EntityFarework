using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_managment_system.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Category")]
        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public Category? Category { get; set; }

        [StringLength(30)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
