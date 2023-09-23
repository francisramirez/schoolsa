using School.Domain.Core;
using System;

namespace School.Domain.Entities
{
    public class Instructor : Person
    {
       public int Id { get; set; }
       public DateTime? HireDate { get; set; }


    }
}
