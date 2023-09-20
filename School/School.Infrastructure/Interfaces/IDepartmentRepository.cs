
using School.Domain.Entities;
using School.Domain.Repository;

namespace School.Infrastructure.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        // Aqui van los metodos esclusivos del la entidad //
    }
}
