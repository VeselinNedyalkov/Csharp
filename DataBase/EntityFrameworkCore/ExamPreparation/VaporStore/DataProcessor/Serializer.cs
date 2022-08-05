namespace VaporStore.DataProcessor
{
	using System;
using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;
public static class Serializer
{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var gamesExport = context.Genres
				.Where(x => genreNames.Contains(x.Name))				
				.ToArray()
				.Select(x => new ExportGamesByGenresExportModel
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games.Where(x => x.Purchases.Any())
					.Select(g => new GamesExportModel
					{
						Id = g.Id,
						Title = g.Name,
						Developer = g.Developer.Name,
						Tags = string.Join(", ", g.GameTags.Select(x => x.Tag.Name)),
						Players = g.Purchases.Count
					})
					.OrderByDescending(x => x.Players)
					.ThenBy(x => x.Id)
					.ToArray(),
					TotalPlayers = x.Games.Where(g => g.Purchases.Any()).Sum(g => g.Purchases.Count())
				})
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id)
				.ToArray();

			var answer = JsonConvert.SerializeObject(gamesExport , Formatting.Indented);

			return answer;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var typeInput = Enum.Parse<PurchaseType>(storeType);

			var userExport = context.Users
				.Where(x => x.Cards.Any(c => c.Purchases.Count(y => y.Type == typeInput) > 0))
				.ToList()
				.Select(u => new UserPurchasesExportModel
				{
					Username = u.Username,
					TotalSpent = u.Cards.Sum(c => c.Purchases.Where(p => p.Type == typeInput).Sum(p => p.Game.Price)),
					Purchases = u.Cards.SelectMany(p => p.Purchases)
					.Where(x => x.Type == typeInput)
					.Select(p => new PurchesOutputModel
					{
						Card = p.Card.Number,
						Cvc = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new GameInputModel
						{
							Title = p.Game.Name,
							Genre = p.Game.Genre.Name,
							Price = p.Game.Price
						}
					})
					.OrderBy(x => x.Date)
					.ToArray()
				})
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.Username)
				.ToArray();

			var xmlExport = XmlConverter.Serialize(userExport, "Users");

			return xmlExport;
		}
	}
}