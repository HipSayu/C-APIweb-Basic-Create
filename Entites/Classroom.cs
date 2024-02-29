using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Entites
{   [Table("Classroom")]
    public class Classroom
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassroomId {get; set ;}
        
        [Required]
        public string NameClassroom {get; set;}
        public ICollection<StudentClassroom>  studentClassrooms {get; set;}
    }
}