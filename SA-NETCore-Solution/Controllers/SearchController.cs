using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SA_NETCore_Solution.Models;

namespace SA_NETCore_Solution.Controllers
{
    public class SearchController : Controller
    {
        private DbSongs dbContext;
        public SearchController(DbSongs dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Duration(string mins,string secs)
        {
            int minutes = Convert.ToInt32(mins);
            int seconds = Convert.ToInt32(secs);

            List<Song> songs = dbContext.Songs.Where(x=>x.Mins>=minutes).ToList();
            List<Song> SearchedSongs = new List<Song>();
            foreach(Song song in songs)
            {
                if((song.Mins>minutes)||(song.Mins==minutes && song.Secs >= seconds))
                {
                    SearchedSongs.Add(song);
                }
            }
            List<Genre> genres = dbContext.Genres.ToList();

            var songlist = from song in SearchedSongs
                           from genre in genres
                           where song.GenreId == genre.Id
                           orderby (song.Mins.ToString() + song.Secs.ToString()) descending
                           select new
                           {
                               song.Title,
                               Length = song.Mins.ToString() + ":" + song.Secs.ToString(),
                               genre.Name
                           };
            List<FinalSongs> toReturnSongs = new List<FinalSongs>(); 
            foreach(var song in songlist)
            {
                toReturnSongs.Add(new FinalSongs{
                    Title = song.Title,
                    Length = song.Length,
                    Name = song.Name
                });
            }
            ViewData["SongList"] =toReturnSongs;
            ViewData["mins"] = mins;
            ViewData["secs"] = secs;
            return View();
        }
    }
}
