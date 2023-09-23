using School.Domain.Entities;

using System.Collections.Generic;


namespace School.Domain.Repository
{
    public interface IStudentRepository
    {
        void Save(Student student);

        void Update(Student student);
        void Remove(Student student);
        List<Student> GetStudents();
        Student GetStudent(int Id);

    }
}
