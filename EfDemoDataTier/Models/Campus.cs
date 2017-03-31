using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemoDataTier.Models
{
    public class Campus
    {
        [Key]
        public int CampusId { get; set; }
       
        [Required]
        [MaxLength(75)]
        [Index(IsUnique=true)]
        public string CampusName { get; set; }
        [MaxLength(200)]
        public string CampusAddress { get; set; }

        public virtual ICollection<Classroom> Classrooms { get; set; } 
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
