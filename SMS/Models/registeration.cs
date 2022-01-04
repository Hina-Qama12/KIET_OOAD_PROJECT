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
    using System.ComponentModel.DataAnnotations;

    public partial class registeration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public registeration()
        {
            this.attendances = new HashSet<attendance>();
            this.teacher_course = new HashSet<teacher_course>();
            this.teacher_student = new HashSet<teacher_student>();
        }
        [Display(Name = "Registration Id:")]
        public int R_id { get; set; }

        [Display(Name = "Firstname:")]
        public string firstname { get; set; }

        [Display(Name = "Lastname:")]
        public string lastname { get; set; }

        [Display(Name = "NIC:")]
        public string nic { get; set; }

        [Display(Name = "Course Id:")]
        public Nullable<int> course_id { get; set; }

        [Display(Name = "Batch Id:")]
        public Nullable<int> batch_id { get; set; }

        [Display(Name = "Mobile Number:")]
        public Nullable<int> Mob_no { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<attendance> attendances { get; set; }
        public virtual batch batch { get; set; }
        public virtual course course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teacher_course> teacher_course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teacher_student> teacher_student { get; set; }
    }
}