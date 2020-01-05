using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneDiary.Models
{
    /// <summary>
    /// Klasa częściowa dla Modelu Person. Pomocnicza która nie generuje się automatycznie.
    /// </summary>
    public partial class Person
    {
        /// <summary>
        /// Zwraca pełne imię i nazwisko potrzebne w widokach.
        /// </summary>
        public string FullName
        {
            get
            {
                return $"{Name} {LastName}";
            }
        }
    }
}