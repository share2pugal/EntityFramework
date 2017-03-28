
using System;
using System.Linq;
namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            var actionMovies = context.Videos.Where(c => c.GenreId == 2).OrderBy(c => c.Name);

            foreach (var item in actionMovies)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\n");
            var drama = context.Videos
                .Where(c => c.GenreId == 7 && c.Classification==Classification.Gold)
                .OrderByDescending(c => c.ReleaseDate);


            foreach (var item in drama)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("\n");
            var allmovies = context.Videos.Select(c => new { MovieName = c.Name, GenreName = c.Genre.Name });

            foreach (var item in allmovies)
            {
                Console.WriteLine(item.MovieName);
            }
            Console.WriteLine("\n");

            var allmoviegroupbyclass = context.Videos.GroupBy(c => c.Classification);

            foreach (var classi in allmoviegroupbyclass)
            {
                Console.WriteLine("Classification:" + classi.Key);
                foreach (var movie in classi)
                {
                    Console.WriteLine(movie.Name);
                }
                Console.WriteLine("\n");

            }
            Console.WriteLine("\n");

            var listofclassification = context.Videos.GroupBy(c => c.Classification);
            foreach (var item in listofclassification)
            {
                Console.WriteLine("{0} ({1})", item.Key, item.Count());
            }
            Console.WriteLine("\n");

            var listofgenres = context.Genres
                .GroupJoin(context.Videos, g => g.Id,
                c => c.GenreId,
                (genre, videos) => new
                {
                    GenreName = genre.Name,
                    Count = videos.Count()
                }).OrderByDescending(v => v.Count);

            foreach (var item in listofgenres)
            {
                Console.WriteLine("{0} ({1})", item.GenreName, item.Count);

            }
        }
    }
}
