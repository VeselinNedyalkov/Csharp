﻿
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class UserPurchasesExportModel
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public PurchesOutputModel[] Purchases { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }

    [XmlType("Purchase")]
    public class PurchesOutputModel
    {
        [XmlElement("Card")]
        public string Card { get; set; }
        [XmlElement("Cvc")]
        public string Cvc { get; set; }

        [XmlElement("Date")] 
        public string Date { get; set; }

        [XmlElement("Game")]
        public GameInputModel Game { get; set; }
    }

    [XmlType("Game")]
    public class GameInputModel
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
//< User username = "mgraveson" >
//  < Purchases >
//    < Purchase >
//      < Card > 7991 7779 5123 9211 </ Card >
//      < Cvc > 340 </ Cvc >
//      < Date > 2017 - 08 - 31 17:09 </ Date >
//      < Game title = "Counter-Strike: Global Offensive" >
//        < Genre > Action </ Genre >
//        < Price > 12.49 </ Price >
//      </ Game >
//    </ Purchase >
//    < Purchase >
//      < Card > 7790 7962 4262 5606 </ Card >
//      < Cvc > 966 </ Cvc >
//      < Date > 2018 - 02 - 28 08:38 </ Date >
//      < Game title = "Tom Clancy's Ghost Recon Wildlands" >
//        < Genre > Action </ Genre >
//        < Price > 59.99 </ Price >
//      </ Game >
//    </ Purchase >
//  </ Purchases >
//  < TotalSpent > 72.48 </ TotalSpent >
//</ User >
