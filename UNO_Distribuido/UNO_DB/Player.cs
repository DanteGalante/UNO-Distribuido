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
    
    public partial class Player
    {
        public int idPlayer { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string lastnames { get; set; }
        public byte[] avatarImage { get; set; }
        public Nullable<bool> isBanned { get; set; }
        public Nullable<bool> isLogged { get; set; }
    }
}