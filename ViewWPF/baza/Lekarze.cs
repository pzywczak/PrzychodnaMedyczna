namespace ViewWPF.baza
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lekarze")]
    public partial class Lekarze
    {
        public int Id { get; set; }

        public string ImieINazwisko { get; set; }

        public string Adres { get; set; }

        public string Specjalizacja { get; set; }

        public int USERID { get; set; }

        public virtual Uzytkownicy Uzytkownicy { get; set; }
    }
}
