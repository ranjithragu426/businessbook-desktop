//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RIAB_Restaurent_Management_System.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_ExpenceSubHead
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_ExpenceSubHead()
        {
            this.tbl_Expence = new HashSet<tbl_Expence>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ExpenseHead_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Expence> tbl_Expence { get; set; }
        public virtual tbl_ExpenceHead tbl_ExpenceHead { get; set; }
    }
}