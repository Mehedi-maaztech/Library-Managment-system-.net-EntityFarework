using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace library_managment_system.Models
{
    public class Students
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Detertment { get; set; }

        [StringLength(20)]
        public string Class { get; set; }

        [StringLength(20)]
        public string Batch { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool Status { get; set; }
    }
}
