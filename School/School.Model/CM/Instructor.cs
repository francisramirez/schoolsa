//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace School.Model.CM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Instructor
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public int CreationUser { get; set; }
        public Nullable<int> UserMod { get; set; }
        public Nullable<int> UserDeleted { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
