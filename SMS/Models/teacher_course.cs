//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class teacher_course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public teacher_course()
        {
            this.teacher_student = new HashSet<teacher_student>();
        }
    
        public int t_c_id { get; set; }
        public Nullable<int> teacher_id { get; set; }
        public Nullable<int> C_id { get; set; }
        public Nullable<int> R_id { get; set; }
    
        public virtual course course { get; set; }
        public virtual registeration registeration { get; set; }
        public virtual teacher teacher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teacher_student> teacher_student { get; set; }
    }
}
