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

            // LINQ Syntax

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
                select new { AuthorName = a.Name, Courses = g.Count() };

            //Cross Join

            var cross =
                from c in conetxt.Courses
                from a in conetxt.Authors
                select new { CourseName = c.Name, AuthorName = a.Name };


            //Extention methods
            //filter

            var courcess = conetxt.Courses.Where(c => c.Level == 1);

            //ordering

            var ordercource = conetxt.Courses
                .Where(c => c.Level == 1)
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Level);

            //projection

            var projectionCource = conetxt.Courses.Where(c => c.Level == 1)
                .Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name });

            var tags = conetxt.Courses.Where(c => c.Level == 1)
                .SelectMany(c => c.Tags);

            //distinct

            var dis = conetxt.Courses.Where(c => c.Level == 1)
                .Distinct();


            //groupby

            var gr = conetxt.Courses.GroupBy(c => c.Level);

            foreach (var item in gr)
            {
                System.Console.WriteLine(item.Key);
                foreach (var ite in item)
                {
                    System.Console.WriteLine("\t" + ite.Name);
                }
            }
            //Inner Join

            conetxt.Courses.Join(conetxt.Authors
                , c => c.AuthorId
                , a => a.Id
                , (course, author) => new
                {
                    CourseName = course.Name,
                    AuthorName = author.Name
                });
            //Group Join

            conetxt.Authors.GroupJoin(conetxt.Courses, a => a.Id, c => c.AuthorId, (author, cous) => new
            {

                AuthorName = author.Name,
                courses = cous.Count()
            });

            //Crossjoin

            conetxt.Authors.SelectMany(c => conetxt.Courses, (author, course) => new
            {
                authorName = author.Name,
                courseName = course.Name
            });

            //Portitioning

            var coursesee = conetxt.Courses.Skip(10).Take(10);

            //Element oper

            var cq = conetxt.Courses.First();
            var b = conetxt.Courses.FirstOrDefault();
            var ag = conetxt.Courses.FirstOrDefault(ccc => ccc.FullPrice > 10);
            var da = conetxt.Courses.Single(co => co.Id == 1);
            var e = conetxt.Courses.SingleOrDefault(co => co.Id == 1);

            var aa = conetxt.Courses.All(cs => cs.FullPrice > 10);
            var bb = conetxt.Courses.Any(cc => cc.FullPrice > 10);

            //aggr

            conetxt.Courses.Count();
            conetxt.Courses.Max(cc => cc.FullPrice);
            conetxt.Courses.Max(cc => cc.FullPrice);
            conetxt.Courses.Average(cc => cc.FullPrice);



        }
    }
}
