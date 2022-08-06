
namespace Artillery.DataProcessor
{
    using Artillery.Data;
using Artillery.Data.Models;
using Artillery.Data.Models.Enums;
using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shellsExport = context.Shells
                .Where(x => x.ShellWeight > shellWeight)
                .ToArray()
                .Select(sh => new
                {
                    ShellWeight = sh.ShellWeight,
                    Caliber = sh.Caliber,
                    Guns = sh.Guns
                    .Where(x => x.GunType.ToString() == "AntiAircraftGun")
                    .Select(g => new
                    {
                        GunType = g.GunType.ToString(),
                        GunWeight = g.GunWeight,
                        BarrelLength = g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range"
                    })
                    .ToArray()
                    .OrderByDescending(x => x.GunWeight)
                })
                .OrderBy(x => x.ShellWeight)
                .ToArray();

            var jsonExport = JsonConvert.SerializeObject(shellsExport , Formatting.Indented);

            return jsonExport;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var gunsExport = context.Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .ToArray()
                .Select(gn => new GunsExportModel
                {
                    Manufacturer = gn.Manufacturer.ManufacturerName,
                    GunType = gn.GunType.ToString(),
                    GunWeight = gn.GunWeight,
                    BarrelLength = gn.BarrelLength,
                    Range = gn.Range,
                    Countries = gn.CountriesGuns
                    .Where(x => x.Country.ArmySize > 4500000)
                    .ToArray()
                    .Select(cn => new CountriExport
                    {
                        Country = cn.Country.CountryName,
                        ArmySize = cn.Country.ArmySize
                    })
                    .OrderBy(x => x.ArmySize)
                    .ToArray()
                })
                .OrderBy(x => x.BarrelLength)
                .ToArray();

            var XmlExport = XmlConverter.Serialize(gunsExport, "Guns");

            return XmlExport;
        }
    }
}
