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
    
    public partial class salepurchaseproduct
    {
        public int id { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<double> quantity { get; set; }
        public Nullable<double> total { get; set; }
        public Nullable<int> fk_product_salepurchaseproduct_product { get; set; }
        public Nullable<int> fk_financetransaction_salepurchaseproduct_financetransaction { get; set; }
    
        public virtual financetransaction financetransaction { get; set; }
        public virtual product product { get; set; }
    }
}
