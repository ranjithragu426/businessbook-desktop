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
    
    public partial class tbl_Deal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Deal()
        {
            this.tbl_DealFoodItem = new HashSet<tbl_DealFoodItem>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<double> SalePrice { get; set; }
        public Nullable<bool> ManageInventory { get; set; }
        public string Recipe { get; set; }
        public Nullable<int> Category_Id { get; set; }
    
        public virtual tbl_FoodItemCategory tbl_FoodItemCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_DealFoodItem> tbl_DealFoodItem { get; set; }
    }
}
