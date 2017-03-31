using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemoDataTier.Models
{
    public class Classroom
    {
        [Key]
        public int ClassroomId { get; set; }
        public int CampusId { get; set; }
        public virtual Campus Campus { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        public int? RoomCapacity { get; set; }
        [Required]
        [MaxLength(250)]
        public string RoomName { get; set; }

        [NotMapped]
        public string RoomDisplay { get { return string.Concat(RoomName, " (", RoomNumber, ")"); } }
    }
}
