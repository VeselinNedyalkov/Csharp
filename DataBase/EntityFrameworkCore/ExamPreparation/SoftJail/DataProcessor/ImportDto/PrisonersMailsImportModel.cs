using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonersMailsImportModel
    {
        public PrisonersMailsImportModel()
        {
            Mails = new HashSet<MailImportModel>();
        }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int age { get; set; }
        public string IncarcerationDate { get; set; }
        public string ReleaseDate { get; set; }
        public decimal Bail { get; set; }
        public int CellId { get; set; }

        public ICollection<MailImportModel> Mails { get; set; }

    }

    public class MailImportModel
    {

    }
}



//{
//    "FullName": "",
//    "Nickname": "The Wallaby",
//    "Age": 32,
//    "IncarcerationDate": "29/03/1957",
//    "ReleaseDate": "27/03/2006",
//    "Bail": null,
//    "CellId": 5,
//    "Mails": [
//      {
//        "Description": "Invalid FullName",
//        "Sender": "Invalid Sender",
//        "Address": "No Address"
//      },
//      {
//        "Description": "Do not put this in your code",
//        "Sender": "My Ansell",
//        "Address": "ha-ha-ha"
//      }
//    ]
//  },
