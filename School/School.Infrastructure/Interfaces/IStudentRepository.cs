using School.Domain.Entities;
using School.Domain.Repository;


namespace School.Infrastructure.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
    }
}
