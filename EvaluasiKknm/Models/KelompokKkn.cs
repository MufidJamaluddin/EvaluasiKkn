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
    
    public partial class KelompokKkn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KelompokKkn()
        {
            this.DosenPembimbings = new HashSet<DosenPembimbing>();
            this.Mahasiswas = new HashSet<Mahasiswa>();
            this.Programs = new HashSet<Program>();
        }
    
        public int IdKel { get; set; }
        public string KodeDesa { get; set; }
        public Nullable<int> IdUniv { get; set; }
        public string NamaKel { get; set; }
        public Nullable<System.DateTime> TanggalMulai { get; set; }
        public Nullable<System.DateTime> TanggalAkhir { get; set; }
        public string NIMKetua { get; set; }
    
        public virtual Desa Desa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DosenPembimbing> DosenPembimbings { get; set; }
        public virtual Universita Universita { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mahasiswa> Mahasiswas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program> Programs { get; set; }
    }
}