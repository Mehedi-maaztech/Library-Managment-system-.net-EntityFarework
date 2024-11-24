using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_managment_system.Models
{
    public class Booklist
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        
        [DisplayName("Category")]
        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public Category? Category { get; set; }
        public DateTime AddOn { get; set; }
    }
}
