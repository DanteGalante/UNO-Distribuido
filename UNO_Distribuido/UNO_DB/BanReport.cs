//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UNO_DB
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class BanReport
    {
        public int idBanReport { get; set; }
        public string reason { get; set; }
        public System.TimeSpan hour { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<int> FK_idPlayer { get; set; }
    
        public virtual Player Player { get; set; }
    }
}
