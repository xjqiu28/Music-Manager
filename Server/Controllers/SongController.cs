using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public SongsController(DataDbContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            if (song == null)
            {
                return BadRequest("Song cannot be null.");
            }


            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Song>>> SearchSongs(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return BadRequest("Song cannot be found.");
            }
            var matchingSongs = await _context.Songs.Where(song => song.Title.ToLower().Contains(s.ToLower()) || song.Artist.ToLower().Contains(s.ToLower())||song.Album.ToLower().Contains(s.ToLower())).ToListAsync();

            if (!matchingSongs.Any())
            {
                return NotFound("No songs matched the search term.");
            }
            return Ok(matchingSongs);
        }
    }
}
