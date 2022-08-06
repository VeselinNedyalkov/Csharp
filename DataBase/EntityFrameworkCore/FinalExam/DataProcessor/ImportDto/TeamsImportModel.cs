using Footballers.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamsImportModel
    {
        [Required]
        [StringLength(40 , MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z0-9\s.-]+$")]
        public string Name { get; set; }

        [Required]
        [StringLength(40 , MinimumLength = 2)]
        public string Nationality { get; set; }

        [Range(typeof(int), "1", "2147483647")]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public IEnumerable<int> Footballers { get; set; }
    }

}

//"Name": "Brentford F.C.",
//    "Nationality": "The United Kingdom",
//    "Trophies": "5",
//    "Footballers": [
//      28,
//      28,
//      39,
//      57

