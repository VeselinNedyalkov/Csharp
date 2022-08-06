using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class CoachesExportModel
    {
        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        [XmlElement("CoachName")]
        public string CoachName { get; set; }

        [XmlArray("Footballers")]
        public FootballerExportModel[] Footballers { get; set; }
    }

    [XmlType("Footballer")]
    public class FootballerExportModel
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }
    }
}

//< Coaches >
//  < Coach FootballersCount = "5" >
//     < CoachName > Pep Guardiola </ CoachName >
//        < Footballers >
//          < Footballer >
//            < Name > Bernardo Silva </ Name >
//               < Position > Midfielder </ Position >
//             </ Footballer >

