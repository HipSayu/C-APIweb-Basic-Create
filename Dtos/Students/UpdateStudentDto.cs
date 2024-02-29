using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Dtos.Students
{
    public class UpdateStudentDto : CreateStudentDto
    {
        public int StudentId {get; set;}
    }
}