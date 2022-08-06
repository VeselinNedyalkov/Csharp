using Artillery.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Shell")]
    public class ShellImportModel
    {
        [XmlElement("ShellWeight")]
        [Range(2 , 1680)]
        public double ShellWeight { get; set; }

        [XmlElement("Caliber")]
        [StringLength(30 , MinimumLength = 4)]
        [Required]
        public string Caliber { get; set; }
    }
}


//< Shells >
//  < Shell >
//    < ShellWeight > 50 </ ShellWeight >
//    < Caliber > 155 mm(6.1 in) </ Caliber >
//  </ Shell >
