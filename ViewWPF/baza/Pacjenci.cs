namespace ViewWPF.baza
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pacjenci")]
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
