using System;

namespace School.Application.Excepctions
{
    public class StudentServiceException : Exception
    {
        public StudentServiceException(string message) :base(message)
        {
            // realizar x logica //
        }
    }
}
