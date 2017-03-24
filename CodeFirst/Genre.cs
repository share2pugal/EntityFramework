using System.Collections.Generic;

namespace CodeFirst
{
    public class Genre
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        public List<Video> Videos { get; set; }
    }
}
