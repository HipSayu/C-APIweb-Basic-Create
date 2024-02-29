using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Dtos.Students
{
    public class StudentDto
    {
        public int StudentId {get; set;}
        public string NameStudent {get ; set ;}
        public DateTime DateOfBirth {get; set ;}
        public string StudentCode {get; set;}
        public int Age {get; set ;}
    }
}