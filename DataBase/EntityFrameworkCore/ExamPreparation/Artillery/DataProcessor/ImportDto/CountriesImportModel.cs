using Artillery.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class CountriesImportModel
    {
        [Required]
        [XmlElement("CountryName")]
        [StringLength(60 , MinimumLength = 4)]
        public string CountryName { get; set; }

        [XmlElement("ArmySize")]
        [Range(50000,10000000)]
        public int ArmySize { get; set; }
    }
}


//< Countries >
//  < Country >
//    < CountryName > Afghanistan </ CountryName >
//    < ArmySize > 1697064 </ ArmySize >
//  </ Country >
//  < Country >
//    < CountryName > Afghan </ CountryName >
//    < ArmySize > 16 </ ArmySize >
//  </ Country >
//  < Country >
//    < CountryName > Albania </ CountryName >
//    < ArmySize > 6296389 </ ArmySize >
//  </ Country >
//  < Country >
//    < CountryName ></ CountryName >
//    < ArmySize > 2401223 </ ArmySize >
//  </ Country >
//  < Country >
//    < CountryName > Algeria </ CountryName >
//    < ArmySize > 1284683 </ ArmySize >
//  </ Country >
//…
//</ Countries >
