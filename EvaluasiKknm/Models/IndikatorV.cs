using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluasiKknm.Models
{
    public class IndikatorV
    {
        public string NamaProgram { get; set; } 
        public string NamaKel { get; set; } 
        public int? Skor { get; set; }
        public string Alasan { get; set; }
        public int? IdPenilaian { get; set; }
    }
}