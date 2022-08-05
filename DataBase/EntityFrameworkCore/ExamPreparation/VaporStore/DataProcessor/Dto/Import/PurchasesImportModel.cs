using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchasesImportModel
    {
        [XmlAttribute("title")]
        public string GameName { get; set; }

        [XmlElement("Type")]
        [Required]
        public string Type { get; set; }

        [XmlElement("Key")]
        [RegularExpression(@"[A-Z\d]{4}[-][A-Z\d]{4}[-][A-Z\d]{4}")]
        public string ProductKey { get; set; }

        [XmlElement("Card")]
        [Required]
        public string Card { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }
    }
}

//< Purchase title = "Dungeon Warfare 2" >
//    < Type > Digital </ Type >
//    < Key > ZTZ3 - 0D2S - G4TJ </ Key >
//    < Card > 1833 5024 0553 6211 </ Card >
//    < Date > 07 / 12 / 2016 05:49 </ Date >

