//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViewWPF.baza
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pacjenci
    {
        public int Id { get; set; }
        public string ImieINazwisko { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public int USERID { get; set; }
    
        public virtual Uzytkownicy Uzytkownicy { get; set; }
    }
}
