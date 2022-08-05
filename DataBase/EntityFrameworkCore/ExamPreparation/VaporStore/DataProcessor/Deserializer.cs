namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
using System.Runtime.Intrinsics.X86;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			var jsonInput = JsonConvert.DeserializeObject<IEnumerable<GamesDevelopersGenresTagsImportModel>>
				(jsonString);

            foreach (var g in jsonInput)
            {
                if (!IsValid(g) || !g.Tags.Any())
                {
                    sb.AppendLine("Invalid Data");
					continue;
                }

				var game = new Game
				{
					Name = g.Name,
					Price = g.Price,
					ReleaseDate = g.ReleaseDate,
					Developer = context.Developers.FirstOrDefault(x => x.Name == g.Developer) ?? new Developer { Name = g.Developer },
					Genre = context.Genres.FirstOrDefault(x => x.Name == g.Genre) ?? new Genre { Name = g.Genre }
				};

                foreach (var t in g.Tags)
                {
					Tag GameTag = context.Tags.FirstOrDefault(x => x.Name == t) ?? new Tag { Name = t };
					game.GameTags.Add(new GameTag { Tag = GameTag });

				}

				context.Games.Add(game);
				context.SaveChanges();

				
				sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count()} tags");
            }


			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();
			List<User> users = new List<User>();

			var usersResult = JsonConvert.DeserializeObject<IEnumerable<UsersCardsInputModel>>(jsonString);

            foreach (var user in usersResult)
            {
                if (!IsValid(user) || !user.Cards.All(IsValid))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				User newUser = new User
				{
					FullName = user.FullName,
					Username = user.Username,
					Email = user.Email,
					Age = user.Age,
					Cards = user.Cards.Select(x => new Card
					{
						Number = x.Number,
						Cvc = x.CVC,
						Type = Enum.Parse<CardType>(x.Type)
					})
					.ToArray()
				};

				users.Add(newUser);
				sb.AppendLine($"Imported {newUser.Username} with {newUser.Cards.Count} cards");
			}

			context.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();
			List<Purchase> purches = new List<Purchase>();

			var xmlInput = XmlConverter.Deserializer<PurchasesImportModel>(xmlString, "Purchases");

            foreach (var xml in xmlInput)
            {
                if (!IsValid(xml))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				Purchase newPurchese = new Purchase
				{
					Game = context.Games.FirstOrDefault(x => x.Name == xml.GameName),
					Type = Enum.Parse<PurchaseType>(xml.Type),
					ProductKey = xml.ProductKey,
					Card = context.Cards.FirstOrDefault(x => x.Number == xml.Card),
					Date = DateTime.ParseExact(xml.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
				};

				purches.Add(newPurchese);
				sb.AppendLine($"Imported {newPurchese.Game.Name} for {newPurchese.Card.User.Username}");
			}

			context.Purchases.AddRange(purches);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}