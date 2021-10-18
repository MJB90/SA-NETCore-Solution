using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SA_NETCore_Solution.Models;
namespace SA_NETCore_Solution
{
    public class DB
    {
        private DbSongs dbContext;
        
        public DB(DbSongs dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Seed()
        {
            SeedGenre();
            SeedSongs();
        }
        public void SeedGenre()
        {
            dbContext.Add(new Genre
            {
                Name = "Classical"
            });
            dbContext.Add(new Genre
            {
                Name = "Pop"
            });
            dbContext.SaveChanges();
        } 
        public void SeedSongs()
        {
            Genre classical = dbContext.Genres.FirstOrDefault(x => x.Name == "Classical");
            Genre pop = dbContext.Genres.FirstOrDefault(x => x.Name == "Pop");

            dbContext.Add(new Song
            {
                Title = "Fly Me To The Moon",
                Mins = 5,
                Secs = 42,
                GenreId = pop.Id
            });
            dbContext.Add(new Song
            {
                Title = "Canon In D",
                Mins = 5,
                Secs = 11,
                GenreId = classical.Id
            });
            dbContext.Add(new Song
            {
                Title = "Let It Be",
                Mins = 5,
                Secs = 58,
                GenreId = pop.Id
            });
            dbContext.Add(new Song
            {
                Title = "Somewhere Out There",
                Mins = 4,
                Secs = 48,
                GenreId = pop.Id
            });
            dbContext.Add(new Song
            {
                Title = "Hallelujah",
                Mins = 4,
                Secs = 15,
                GenreId = classical.Id
            }); ;
            dbContext.SaveChanges();
        }
    }
}
