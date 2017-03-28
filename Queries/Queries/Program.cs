using System.Linq;
namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var conetxt = new PlutoContext();

            // LINQ Syntax
            var query =
                from c in conetxt.Courses
                where c.Name.Contains("C#")
                orderby c.Name
                select c;

            foreach (var item in query)
            {
                System.Console.WriteLine(item.Name);
            }

            System.Console.WriteLine("Ex");
            //Extention methods

            var courses = conetxt.Courses
                .Where(c => c.Name.Contains("C#"))
                .OrderBy(c => c.Name);

            foreach (var item in courses)
            {
                System.Console.WriteLine(item.Name);
            }


            // Query Filter

            var filter =
                from c in conetxt.Courses
                where c.Level == 1 && c.Author.Id == 1
                select c;

            //Ordering

            var order =
                from c in conetxt.Courses
                where c.Author.Id == 1
                orderby c.Level descending, c.Name
                select c;

            //Projection

            var projection =
                from c in conetxt.Courses
                where c.Author.Id == 1
                select new { Name = c.Name, Author = c.Author.Name };

            //Group

            var groups =
                from c in conetxt.Courses
                group c by c.Level into g
                select g;

            foreach (var group in groups)
            {
                System.Console.WriteLine(group.Key);

                foreach (var course in group)
                {
                    System.Console.WriteLine("\t{0}", course.Name);
                }
            }

            //groups with count

            var goup =
                from c in conetxt.Courses
                group c by c.Level into g
                select g;


            foreach (var item in goup)
            {
                System.Console.WriteLine("{0} ({1})", item.Key, item.Count());
            }

            //Inner Join with Navigation

            var q =
                from c in conetxt.Courses
                select new { CourseName = c.Name, AuthorName = c.Author.Name };

            //Inner Join With out Navigation

            var q1 =
                from c in conetxt.Courses
                join a in conetxt.Authors on c.AuthorId equals a.Id

                select new { CourseName = c.Name, AuthorName = a.Name };



            //Group join 

            var q2 =
                from a in conetxt.Authors
                join c in conetxt.Courses on a.Id equals c.AuthorId into g
                select new { AuthorName = a.Name,Courses= g.Count() };

            //Cross Join

            var cross =
                from c in conetxt.Courses
                from a in conetxt.Authors
                select new { CourseName = c.Name, AuthorName = a.Name };

        }
    }
}
