
using System;
using System.Data.Entity;
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
                (genre, vides) => new
                {
                    GenreName = genre.Name,
                    Count = vides.Count()
                }).OrderByDescending(v => v.Count);

            foreach (var item in listofgenres)
            {
                Console.WriteLine("{0} ({1})", item.GenreName, item.Count);

            }
            // To enable lazy loading, you need to declare navigation properties
            // as virtual. Look at the Video class.

            var videos = context.Videos.ToList();

            Console.WriteLine();
            Console.WriteLine("LAZY LOADING");
            foreach (var v in videos)
                Console.WriteLine("{0} ({1})", v.Name, v.Genre.Name);

            // Eager loading
            var videosWithGenres = context.Videos.Include(v => v.Genre).ToList();

            Console.WriteLine();
            Console.WriteLine("EAGER LOADING");
            foreach (var v in videosWithGenres)
                Console.WriteLine("{0} ({1})", v.Name, v.Genre.Name);

            // Explicit loading

            // NOTE: At this point, genres are already loaded into the context,
            // so the following line is not going to make a difference. If you 
            // want to see expicit loading in action, comment out the eager loading 
            // part as well as the foreach block in the lazy loading.
            context.Genres.Load();

            Console.WriteLine();
            Console.WriteLine("EXPLICIT LOADING");
            foreach (var v in videos)
                Console.WriteLine("{0} ({1})", v.Name, v.Genre.Name);

        }
    }
}
