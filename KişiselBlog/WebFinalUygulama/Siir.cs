//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebFinalUygulama
{
    using System;
    using System.Collections.Generic;
    
    public partial class Siir
    {
        public int SiirNo { get; set; }
        public string SiirBaslik { get; set; }
        public string SiirBirinciSatir { get; set; }
        public string SiirIkinciSatir { get; set; }
        public string SiiUcuncuSatir { get; set; }
        public string SiirDorduncuSatir { get; set; }
        public Nullable<System.DateTime> SiirTarihi { get; set; }
        public Nullable<int> YorumNo { get; set; }
    
        public virtual Yorum Yorum { get; set; }
    }
}
