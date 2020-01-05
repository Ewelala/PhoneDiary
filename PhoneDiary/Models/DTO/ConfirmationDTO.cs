using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneDiary.Models.DTO
{
    /// <summary>
    /// Klasa pomocnicza dla usuwania rekordów z bazy danych. Posiada tylko dwie potrzebne właściwości.
    /// </summary>
    public class ConfirmationDTO
    {
        /// <summary>
        /// Nazwa funkcji którą należy wykonać po stronie JavaScript, w celu usunięcia rekordu.
        /// </summary>
        public string Function { get; set; }
        /// <summary>
        /// Id rekordu do usunięcia z bazy danych.
        /// </summary>
        public string Id { get; set; }
    }
}