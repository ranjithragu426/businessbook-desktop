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
    
    public partial class tbl_DealFoodItem
    {
        public int Id { get; set; }
        public Nullable<int> Deal_Id { get; set; }
        public Nullable<int> FoodItem_Id { get; set; }
    
        public virtual tbl_Deal tbl_Deal { get; set; }
        public virtual tbl_FoodItem tbl_FoodItem { get; set; }
    }
}