using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemoDataTier.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int CampusId { get; set; }
        public virtual Campus Campus { get; set; }
        [Required]
        public string EmployeeName { get; set; }
    }
}
