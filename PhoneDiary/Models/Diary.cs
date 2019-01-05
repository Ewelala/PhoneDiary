namespace PhoneDiary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Diary
    {
        public int ID { get; set; }
        [Display(Name = "Osoba")]
        public int PersonID { get; set; }
        [Display(Name = "Adres")]
        public int AddressID { get; set; }
        [Display(Name = "Numer")]
        public int Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public virtual Address Address { get; set; }
        public virtual Person Person { get; set; }
    }
}