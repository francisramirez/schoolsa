using School.Application.Core;
using School.Application.Dtos.Course;
 

namespace School.Application.Contracts
{
    public interface ICourseService : IBaseService<CourseDtoAdd, CourseDtoUpdate, CourseDtoRemove>
    {
        
    }
}
