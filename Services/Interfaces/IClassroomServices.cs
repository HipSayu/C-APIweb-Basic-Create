using ApiWebBasicPlatFrom.Dtos.Classroom;
using ApiWebBasicPlatFrom.Dtos.Shared;
using ApiWebBasicPlatFrom.Dtos.Students;
using ApiWebBasicPlatFrom.Entites;

namespace ApiBasic.Services.Interfaces
{
    public interface IClassroomServices
    {
        void Create(CreateClassroomDto input);
        PageResultDto<List<Classroom>> GetClassroom(FilterDto input);

        ClassroomDto GetById(int StudentId);

        void UpdateClassroom(UpdateClassroomDto input);

        void DeleteStudentById(int ClassroomId);

        
    }
}
