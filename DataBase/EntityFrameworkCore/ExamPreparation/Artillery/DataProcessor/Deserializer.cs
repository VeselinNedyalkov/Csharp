namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Artillery.Data;
    using Artillery.Data.Models;
using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            List<Country> countries = new List<Country>();

            var countryList = XmlConverter.Deserializer<CountriesImportModel>(xmlString, "Countries");

            foreach (var ctr in countryList)
            {
                if (!IsValid(ctr))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country countryInput = new Country
                {
                    CountryName = ctr.CountryName,
                    ArmySize = ctr.ArmySize
                };

                countries.Add(countryInput);
                sb.AppendLine(String.Format(SuccessfulImportCountry, countryInput.CountryName, countryInput.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            HashSet<string> validName = new HashSet<string>();

            var manufacInput = XmlConverter.Deserializer<ManufacturersImportModel>(xmlString, "Manufacturers");

            foreach (var man in manufacInput)
            {
                if (!IsValid(man) || validName.Contains(man.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Manufacturer manufacturer = new Manufacturer
                {
                    ManufacturerName = man.ManufacturerName,
                    Founded = man.Founded
                };

                manufacturers.Add(manufacturer);
                validName.Add(man.ManufacturerName);

                string[] foundedArray = manufacturer.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string townName = foundedArray[foundedArray.Length - 2];
                string countryName = foundedArray[foundedArray.Length - 1];

                sb.AppendLine(string.Format($"Successfully import manufacturer {manufacturer.ManufacturerName}" +
                    $" founded in {townName}, {countryName}."));
            }

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            List<Shell> shells = new List<Shell>();

            var shellInput = XmlConverter.Deserializer<ShellImportModel>(xmlString, "Shells");

            foreach (var sh in shellInput)
            {
                if (!IsValid(sh))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell
                {
                    ShellWeight = sh.ShellWeight,
                    Caliber = sh.Caliber
                };

                shells.Add(shell);
                sb.AppendLine(String.Format(SuccessfulImportShell,
                    shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Gun> guns = new List<Gun>();

            var gunsInput = JsonConvert.DeserializeObject<IEnumerable<GunsImportModel>>(jsonString);

            foreach (var gun in gunsInput)
            {

                if (!IsValid(gun) )
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gunInput = new Gun
                {
                    ManufacturerId = gun.ManufacturerId,
                    GunWeight = gun.GunWeight,
                    BarrelLength = gun.BarrelLength,
                    NumberBuild = gun.NumberBuild,
                    Range = gun.Range,
                    GunType = Enum.Parse<GunType>(gun.GunType),
                    ShellId = gun.ShellId,
                    CountriesGuns = gun.Countries.Select(cn => new CountryGun
                    {
                        CountryId = cn.Id,
                    })
                    .ToList(),
                };

                guns.Add(gunInput);

                sb.AppendLine(String.Format(SuccessfulImportGun,
                   gunInput.GunType.ToString(), gunInput.GunWeight, gunInput.BarrelLength));
            }

            context.Guns.AddRange(guns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
