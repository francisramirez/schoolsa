using School.Domain.Entities;
using School.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infrastructure.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
    }
}
