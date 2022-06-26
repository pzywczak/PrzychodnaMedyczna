namespace ViewWPF.baza
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wizyty")]
    public partial class Wizyty
    {
        public int Id { get; set; }

        public string Data { get; set; }

        public string Godzina { get; set; }

        public string TypWizyty { get; set; }

        public string ImieINazwiskoPacjenta { get; set; }

        public int USERID { get; set; }

        public virtual Uzytkownicy Uzytkownicy { get; set; }
    }
}
