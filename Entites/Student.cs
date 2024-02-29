using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Entites
{
    [Table("Students")]
    public class Student
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId {get; set;}
       
        [MinLength(5)]
        public string NameStudent {get ; set ;}
        public DateTime DateOfBirth {get; set ;}
        
        [MinLength(10)]
        public string StudentCode {get; set;}
        public int Age {get; set ;}

    }
}