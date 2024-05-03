using System.Globalization;
using System.Text;

namespace MusicHub
{
    using Data;
    using Initializer;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            int producerId = 9;
            Console.WriteLine(ExportAlbumsInfo(context, producerId));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .ToArray() //because of the calculated property, could be fixed in latest versions of EF but Judge uses 6.0.1
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.Writer.Name)
                        .Select(s => new
                        {
                            SongName = s.Name,
                            s.Price,
                            WriterName = s.Writer.Name
                        })
                        .ToArray(),
                    a.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int songCount = 0;
                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{++songCount}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
