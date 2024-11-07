using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public PlaylistsController(DataDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            return await _context.Playlists.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylistById(int id)
        {
            var playlist =  await _context.Playlists.FindAsync(id);
            return playlist;
        }

        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
            if (playlist == null)
            {
                return BadRequest("Playlist cannot be null.");
            }


            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Playlist>> DeletePlaylist(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            Console.WriteLine($"Playlist details: Id = {playlist.Id}, Name = {playlist.Name}, Creator = {playlist.Creator}");
            if (playlist == null)
            {
                return BadRequest();
            }
            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<Playlist>> EditPlaylist(int id, [FromBody] Playlist updatedPlaylist)
        {
            var playlist = await _context.Playlists.FindAsync(id);

            if (playlist == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(updatedPlaylist.Name))
            {
                playlist.Name = updatedPlaylist.Name; // Update the name
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the updated playlist
            return Ok(playlist);
        }
    }
}
