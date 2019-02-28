using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneDiary.Models
{
    public partial class Person
    {
        public string FullName
        {
            get
            {
                return $"{Name} {LastName}";
            }
        }
    }
}