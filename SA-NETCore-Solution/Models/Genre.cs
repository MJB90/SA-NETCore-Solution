using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA_NETCore_Solution.Models
{
    public class Genre
    {
        public Genre()
        {
            Id = new Guid();
            Songs = new List<Song>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
