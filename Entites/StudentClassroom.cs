using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Entites
{
    [Table("StudentClassroom")]
    public class StudentClassroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStudentClassroom {get; set;}
        public int StudentId {get; set;}
        public int ClassroomId {get; set;}
        public Student student {get; set;}
        public Classroom classroom {get ;set;}
    }
}