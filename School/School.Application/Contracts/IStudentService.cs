using School.Application.Core;
using School.Application.Dtos.Student;

namespace School.Application.Contracts
{
    public interface IStudentService : IBaseServices<StudentDtoAdd, StudentDtoUpdate, StudentDtoRemove>
    {

    }
}
