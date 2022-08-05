using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeesImportModel
    {
        [Required]
        [StringLength(40 , MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z0-9]+$")]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"[\d]{3}[-][\d]{3}[-][\d]{4}")]
        public string Phone { get; set; }

        public ICollection<int> Tasks { get; set; }
    }
}
