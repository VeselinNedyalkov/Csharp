using SoftJail.Data.Models.Enums;
using System;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficersPrisonersInputModel
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(30, MinimumLength = 3)]
        
        public string Fullname { get; set; }

        [XmlElement("Money")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Salary { get; set; }

        [XmlElement("Position")]
        [EnumDataType(typeof(Position))]
        [Required]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [EnumDataType(typeof(Weapon))]
        [Required]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonerInputModel[] Prisoners { get; set; }

    }

    [XmlType("Prisoner")]
    public class PrisonerInputModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}

//< Officers >
//  < Officer >
//    < Name > Minerva Kitchingman </ Name >
//    < Money > 2582 </ Money >
//    < Position > Invalid </ Position >
//    < Weapon > ChainRifle </ Weapon >
//    < DepartmentId > 2 </ DepartmentId >
//    < Prisoners >
//      < Prisoner id = "15" />
//    </ Prisoners >
//  </ Officer >

