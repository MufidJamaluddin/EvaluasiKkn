//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EvaluasiKknm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pemda
    {
        public string Username { get; set; }
        public string NIP { get; set; }
        public string KodeDesa { get; set; }
        public string NamaLengkap { get; set; }
    
        public virtual Akun Akun { get; set; }
        public virtual Desa Desa { get; set; }
    }
}
