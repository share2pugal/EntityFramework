using System;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var vidzyDbContext = new VidzyDbContext();

            vidzyDbContext.AddVideo("Test", DateTime.Today, "Comedy");


        }
    }
}
