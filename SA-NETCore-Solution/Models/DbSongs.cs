using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SA_NETCore_Solution.Models
{
    public class DbSongs : DbContext
    {
        public DbSongs(DbContextOptions<DbSongs> options) : base(options)
        {

        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
