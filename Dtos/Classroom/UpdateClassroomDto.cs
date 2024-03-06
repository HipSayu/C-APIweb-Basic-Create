using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Dtos.Classroom
{
    public class UpdateClassroomDto : CreateClassroomDto
    {
        public int ClassroomId {get; set ;}
    }
}