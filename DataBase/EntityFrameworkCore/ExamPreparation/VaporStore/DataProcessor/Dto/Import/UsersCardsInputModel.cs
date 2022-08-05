using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UsersCardsInputModel
    {
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]+[ ][A-Z]{1}[a-z]+")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20 , MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
        [Range(3,103)]
        public int Age { get; set; }

        public IEnumerable<CardImportModel> Cards { get; set; }
    }

    public class CardImportModel
    {
        [Required]
        [RegularExpression(@"[\d]{4}[ ][\d]{4}[ ][\d]{4}[ ][\d]{4}")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"[\d]{3}")]
        public string CVC { get; set; }

        [Required]
        [EnumDataType(typeof(CardType))]
        public string Type { get; set; }
    }
}
