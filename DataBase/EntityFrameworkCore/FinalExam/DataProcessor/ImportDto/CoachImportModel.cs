using Footballers.Data.Models.Enums;
using Footballers.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class CoachImportModel
    {
        [Required]
        [XmlElement("Name")]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [XmlElement("Nationality")]
        public string Nationality { get; set; }

        [XmlArray("Footballers")]
        public FootballerImputModel[] Footballers { get; set; }
    }

    [XmlType("Footballer")]
    public class FootballerImputModel
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40 , MinimumLength = 2)]
        public string Name { get; set; }

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; }

        [XmlElement("BestSkillType")]
        [EnumDataType(typeof(BestSkillType))]
        public int BestSkillType { get; set; }

        [XmlElement("PositionType")]
        [EnumDataType(typeof(PositionType))]
        public int PositionType { get; set; }
    }
}

//< Coaches >
//  < Coach >
//    < Name > S </ Name >
//    < Nationality > 25 / 01 / 2018 </ Nationality >
//    < Footballers >
//      < Footballer >
//        < Name > Benjamin Bourigeaud </ Name >
//           < ContractStartDate > 22 / 03 / 2020 </ ContractStartDate >
//           < ContractEndDate > 24 / 02 / 2026 </ ContractEndDate >
//           < BestSkillType > 2 </ BestSkillType >
//           < PositionType > 2 </ PositionType >
//         </ Footballer >
//         < Footballer >
//           < Name > Martin Terrier </ Name >
//              < ContractStartDate > 29 / 12 / 2021 </ ContractStartDate >
//              < ContractEndDate > 16 / 06 / 2024 </ ContractEndDate >
//              < BestSkillType > 2 </ BestSkillType >
//              < PositionType > 3 </ PositionType >
//            </ Footballer >
//          </ Footballers >
//        </ Coach >

