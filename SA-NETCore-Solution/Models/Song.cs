using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA_NETCore_Solution.Models
{
    public class Song
    {
        public Song()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Mins { get; set; }
        public int Secs { get; set; }
        public virtual Guid GenreId { get; set; }
    }
}
