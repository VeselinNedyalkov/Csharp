using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    public class ExportGamesByGenresExportModel
    {
        public int Id { get; set; }
        public string Genre { get; set; }

        [JsonProperty("Games")]
        public GamesExportModel[] Games { get; set; }
        public int TotalPlayers { get; set; }
    }

    public class GamesExportModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Developer { get; set; }
        public string Tags { get; set; }
        public int Players { get; set; }
    }
}
