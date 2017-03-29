using System.Data.Entity;
using System.Linq;
namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddVideo();
            AddTags("Classics");
            AddTags("Drama");
            AddTagstoVideo(1, "Classics", "Drama", "Comedy");
            RemoveTagFromVideo(1, "Comedy");
            RemoveVideo(1);
            RemoveGenre(2, true);
        }

        public static void AddVideo()
        {
            using (var context = new VidzyContext())
            {
                context.Videos.Add(
                    new Video
                    {
                        Name = "Terminator1",
                        GenreId = 2,
                        ReleaseDate = new System.DateTime(1984, 10, 26),
                        Classification = Classification.Silver
                    });
                context.SaveChanges();
            }
        }

        public static void AddTags(string name)
        {

            using (var context = new VidzyContext())
            {
                if (context.Tags.Any(t => t.Name.Contains(name)))
                    return;

                context.Tags.Add(
                    new Tag
                    {
                        Name = name
                    });
                context.SaveChanges();
            }
        }
        public static void AddTagstoVideo(int id, params string[] tagNames)
        {
            using (var context = new VidzyContext())
            {

                var tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();
                if (tags == null)
                    return;

                foreach (var item in tagNames)
                {

                    if (!tags.Any(t => t.Name.Contains(item)))
                        tags.Add(new Tag { Name = item });

                }
                var video = context.Videos.Find(id);
                if (video == null)
                    return;

                tags.ForEach(t => video.AddTag(t));



                context.SaveChanges();

            }
        }

        public static void RemoveTagFromVideo(int videoId, params string[] tagNames)
        {

            using (var context = new VidzyContext())
            {


                var video = context.Videos.SingleOrDefault(v => v.Id == videoId);

                if (video == null)
                    return;

                foreach (var item in tagNames)
                {
                    video.RemoveTag(item);
                }

                context.SaveChanges();
            }
        }

        public static void RemoveVideo(int videoId)
        {
            using (var context = new VidzyContext())
            {
                var video = context.Videos.Include(v => v.Tags).SingleOrDefault(v => v.Id == videoId);

                if (video == null)
                    return;
                context.Videos.Remove(video);
                context.SaveChanges();

            }

        }

        public static void RemoveGenre(int genreId,bool removevides)
        {
            using (var context = new VidzyContext())
            {

                var genre = context.Genres.Include(g => g.Videos).SingleOrDefault(g => g.Id == genreId);

                if (genre == null)
                    return;

                if(removevides)
                context.Videos.RemoveRange(genre.Videos);

                context.Genres.Remove(genre);

                context.SaveChanges();

            }

        }



    }
}
