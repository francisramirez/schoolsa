

using System;

namespace School.Application.Excepctions
{
    public class CourseServiceException : Exception
    {
        public CourseServiceException(string message):base(message)
        {
            // x logica para envio de notificaciones o logger.
        }
        
    }
}
