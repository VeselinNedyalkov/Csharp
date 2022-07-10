namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            string result = ExportAlbumsInfo(context, 7);
            Console.WriteLine(result);

            string result1 = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result1);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var output = context.Albums
                .Where(x => x.ProducerId.Value == producerId)
                .Include(x  =>  x.Songs)
                .ThenInclude(x => x.Writer) 
                .ToArray()
                .Select(a => new
                {
                    AlbumName = a.Name,
                    RelDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProdName = a.Producer.Name,
                    AlbumSongs = a.Songs
                    .Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        SongWriter = s.Writer.Name
                    })
                     .OrderByDescending(x => x.SongName)
                     .ThenBy(x => x.SongWriter)
                     .ToArray(),
                    TotalPrice = a.Price
                }).OrderByDescending(a => a.TotalPrice)
                .ToArray();


            foreach (var item in output)
            {
                sb.AppendLine($"-AlbumName: {item.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {item.RelDate}");
                sb.AppendLine($"-ProducerName: {item.ProdName}");
                sb.AppendLine("-Songs:");

                int counter = 1;

                foreach (var alb in item.AlbumSongs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {alb.SongName}");
                    sb.AppendLine($"---Price: {alb.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {alb.SongWriter}");
                }
                sb.AppendLine($"-AlbumPrice: {item.TotalPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var result = context.Songs
                .Include(x => x.SongPerformers)
                .ThenInclude(x => x.Performer)
                .Include(x => x.Writer)
                .Include(x => x.Album)
                .ThenInclude(x => x.Producer)
                .ToArray()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    PerformerName = s.SongPerformers
                    .Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}")
                    .FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    SongDuration = s.Duration.ToString("c"),
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.PerformerName)
                .ToArray();

            int count = 1;

            foreach (var song in result)
            {
                sb.AppendLine($"-Song #{count++}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.WriterName}")
                    .AppendLine($"---Performer: {song.PerformerName}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.SongDuration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
