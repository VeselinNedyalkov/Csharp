using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class ExportPrisonersModel
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public EncryptedMessagesOutput[] EncryptedMessages { get; set; }
    }

    [XmlType("Message")]
    public class EncryptedMessagesOutput
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}

//<? xml version = "1.0" encoding = "utf-16" ?>
//< Prisoners >
//  < Prisoner >
//    < Id > 3 </ Id >
//    < Name > Binni Cornhill </ Name >
//    < IncarcerationDate > 1967 - 04 - 29 </ IncarcerationDate >
//    < EncryptedMessages >
//      < Message >
//        < Description > !? sdnasuoht evif - ytnewt rof deksa uoy ro orez artxe na ereht sI</Description>
//      </Message>
//    </EncryptedMessages>
//  </Prisoner>
